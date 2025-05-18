namespace ConsensusUI.Forms
{
    partial class CompanyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyForm));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chk_IsMont = new DevExpress.XtraEditors.CheckEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CompanyName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CompanyPeriod = new DevExpress.XtraEditors.TextEdit();
            this.txt_CompanyNumber = new DevExpress.XtraEditors.TextEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.chk_ISTL = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_IsMont.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompanyPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompanyNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ISTL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.chk_ISTL);
            this.groupControl1.Controls.Add(this.chk_IsMont);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txt_CompanyName);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txt_CompanyPeriod);
            this.groupControl1.Controls.Add(this.txt_CompanyNumber);
            this.groupControl1.Controls.Add(this.btn_Save);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(426, 251);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Şirket Ayarı";
            // 
            // chk_IsMont
            // 
            this.chk_IsMont.Location = new System.Drawing.Point(9, 135);
            this.chk_IsMont.Name = "chk_IsMont";
            this.chk_IsMont.Properties.Caption = "Gönderilen Aydaki Cari Tekrardan Gönderilsin Mi ?";
            this.chk_IsMont.Size = new System.Drawing.Size(353, 20);
            this.chk_IsMont.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label3.Location = new System.Drawing.Point(5, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 42;
            this.label3.Text = "Firma Adı:";
            // 
            // txt_CompanyName
            // 
            this.txt_CompanyName.Location = new System.Drawing.Point(167, 105);
            this.txt_CompanyName.Name = "txt_CompanyName";
            this.txt_CompanyName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_CompanyName.Properties.Appearance.Options.UseFont = true;
            this.txt_CompanyName.Properties.MaxLength = 250;
            this.txt_CompanyName.Size = new System.Drawing.Size(195, 24);
            this.txt_CompanyName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label2.Location = new System.Drawing.Point(5, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 39;
            this.label2.Text = "Logo Dönem:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 38;
            this.label1.Text = "Logo Şirket Kodu:";
            // 
            // txt_CompanyPeriod
            // 
            this.txt_CompanyPeriod.Location = new System.Drawing.Point(167, 73);
            this.txt_CompanyPeriod.Name = "txt_CompanyPeriod";
            this.txt_CompanyPeriod.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_CompanyPeriod.Properties.Appearance.Options.UseFont = true;
            this.txt_CompanyPeriod.Properties.MaxLength = 10;
            this.txt_CompanyPeriod.Size = new System.Drawing.Size(195, 24);
            this.txt_CompanyPeriod.TabIndex = 1;
            this.txt_CompanyPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_CompanyPeriod_KeyPress);
            // 
            // txt_CompanyNumber
            // 
            this.txt_CompanyNumber.Location = new System.Drawing.Point(167, 42);
            this.txt_CompanyNumber.Name = "txt_CompanyNumber";
            this.txt_CompanyNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_CompanyNumber.Properties.Appearance.Options.UseFont = true;
            this.txt_CompanyNumber.Properties.MaxLength = 10;
            this.txt_CompanyNumber.Size = new System.Drawing.Size(195, 24);
            this.txt_CompanyNumber.TabIndex = 0;
            this.txt_CompanyNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_CompanyNumber_KeyPress);
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.btn_Save.Appearance.Options.UseBackColor = true;
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(167, 203);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(195, 42);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Kaydet";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // chk_ISTL
            // 
            this.chk_ISTL.Location = new System.Drawing.Point(9, 161);
            this.chk_ISTL.Name = "chk_ISTL";
            this.chk_ISTL.Properties.Caption = "İşlem Dövizide Dahil Edilsin ?";
            this.chk_ISTL.Size = new System.Drawing.Size(353, 20);
            this.chk_ISTL.TabIndex = 4;
            // 
            // CompanyForm
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(701, 460);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("CompanyForm.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "CompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şirket Bilgileri Ayarları";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompanyForm_FormClosed);
            this.Load += new System.EventHandler(this.CompanyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_IsMont.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompanyPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompanyNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ISTL.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt_CompanyPeriod;
        private DevExpress.XtraEditors.TextEdit txt_CompanyNumber;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txt_CompanyName;
        private DevExpress.XtraEditors.CheckEdit chk_IsMont;
        private DevExpress.XtraEditors.CheckEdit chk_ISTL;
    }
}