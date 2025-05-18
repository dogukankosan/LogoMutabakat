namespace ConsensusUI.Forms
{
    partial class ApproveConsensusListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApproveConsensusListForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allselectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allUnSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtreKaldırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkReadToolStripMenuItem,
            this.excelToolStripMenuItem,
            this.pDFToolStripMenuItem,
            this.unreadToolStripMenuItem,
            this.allselectToolStripMenuItem,
            this.allUnSelectToolStripMenuItem,
            this.filtreKaldırToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(256, 186);
            // 
            // checkReadToolStripMenuItem
            // 
            this.checkReadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkReadToolStripMenuItem.Image")));
            this.checkReadToolStripMenuItem.Name = "checkReadToolStripMenuItem";
            this.checkReadToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.checkReadToolStripMenuItem.Text = "Seçili Satırları Okundu Yap";
            this.checkReadToolStripMenuItem.Click += new System.EventHandler(this.checkReadToolStripMenuItem_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("excelToolStripMenuItem.Image")));
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.excelToolStripMenuItem.Text = "Excel Aktar";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pDFToolStripMenuItem.Image")));
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.pDFToolStripMenuItem.Text = "PDF Aç";
            this.pDFToolStripMenuItem.Click += new System.EventHandler(this.pDFToolStripMenuItem_Click);
            // 
            // unreadToolStripMenuItem
            // 
            this.unreadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("unreadToolStripMenuItem.Image")));
            this.unreadToolStripMenuItem.Name = "unreadToolStripMenuItem";
            this.unreadToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.unreadToolStripMenuItem.Text = "Görülmeyenleri Seç";
            this.unreadToolStripMenuItem.Click += new System.EventHandler(this.unreadToolStripMenuItem_Click);
            // 
            // allselectToolStripMenuItem
            // 
            this.allselectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("allselectToolStripMenuItem.Image")));
            this.allselectToolStripMenuItem.Name = "allselectToolStripMenuItem";
            this.allselectToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.allselectToolStripMenuItem.Text = "Tümünü Seç";
            this.allselectToolStripMenuItem.Click += new System.EventHandler(this.allselectToolStripMenuItem_Click);
            // 
            // allUnSelectToolStripMenuItem
            // 
            this.allUnSelectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("allUnSelectToolStripMenuItem.Image")));
            this.allUnSelectToolStripMenuItem.Name = "allUnSelectToolStripMenuItem";
            this.allUnSelectToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.allUnSelectToolStripMenuItem.Text = "Tümünü Kaldır";
            this.allUnSelectToolStripMenuItem.Click += new System.EventHandler(this.allUnSelectToolStripMenuItem_Click);
            // 
            // filtreKaldırToolStripMenuItem
            // 
            this.filtreKaldırToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filtreKaldırToolStripMenuItem.Image")));
            this.filtreKaldırToolStripMenuItem.Name = "filtreKaldırToolStripMenuItem";
            this.filtreKaldırToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.filtreKaldırToolStripMenuItem.Text = "Filtre Kaldır";
            this.filtreKaldırToolStripMenuItem.Click += new System.EventHandler(this.filtreKaldırToolStripMenuItem_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl1.CaptionImageOptions.SvgImage")));
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(910, 631);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Onaylanan Mutabakatlar";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(2, 41);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(906, 588);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle_1);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor_1);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData_1);
            // 
            // ApproveConsensusListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(910, 631);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("ApproveConsensusListForm.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ApproveConsensusListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Onaylanan Mutabakatlar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApproveConsensusListForm_FormClosed);
            this.Load += new System.EventHandler(this.ApproveConsensusListForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem checkReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unreadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allselectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allUnSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtreKaldırToolStripMenuItem;
    }
}