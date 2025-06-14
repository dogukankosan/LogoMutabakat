﻿namespace ConsensusUI.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pcb_Wp = new System.Windows.Forms.PictureBox();
            this.pcb_Instagram = new System.Windows.Forms.PictureBox();
            this.pcb_WebSite = new System.Windows.Forms.PictureBox();
            this.pcb_Linkedin = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Password = new DevExpress.XtraEditors.TextEdit();
            this.txt_UserName = new DevExpress.XtraEditors.TextEdit();
            this.btn_Eyes = new DevExpress.XtraEditors.SimpleButton();
            this.btn_NotEye = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Login = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Wp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Instagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_WebSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Linkedin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pcb_Wp);
            this.panelControl1.Controls.Add(this.pcb_Instagram);
            this.panelControl1.Controls.Add(this.pcb_WebSite);
            this.panelControl1.Controls.Add(this.pcb_Linkedin);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 180);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(433, 57);
            this.panelControl1.TabIndex = 20;
            // 
            // pcb_Wp
            // 
            this.pcb_Wp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcb_Wp.Image = ((System.Drawing.Image)(resources.GetObject("pcb_Wp.Image")));
            this.pcb_Wp.Location = new System.Drawing.Point(166, 4);
            this.pcb_Wp.Name = "pcb_Wp";
            this.pcb_Wp.Size = new System.Drawing.Size(64, 48);
            this.pcb_Wp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_Wp.TabIndex = 7;
            this.pcb_Wp.TabStop = false;
            this.pcb_Wp.Click += new System.EventHandler(this.pcb_Wp_Click);
            // 
            // pcb_Instagram
            // 
            this.pcb_Instagram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcb_Instagram.Image = ((System.Drawing.Image)(resources.GetObject("pcb_Instagram.Image")));
            this.pcb_Instagram.Location = new System.Drawing.Point(95, 4);
            this.pcb_Instagram.Name = "pcb_Instagram";
            this.pcb_Instagram.Size = new System.Drawing.Size(65, 48);
            this.pcb_Instagram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_Instagram.TabIndex = 6;
            this.pcb_Instagram.TabStop = false;
            this.pcb_Instagram.Click += new System.EventHandler(this.pcb_Instagram_Click);
            // 
            // pcb_WebSite
            // 
            this.pcb_WebSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcb_WebSite.Image = ((System.Drawing.Image)(resources.GetObject("pcb_WebSite.Image")));
            this.pcb_WebSite.Location = new System.Drawing.Point(236, 4);
            this.pcb_WebSite.Name = "pcb_WebSite";
            this.pcb_WebSite.Size = new System.Drawing.Size(73, 48);
            this.pcb_WebSite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_WebSite.TabIndex = 5;
            this.pcb_WebSite.TabStop = false;
            this.pcb_WebSite.Click += new System.EventHandler(this.pcb_WebSite_Click);
            // 
            // pcb_Linkedin
            // 
            this.pcb_Linkedin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcb_Linkedin.Image = ((System.Drawing.Image)(resources.GetObject("pcb_Linkedin.Image")));
            this.pcb_Linkedin.Location = new System.Drawing.Point(28, 4);
            this.pcb_Linkedin.Name = "pcb_Linkedin";
            this.pcb_Linkedin.Size = new System.Drawing.Size(61, 48);
            this.pcb_Linkedin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_Linkedin.TabIndex = 4;
            this.pcb_Linkedin.TabStop = false;
            this.pcb_Linkedin.Click += new System.EventHandler(this.pcb_Linkedin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 18;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(124, 38);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_Password.Properties.Appearance.Options.UseFont = true;
            this.txt_Password.Properties.MaxLength = 50;
            this.txt_Password.Properties.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(195, 24);
            this.txt_Password.TabIndex = 1;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(124, 7);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_UserName.Properties.Appearance.Options.UseFont = true;
            this.txt_UserName.Properties.MaxLength = 50;
            this.txt_UserName.Size = new System.Drawing.Size(195, 24);
            this.txt_UserName.TabIndex = 0;
            // 
            // btn_Eyes
            // 
            this.btn_Eyes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Eyes.ImageOptions.Image")));
            this.btn_Eyes.Location = new System.Drawing.Point(80, 36);
            this.btn_Eyes.Name = "btn_Eyes";
            this.btn_Eyes.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Eyes.Size = new System.Drawing.Size(38, 29);
            this.btn_Eyes.TabIndex = 2;
            this.btn_Eyes.Click += new System.EventHandler(this.btn_Eyes_Click);
            // 
            // btn_NotEye
            // 
            this.btn_NotEye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NotEye.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_NotEye.ImageOptions.Image")));
            this.btn_NotEye.Location = new System.Drawing.Point(80, 36);
            this.btn_NotEye.Name = "btn_NotEye";
            this.btn_NotEye.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_NotEye.Size = new System.Drawing.Size(38, 30);
            this.btn_NotEye.TabIndex = 3;
            this.btn_NotEye.Click += new System.EventHandler(this.btn_NotEye_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Login.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.btn_Login.Appearance.Options.UseBackColor = true;
            this.btn_Login.Appearance.Options.UseFont = true;
            this.btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Login.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Login.ImageOptions.Image")));
            this.btn_Login.Location = new System.Drawing.Point(124, 81);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(195, 44);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Giriş Yap";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Şifre:";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 237);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.btn_Eyes);
            this.Controls.Add(this.btn_NotEye);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.label2);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("LoginForm.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nokta Bilgi İşlem Mutabakat Programı V1.0.0";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Wp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Instagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_WebSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Linkedin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox pcb_Wp;
        private System.Windows.Forms.PictureBox pcb_Instagram;
        private System.Windows.Forms.PictureBox pcb_WebSite;
        private System.Windows.Forms.PictureBox pcb_Linkedin;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt_Password;
        private DevExpress.XtraEditors.TextEdit txt_UserName;
        private DevExpress.XtraEditors.SimpleButton btn_Eyes;
        private DevExpress.XtraEditors.SimpleButton btn_NotEye;
        private DevExpress.XtraEditors.SimpleButton btn_Login;
        private System.Windows.Forms.Label label2;
    }
}