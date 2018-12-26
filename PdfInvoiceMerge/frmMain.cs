using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PdfInvoiceMerge
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Icon = PdfInvoiceMerge.Properties.Resources.Invoice;
            RefreshState();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dlg = openFileDialog1.ShowDialog();
            if (dlg != DialogResult.OK)
                return;
            listInvoices.Items.AddRange(openFileDialog1.FileNames);
            RefreshState();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listInvoices.Items.Clear();
            RefreshState();
        }

        private void RefreshState()
        {
            var has = listInvoices.Items.Count > 0;
            labInfo.Text = has ? $"共 { listInvoices.Items.Count} 张发票" : "就绪";
            btnClear.Enabled = has;
            btnMerge.Enabled = has;
            if (has && listInvoices.SelectedIndex < 0)
                listInvoices.SelectedIndex = 0;
        }

        private void listInvoices_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Delete)
                return;
            var values = listInvoices.SelectedItems.OfType<object>().ToArray();
            if (values.Length == 0)
                return;
            else if (values.Length == 1)
            {
                var index = listInvoices.SelectedIndex;
                listInvoices.Items.RemoveAt(index);
                if (index < listInvoices.Items.Count)
                    listInvoices.SelectedIndex = index;
                else if (listInvoices.Items.Count > 0)
                    listInvoices.SelectedIndex = listInvoices.Items.Count - 1;
                RefreshState();
            }
            else
            {
                foreach (var value in values)
                    listInvoices.Items.Remove(value);
                RefreshState();
            }
        }

        private void listInvoices_DoubleClick(object sender, EventArgs e)
        {
            if (listInvoices.SelectedIndex >= 0)
            {
                Process.Start(listInvoices.SelectedItem as string);
            }
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            var items = (Array)e.Data.GetData(DataFormats.FileDrop);
            var files = new List<string>();
            foreach (object item in items)
            {
                string path = item.ToString();
                var info = new FileInfo(path);

                if (info.Attributes.HasFlag(FileAttributes.Directory))
                    files.AddRange(Directory.GetFiles(path, "*.pdf", SearchOption.AllDirectories));
                else if (File.Exists(path) && path.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase))
                    files.Add(path);
            }
            if (files.Any())
            {
                listInvoices.Items.AddRange(files.ToArray());
                RefreshState();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbMergeType.SelectedIndex = 1;
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (listInvoices.Items.Count == 0)
            {
                MessageBox.Show("请先添加至少一张发票。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dlg = saveFileDialog1.ShowDialog();
            if (dlg != DialogResult.OK)
                return;
            var type = cmbMergeType.SelectedIndex;

            var files = listInvoices.Items.Cast<string>().ToList();
            try
            {
                switch (cmbMergeType.SelectedIndex)
                {
                    case 0:
                        Merge1(files, saveFileDialog1.FileName);
                        break;
                    case 1:
                    default:
                        Merge2(files, saveFileDialog1.FileName);
                        break;
                    case 2:
                        Merge4(files, saveFileDialog1.FileName);
                        break;
                }

                Process.Start(saveFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "合并失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// 每页一张发票
        /// </summary>
        /// <param name="files"></param>
        /// <param name="outputFile"></param>
        public static void Merge1(IEnumerable<string> files, string outputFile)
        {
            Document document = new Document();
            try
            {
                using (FileStream newFileStream = new FileStream(outputFile, FileMode.Create))
                {
                    PdfCopy writer = new PdfCopy(document, newFileStream);
                    if (writer == null)
                    {
                        return;
                    }

                    document.Open();

                    foreach (string file in files)
                    {
                        PdfReader reader = new PdfReader(file);
                        reader.ConsolidateNamedDestinations();

                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            PdfImportedPage page = writer.GetImportedPage(reader, i);
                            writer.AddPage(page);
                        }
                        reader.Close();
                    }
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                document.Close();
            }
        }


        /// <summary>
        /// 每页两张发票
        /// </summary>
        /// <param name="files"></param>
        /// <param name="outputFile"></param>
        public static void Merge2(IEnumerable<string> files, string outputFile)
        {
            var queue = new ConcurrentQueue<string>(files);
            var document = new Document();
            var margin = 20;
            try
            {
                var writer = PdfWriter.GetInstance(document, new FileStream(outputFile, FileMode.Create));
                var size = PageSize.A4;
                document.Open();
                document.SetPageSize(size);
                PdfContentByte cb = writer.DirectContent;

                do
                {
                    document.NewPage();
                    if (TryAppendPage(true) == false)
                        break;
                    if (TryAppendPage(false) == false)
                        break;
                } while (true);

                bool TryAppendPage(bool top)
                {
                    if (queue.TryDequeue(out var p) == false)
                        return false;

                    var reader = new PdfReader(p);
                    var page = writer.GetImportedPage(reader, 1);

                    AffineTransform af = new AffineTransform();

                    var scaleHeight = (size.Height - margin * 4) / 2 / page.Height;
                    var scaleWidth = (size.Width - margin * 2) / page.Width;
                    var scale = Math.Min(scaleHeight, scaleWidth);

                    var height = ((size.Height - margin * 4) / 2 - scale * page.Height) / 2;
                    var width = ((size.Width - margin * 2) - scale * page.Width) / 2;

                    af.Translate(margin + width, margin + height + (top ? size.Height / 2 : 0));
                    af.Scale(scale, scale);

                    cb.AddTemplate(page, af);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                document.Close();
            }
        }


        /// <summary>
        /// 每页两张发票
        /// </summary>
        /// <param name="files"></param>
        /// <param name="outputFile"></param>
        public static void Merge4(IEnumerable<string> files, string outputFile)
        {
            var queue = new ConcurrentQueue<string>(files);
            var document = new Document();
            var margin = 20;
            try
            {
                var writer = PdfWriter.GetInstance(document, new FileStream(outputFile, FileMode.Create));
                var size = PageSize.A4.Rotate();
                document.Open();
                document.SetPageSize(size);
                PdfContentByte cb = writer.DirectContent;

                do
                {
                    document.NewPage();
                    for (int i = 0; i < 4; i++)
                    {
                        if (TryAppendPage(i) == false)
                            break;
                    }
                } while (queue.Count > 0);

                bool TryAppendPage(int type)
                {
                    if (queue.TryDequeue(out var p) == false)
                        return false;

                    var reader = new PdfReader(p);
                    var page = writer.GetImportedPage(reader, 1);

                    AffineTransform af = new AffineTransform();

                    var scaleHeight = (size.Height - margin * 4) / 2 / page.Height;
                    var scaleWidth = (size.Width - margin * 4) / 2 / page.Width;
                    var scale = Math.Min(scaleHeight, scaleWidth);

                    var height = ((size.Height - margin * 4) / 2 - scale * page.Height) / 2;
                    var width = ((size.Width - margin * 4) / 2 - scale * page.Width) / 2;

                    switch (type)
                    {
                        case 2:
                        default:
                            af.Translate(margin + width, margin + height);
                            break;
                        case 3:
                            af.Translate(margin + width + size.Width / 2, margin + height);
                            break;
                        case 0:
                            af.Translate(margin + width, margin + height + size.Height / 2);
                            break;
                        case 1:
                            af.Translate(margin + width + size.Width / 2, margin + height + size.Height / 2);
                            break;
                    }
                    af.Scale(scale, scale);

                    cb.AddTemplate(page, af);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                document.Close();
            }
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/hetaoos/PdfInvoiceMerge");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAbout();
            frm.ShowDialog();
        }
    }
}
