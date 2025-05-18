namespace ConsensusUI.Forms
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.btn_ConsensusChart = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_Whatsapp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_Mail = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_SQLConnect = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_ErrorMail = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_SQLite = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_WpAndMailCount = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_WebService = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_ErrorLog = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_adminCompanySettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_Thema = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_User = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_PhoneMailUpdate = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_PDFSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_UserCompanySettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_Consensus = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_ApproveCons = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_ErrorCons = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_ConsensusAllList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.skinPaletteDropDownButtonItem1 = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            this.skinBarSubItem1 = new DevExpress.XtraBars.SkinBarSubItem();
            this.skinBarSubItem2 = new DevExpress.XtraBars.SkinBarSubItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ConsensusChart
            // 
            this.btn_ConsensusChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ConsensusChart.Location = new System.Drawing.Point(260, 31);
            this.btn_ConsensusChart.Name = "btn_ConsensusChart";
            this.btn_ConsensusChart.Size = new System.Drawing.Size(819, 520);
            this.btn_ConsensusChart.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement2,
            this.accordionControlElement3});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 520);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btn_Whatsapp,
            this.btn_Mail,
            this.btn_SQLConnect,
            this.btn_ErrorMail,
            this.btn_SQLite,
            this.btn_WpAndMailCount,
            this.btn_WebService,
            this.btn_ErrorLog,
            this.btn_adminCompanySettings});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Admin Ayarları";
            // 
            // btn_Whatsapp
            // 
            this.btn_Whatsapp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Whatsapp.ImageOptions.Image")));
            this.btn_Whatsapp.Name = "btn_Whatsapp";
            this.btn_Whatsapp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_Whatsapp.Text = "Whatsapp Tanımı";
            this.btn_Whatsapp.Click += new System.EventHandler(this.btn_Whatsapp_Click);
            // 
            // btn_Mail
            // 
            this.btn_Mail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Mail.ImageOptions.Image")));
            this.btn_Mail.Name = "btn_Mail";
            this.btn_Mail.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_Mail.Text = "Mail Tanımı";
            this.btn_Mail.Click += new System.EventHandler(this.btn_Mail_Click);
            // 
            // btn_SQLConnect
            // 
            this.btn_SQLConnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SQLConnect.ImageOptions.Image")));
            this.btn_SQLConnect.Name = "btn_SQLConnect";
            this.btn_SQLConnect.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_SQLConnect.Text = "SQL Bağlantı Ayarı";
            this.btn_SQLConnect.Click += new System.EventHandler(this.btn_SQLConnect_Click);
            // 
            // btn_ErrorMail
            // 
            this.btn_ErrorMail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ErrorMail.ImageOptions.Image")));
            this.btn_ErrorMail.Name = "btn_ErrorMail";
            this.btn_ErrorMail.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_ErrorMail.Text = "Mail Hata Tanımı";
            this.btn_ErrorMail.Click += new System.EventHandler(this.btn_ErrorMail_Click);
            // 
            // btn_SQLite
            // 
            this.btn_SQLite.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SQLite.ImageOptions.Image")));
            this.btn_SQLite.Name = "btn_SQLite";
            this.btn_SQLite.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_SQLite.Text = "SQLite Komut Ekranı";
            this.btn_SQLite.Click += new System.EventHandler(this.btn_SQLite_Click);
            // 
            // btn_WpAndMailCount
            // 
            this.btn_WpAndMailCount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_WpAndMailCount.ImageOptions.Image")));
            this.btn_WpAndMailCount.Name = "btn_WpAndMailCount";
            this.btn_WpAndMailCount.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_WpAndMailCount.Text = "Mail Whatsapp Kontör Sayısı";
            this.btn_WpAndMailCount.Click += new System.EventHandler(this.btn_WpAndMailCount_Click);
            // 
            // btn_WebService
            // 
            this.btn_WebService.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_WebService.ImageOptions.Image")));
            this.btn_WebService.Name = "btn_WebService";
            this.btn_WebService.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_WebService.Text = "Web Service Ayarları";
            this.btn_WebService.Click += new System.EventHandler(this.btn_WebService_Click);
            // 
            // btn_ErrorLog
            // 
            this.btn_ErrorLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ErrorLog.ImageOptions.Image")));
            this.btn_ErrorLog.Name = "btn_ErrorLog";
            this.btn_ErrorLog.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_ErrorLog.Text = "Yazılım Hata Log";
            this.btn_ErrorLog.Click += new System.EventHandler(this.btn_ErrorLog_Click);
            // 
            // btn_adminCompanySettings
            // 
            this.btn_adminCompanySettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_adminCompanySettings.ImageOptions.Image")));
            this.btn_adminCompanySettings.Name = "btn_adminCompanySettings";
            this.btn_adminCompanySettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_adminCompanySettings.Text = "Şirket Ayarları";
            this.btn_adminCompanySettings.Click += new System.EventHandler(this.btn_adminCompanySettings_Click);
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btn_Thema,
            this.btn_User,
            this.btn_PhoneMailUpdate,
            this.btn_PDFSettings,
            this.btn_UserCompanySettings});
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "Kullanıcı Ayarları";
            // 
            // btn_Thema
            // 
            this.btn_Thema.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thema.ImageOptions.Image")));
            this.btn_Thema.Name = "btn_Thema";
            this.btn_Thema.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_Thema.Text = "Temalar";
            this.btn_Thema.Click += new System.EventHandler(this.btn_Thema_Click);
            // 
            // btn_User
            // 
            this.btn_User.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_User.ImageOptions.Image")));
            this.btn_User.Name = "btn_User";
            this.btn_User.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_User.Text = "Kullanıcı Girişi";
            this.btn_User.Click += new System.EventHandler(this.btn_User_Click);
            // 
            // btn_PhoneMailUpdate
            // 
            this.btn_PhoneMailUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_PhoneMailUpdate.ImageOptions.Image")));
            this.btn_PhoneMailUpdate.Name = "btn_PhoneMailUpdate";
            this.btn_PhoneMailUpdate.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_PhoneMailUpdate.Text = "Logoya Telefon Mail Aktar";
            this.btn_PhoneMailUpdate.Click += new System.EventHandler(this.btn_PhoneMailUpdate_Click);
            // 
            // btn_PDFSettings
            // 
            this.btn_PDFSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_PDFSettings.ImageOptions.Image")));
            this.btn_PDFSettings.Name = "btn_PDFSettings";
            this.btn_PDFSettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_PDFSettings.Text = "PDF Ayarları";
            this.btn_PDFSettings.Click += new System.EventHandler(this.btn_PDFSettings_Click);
            // 
            // btn_UserCompanySettings
            // 
            this.btn_UserCompanySettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_UserCompanySettings.ImageOptions.Image")));
            this.btn_UserCompanySettings.Name = "btn_UserCompanySettings";
            this.btn_UserCompanySettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_UserCompanySettings.Text = "Şirket Ayarları";
            this.btn_UserCompanySettings.Click += new System.EventHandler(this.btn_UserCompanySettings_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btn_Consensus,
            this.btn_ApproveCons,
            this.btn_ErrorCons,
            this.btn_ConsensusAllList,
            this.accordionControlElement4});
            this.accordionControlElement3.Expanded = true;
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Mutabakat";
            // 
            // btn_Consensus
            // 
            this.btn_Consensus.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Consensus.ImageOptions.Image")));
            this.btn_Consensus.Name = "btn_Consensus";
            this.btn_Consensus.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_Consensus.Text = "Mutabakat Gönder";
            this.btn_Consensus.Click += new System.EventHandler(this.btn_Consensus_Click);
            // 
            // btn_ApproveCons
            // 
            this.btn_ApproveCons.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ApproveCons.ImageOptions.Image")));
            this.btn_ApproveCons.Name = "btn_ApproveCons";
            this.btn_ApproveCons.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_ApproveCons.Text = "Kabul Edilen Mutabakatlar";
            this.btn_ApproveCons.Click += new System.EventHandler(this.btn_ApproveCons_Click);
            // 
            // btn_ErrorCons
            // 
            this.btn_ErrorCons.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ErrorCons.ImageOptions.Image")));
            this.btn_ErrorCons.Name = "btn_ErrorCons";
            this.btn_ErrorCons.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_ErrorCons.Text = "Red Edilen Mutabakatlar";
            this.btn_ErrorCons.Click += new System.EventHandler(this.btn_ErrorCons_Click);
            // 
            // btn_ConsensusAllList
            // 
            this.btn_ConsensusAllList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ConsensusAllList.ImageOptions.Image")));
            this.btn_ConsensusAllList.Name = "btn_ConsensusAllList";
            this.btn_ConsensusAllList.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_ConsensusAllList.Text = "Bekleyen Mutabakatlar";
            this.btn_ConsensusAllList.Click += new System.EventHandler(this.btn_ConsensusAllList_Click);
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement4.ImageOptions.Image")));
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement4.Text = "Mutabakat Rapor";
            this.accordionControlElement4.Click += new System.EventHandler(this.accordionControlElement4_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinPaletteDropDownButtonItem1,
            this.skinBarSubItem1,
            this.skinBarSubItem2});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1079, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // skinPaletteDropDownButtonItem1
            // 
            this.skinPaletteDropDownButtonItem1.Id = 0;
            this.skinPaletteDropDownButtonItem1.Name = "skinPaletteDropDownButtonItem1";
            // 
            // skinBarSubItem1
            // 
            this.skinBarSubItem1.Caption = "Temalaer";
            this.skinBarSubItem1.Id = 1;
            this.skinBarSubItem1.Name = "skinBarSubItem1";
            // 
            // skinBarSubItem2
            // 
            this.skinBarSubItem2.Caption = "Temalar";
            this.skinBarSubItem2.Id = 2;
            this.skinBarSubItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("skinBarSubItem2.ImageOptions.Image")));
            this.skinBarSubItem2.Name = "skinBarSubItem2";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinPaletteDropDownButtonItem1,
            this.skinBarSubItem1,
            this.skinBarSubItem2});
            this.fluentFormDefaultManager1.MaxItemId = 3;
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.skinBarSubItem2)});
            this.popupMenu2.Manager = this.fluentFormDefaultManager1;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1079, 551);
            this.ControlContainer = this.btn_ConsensusChart;
            this.Controls.Add(this.btn_ConsensusChart);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("HomeForm.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logo Mutabakat Anasayfa V1.0.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeForm_FormClosed);
            this.Load += new System.EventHandler(this.HomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer btn_ConsensusChart;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_Whatsapp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_Mail;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_SQLConnect;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_ErrorMail;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_SQLite;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_WpAndMailCount;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_WebService;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_ErrorLog;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_Thema;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem1;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_User;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_Consensus;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_ApproveCons;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_ErrorCons;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_PhoneMailUpdate;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_PDFSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_ConsensusAllList;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_UserCompanySettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_adminCompanySettings;
    }
}