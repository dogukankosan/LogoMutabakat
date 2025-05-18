namespace ConsensusUI.Forms
{
    partial class ConsensusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsensusForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wpSendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.memoExEdit1 = new DevExpress.XtraEditors.MemoExEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btn_LogClear = new DevExpress.XtraEditors.SimpleButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoExEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 108);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(855, 408);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wpSendToolStripMenuItem,
            this.sendMailToolStripMenuItem,
            this.testPDFToolStripMenuItem,
            this.removeFilterToolStripMenuItem,
            this.allCheckToolStripMenuItem,
            this.allRemoveToolStripMenuItem,
            this.sendCheckToolStripMenuItem,
            this.emptCheckToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(284, 212);
            // 
            // wpSendToolStripMenuItem
            // 
            this.wpSendToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("wpSendToolStripMenuItem.Image")));
            this.wpSendToolStripMenuItem.Name = "wpSendToolStripMenuItem";
            this.wpSendToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.wpSendToolStripMenuItem.Text = "Seçilen Tüm Carilere Whatsapp Gönder";
            this.wpSendToolStripMenuItem.Click += new System.EventHandler(this.wpSendToolStripMenuItem_Click);
            // 
            // sendMailToolStripMenuItem
            // 
            this.sendMailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendMailToolStripMenuItem.Image")));
            this.sendMailToolStripMenuItem.Name = "sendMailToolStripMenuItem";
            this.sendMailToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.sendMailToolStripMenuItem.Text = "Seçilen Tüm Carilere Mail Gönder";
            this.sendMailToolStripMenuItem.Click += new System.EventHandler(this.sendMailToolStripMenuItem_Click);
            // 
            // testPDFToolStripMenuItem
            // 
            this.testPDFToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("testPDFToolStripMenuItem.Image")));
            this.testPDFToolStripMenuItem.Name = "testPDFToolStripMenuItem";
            this.testPDFToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.testPDFToolStripMenuItem.Text = "Örnek Mutabakat";
            this.testPDFToolStripMenuItem.Click += new System.EventHandler(this.testPDFToolStripMenuItem_Click);
            // 
            // removeFilterToolStripMenuItem
            // 
            this.removeFilterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeFilterToolStripMenuItem.Image")));
            this.removeFilterToolStripMenuItem.Name = "removeFilterToolStripMenuItem";
            this.removeFilterToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.removeFilterToolStripMenuItem.Text = "Filtreyi Kaldır";
            this.removeFilterToolStripMenuItem.Click += new System.EventHandler(this.removeFilterToolStripMenuItem_Click);
            // 
            // allCheckToolStripMenuItem
            // 
            this.allCheckToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("allCheckToolStripMenuItem.Image")));
            this.allCheckToolStripMenuItem.Name = "allCheckToolStripMenuItem";
            this.allCheckToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.allCheckToolStripMenuItem.Text = "Tümünü Seç";
            this.allCheckToolStripMenuItem.Click += new System.EventHandler(this.allCheckToolStripMenuItem_Click);
            // 
            // allRemoveToolStripMenuItem
            // 
            this.allRemoveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("allRemoveToolStripMenuItem.Image")));
            this.allRemoveToolStripMenuItem.Name = "allRemoveToolStripMenuItem";
            this.allRemoveToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.allRemoveToolStripMenuItem.Text = "Tümünü Kaldır";
            this.allRemoveToolStripMenuItem.Click += new System.EventHandler(this.allRemoveToolStripMenuItem_Click);
            // 
            // sendCheckToolStripMenuItem
            // 
            this.sendCheckToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendCheckToolStripMenuItem.Image")));
            this.sendCheckToolStripMenuItem.Name = "sendCheckToolStripMenuItem";
            this.sendCheckToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.sendCheckToolStripMenuItem.Text = "Gönderilenleri Seç";
            this.sendCheckToolStripMenuItem.Click += new System.EventHandler(this.sendCheckToolStripMenuItem_Click);
            // 
            // emptCheckToolStripMenuItem
            // 
            this.emptCheckToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("emptCheckToolStripMenuItem.Image")));
            this.emptCheckToolStripMenuItem.Name = "emptCheckToolStripMenuItem";
            this.emptCheckToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.emptCheckToolStripMenuItem.Text = "Gönderilmeyenleri Seç";
            this.emptCheckToolStripMenuItem.Click += new System.EventHandler(this.emptCheckToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.dateTimePicker1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(347, 90);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Filtre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bakiye Tarihi:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(82, 41);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 21);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // memoExEdit1
            // 
            this.memoExEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoExEdit1.Location = new System.Drawing.Point(2, 33);
            this.memoExEdit1.Name = "memoExEdit1";
            this.memoExEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.memoExEdit1.Properties.ReadOnly = true;
            this.memoExEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.memoExEdit1.Size = new System.Drawing.Size(142, 20);
            this.memoExEdit1.TabIndex = 8;
            // 
            // groupControl2
            // 
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.btn_LogClear);
            this.groupControl2.Controls.Add(this.memoExEdit1);
            this.groupControl2.Location = new System.Drawing.Point(378, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(146, 63);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "Hata Log";
            // 
            // btn_LogClear
            // 
            this.btn_LogClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LogClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_LogClear.ImageOptions.Image")));
            this.btn_LogClear.Location = new System.Drawing.Point(107, 3);
            this.btn_LogClear.Name = "btn_LogClear";
            this.btn_LogClear.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_LogClear.Size = new System.Drawing.Size(39, 27);
            this.btn_LogClear.TabIndex = 11;
            this.btn_LogClear.Click += new System.EventHandler(this.btn_LogClear_Click);
            this.btn_LogClear.MouseHover += new System.EventHandler(this.btn_LogClear_MouseHover);
            // 
            // ConsensusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 516);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("ConsensusForm.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "ConsensusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mutabakat Listesi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConsensusForm_FormClosed);
            this.Load += new System.EventHandler(this.ConsensusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoExEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wpSendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testPDFToolStripMenuItem;
        private DevExpress.XtraEditors.MemoExEdit memoExEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.ToolStripMenuItem removeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allRemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emptCheckToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraEditors.SimpleButton btn_LogClear;
    }
}