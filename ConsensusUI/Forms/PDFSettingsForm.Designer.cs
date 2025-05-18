namespace ConsensusUI.Forms
{
    partial class PDFSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFSettingsForm));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.msk_VKN = new System.Windows.Forms.MaskedTextBox();
            this.msk_Phone = new System.Windows.Forms.MaskedTextBox();
            this.txt_Mail = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Adres = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Company = new DevExpress.XtraEditors.TextEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Adres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Company.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.msk_VKN);
            this.groupControl1.Controls.Add(this.msk_Phone);
            this.groupControl1.Controls.Add(this.txt_Mail);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txt_Adres);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.pictureEdit1);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txt_Company);
            this.groupControl1.Controls.Add(this.btn_Save);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(426, 410);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Şirket Ayarı";
            // 
            // msk_VKN
            // 
            this.msk_VKN.Location = new System.Drawing.Point(167, 111);
            this.msk_VKN.Mask = "0000000000";
            this.msk_VKN.Name = "msk_VKN";
            this.msk_VKN.Size = new System.Drawing.Size(195, 21);
            this.msk_VKN.TabIndex = 2;
            // 
            // msk_Phone
            // 
            this.msk_Phone.Location = new System.Drawing.Point(167, 145);
            this.msk_Phone.Mask = "+900000000000";
            this.msk_Phone.Name = "msk_Phone";
            this.msk_Phone.Size = new System.Drawing.Size(195, 21);
            this.msk_Phone.TabIndex = 3;
            // 
            // txt_Mail
            // 
            this.txt_Mail.Location = new System.Drawing.Point(167, 173);
            this.txt_Mail.Name = "txt_Mail";
            this.txt_Mail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_Mail.Properties.Appearance.Options.UseFont = true;
            this.txt_Mail.Properties.MaxLength = 50;
            this.txt_Mail.Size = new System.Drawing.Size(195, 24);
            this.txt_Mail.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label6.Location = new System.Drawing.Point(8, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 46;
            this.label6.Text = "Şirket Mail:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label5.Location = new System.Drawing.Point(8, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 21);
            this.label5.TabIndex = 45;
            this.label5.Text = "Şirket Telefon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label4.Location = new System.Drawing.Point(8, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 43;
            this.label4.Text = "Şirket VKN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label3.Location = new System.Drawing.Point(8, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 42;
            this.label3.Text = "Şirket Adres:";
            // 
            // txt_Adres
            // 
            this.txt_Adres.Location = new System.Drawing.Point(167, 77);
            this.txt_Adres.Name = "txt_Adres";
            this.txt_Adres.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_Adres.Properties.Appearance.Options.UseFont = true;
            this.txt_Adres.Properties.MaxLength = 250;
            this.txt_Adres.Size = new System.Drawing.Size(195, 24);
            this.txt_Adres.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label2.Location = new System.Drawing.Point(8, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 40;
            this.label2.Text = "Şirket Resim:";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureEdit1.Location = new System.Drawing.Point(167, 214);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(195, 106);
            this.pictureEdit1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label1.Location = new System.Drawing.Point(8, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 38;
            this.label1.Text = "Şirket Adı:";
            // 
            // txt_Company
            // 
            this.txt_Company.Location = new System.Drawing.Point(167, 44);
            this.txt_Company.Name = "txt_Company";
            this.txt_Company.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_Company.Properties.Appearance.Options.UseFont = true;
            this.txt_Company.Properties.MaxLength = 250;
            this.txt_Company.Size = new System.Drawing.Size(195, 24);
            this.txt_Company.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.btn_Save.Appearance.Options.UseBackColor = true;
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(167, 344);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(195, 42);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Kaydet";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // PDFSettingsForm
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 452);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("PDFSettingsForm.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "PDFSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDFS Ayarları";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PDFSettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.PDFSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Adres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Company.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt_Company;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private System.Windows.Forms.MaskedTextBox msk_Phone;
        private DevExpress.XtraEditors.TextEdit txt_Mail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txt_Adres;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.MaskedTextBox msk_VKN;
    }
}