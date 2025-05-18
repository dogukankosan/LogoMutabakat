using System;
using System.Windows.Forms;

namespace ConsensusUI.Forms
{
    public partial class HomeForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public HomeForm()
        {
            InitializeComponent();
            Instance = this;
        }
        public string username = "";
        internal static HomeForm Instance;
        internal void OpenFormInContainer(Form form)
        {
            btn_ConsensusChart.Controls.Clear();
            if (form != null)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                btn_ConsensusChart.Controls.Add(form);
                try
                {
                    form.Show();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                var homeImg = new HomeImageControl();
                homeImg.Dock = DockStyle.Fill;
                btn_ConsensusChart.Controls.Add(homeImg);
            }
        }
        private void btn_Whatsapp_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new WhatsappSettingsForm());
        }
        private void btn_Mail_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new EMailSettingsForm());
        }
        private void btn_SQLConnect_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new SQLConnectionForm());
        }
        private void btn_ErrorMail_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new ErrorMailForm());
        }
        private void btn_SQLite_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new SQLiteCommandForm());
       }
        private void btn_WpAndMailCount_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new MailAndWpCountForm());
        }
        private void btn_WebService_Click(object sender, EventArgs e)
        {

            OpenFormInContainer(new WebServiceSettingsForm());
        }
        private void btn_ErrorLog_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new SoftwareLogForm());
        }
        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Default_StyleChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ThemaName = DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSkinName;
            Properties.Settings.Default.Save();
        }
        private void HomeForm_Load(object sender, EventArgs e)
        {
            if (username != "admin")
            {
                accordionControlElement1.Visible = false;
            }
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            string savedTheme = Properties.Settings.Default.ThemaName;
            if (!string.IsNullOrEmpty(savedTheme))
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(savedTheme);
            }
            DevExpress.LookAndFeel.UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            var homeImg = new HomeImageControl();
            homeImg.Dock = DockStyle.Fill;
            btn_ConsensusChart.Controls.Add(homeImg);
        }
        private void btn_Thema_Click(object sender, EventArgs e)
        {
            popupMenu2.ShowPopup(Cursor.Position);
        }
        private void btn_User_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new UserSettingsForm());
        }
        private void btn_Consensus_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new ConsensusForm());
        }
        private void btn_PhoneMailUpdate_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new CustomerTelAndMailForm());
        }
        private void btn_PDFSettings_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new PDFSettingsForm());
        }
        private void btn_ConsensusAllList_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new ResponseNullConsensusForm());
        }
        private void btn_ErrorCons_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new CancelConsensusListForm());
        }
        private void btn_ApproveCons_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new ApproveConsensusListForm());
        }
        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
           Instance.OpenFormInContainer(null);
        }
        private void btn_UserCompanySettings_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new CompanyForm(username));
        }
        private void btn_adminCompanySettings_Click(object sender, EventArgs e)
        {
             OpenFormInContainer(new CompanyForm(username));
        }
    }
}
