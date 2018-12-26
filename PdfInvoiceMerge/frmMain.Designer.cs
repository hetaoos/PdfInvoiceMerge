namespace PdfInvoiceMerge
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.cmbMergeType = new System.Windows.Forms.ToolStripComboBox();
            this.btnMerge = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.listInvoices = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnClear,
            this.cmbMergeType,
            this.btnMerge});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(758, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 22);
            this.btnAdd.Text = "添加发票(&A)";
            this.btnAdd.ToolTipText = "添加发票，支持拖拽添加发票文件";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(52, 22);
            this.btnClear.Text = "清空(&C)";
            this.btnClear.ToolTipText = "清空发票列表，也可以选中后按 DELETE 键删除。";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbMergeType
            // 
            this.cmbMergeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMergeType.Items.AddRange(new object[] {
            "每页一张发票",
            "每页两张发票",
            "每页四张发票"});
            this.cmbMergeType.Name = "cmbMergeType";
            this.cmbMergeType.Size = new System.Drawing.Size(121, 25);
            this.cmbMergeType.ToolTipText = "输出样式";
            // 
            // btnMerge
            // 
            this.btnMerge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMerge.Image = ((System.Drawing.Image)(resources.GetObject("btnMerge.Image")));
            this.btnMerge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(56, 22);
            this.btnMerge.Text = "合并(&M)";
            this.btnMerge.ToolTipText = "将发票合并后输出。";
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(758, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.fileToolStripMenuItem.Text = "文件(&F)";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "退出(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.helpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.sourceToolStripMenuItem.Text = "源码(&S)";
            this.sourceToolStripMenuItem.Click += new System.EventHandler(this.sourceToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "关于(&A)";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 373);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labInfo
            // 
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(35, 17);
            this.labInfo.Text = "就绪.";
            // 
            // listInvoices
            // 
            this.listInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listInvoices.FormattingEnabled = true;
            this.listInvoices.ItemHeight = 21;
            this.listInvoices.Location = new System.Drawing.Point(0, 50);
            this.listInvoices.Name = "listInvoices";
            this.listInvoices.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listInvoices.Size = new System.Drawing.Size(758, 323);
            this.listInvoices.Sorted = true;
            this.listInvoices.TabIndex = 4;
            this.listInvoices.DoubleClick += new System.EventHandler(this.listInvoices_DoubleClick);
            this.listInvoices.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listInvoices_KeyUp);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PDF 文件|*.pdf";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PDF 发票文件|*.pdf";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "PDF 发票";
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 395);
            this.Controls.Add(this.listInvoices);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF 发票合并工具";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labInfo;
        private System.Windows.Forms.ListBox listInvoices;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnMerge;
        private System.Windows.Forms.ToolStripComboBox cmbMergeType;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

