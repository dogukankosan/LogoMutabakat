namespace ConsensusUI.Forms
{
    partial class CustomerTelAndMailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerTelAndMailForm));
            this.btn_Logo = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Excel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dışarıAktarExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Logo
            // 
            this.btn_Logo.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Logo.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btn_Logo.Appearance.Options.UseBackColor = true;
            this.btn_Logo.Appearance.Options.UseFont = true;
            this.btn_Logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Logo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Logo.ImageOptions.SvgImage")));
            this.btn_Logo.Location = new System.Drawing.Point(574, 74);
            this.btn_Logo.Name = "btn_Logo";
            this.btn_Logo.Size = new System.Drawing.Size(168, 44);
            this.btn_Logo.TabIndex = 1;
            this.btn_Logo.Text = "Logoya Aktar";
            this.btn_Logo.Click += new System.EventHandler(this.btn_Logo_Click);
            // 
            // btn_Excel
            // 
            this.btn_Excel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btn_Excel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btn_Excel.Appearance.Options.UseBackColor = true;
            this.btn_Excel.Appearance.Options.UseFont = true;
            this.btn_Excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Excel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Excel.ImageOptions.SvgImage")));
            this.btn_Excel.Location = new System.Drawing.Point(574, 12);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(168, 44);
            this.btn_Excel.TabIndex = 0;
            this.btn_Excel.Text = "Excelden Aktar";
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(531, 471);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dışarıAktarExcelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 26);
            // 
            // dışarıAktarExcelToolStripMenuItem
            // 
            this.dışarıAktarExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dışarıAktarExcelToolStripMenuItem.Image")));
            this.dışarıAktarExcelToolStripMenuItem.Name = "dışarıAktarExcelToolStripMenuItem";
            this.dışarıAktarExcelToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.dışarıAktarExcelToolStripMenuItem.Text = "Dışarı Aktar Excel";
            this.dışarıAktarExcelToolStripMenuItem.Click += new System.EventHandler(this.dışarıAktarExcelToolStripMenuItem_Click);
            // 
            // CustomerTelAndMailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 471);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btn_Logo);
            this.Controls.Add(this.btn_Excel);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("CustomerTelAndMailForm.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "CustomerTelAndMailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Telefon Güncelle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerTelAndMailForm_FormClosed);
            this.Load += new System.EventHandler(this.CustomerTelAndMailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_Logo;
        private DevExpress.XtraEditors.SimpleButton btn_Excel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dışarıAktarExcelToolStripMenuItem;
    }
}