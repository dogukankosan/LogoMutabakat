using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ConsensusUI.Classes;
using ConsensusUI.Business;
using System.Drawing.Imaging;

namespace ConsensusUI.Forms
{
    public partial class PDFSettingsForm : XtraForm
    {
        public PDFSettingsForm()
        {
            InitializeComponent();
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (PDFLogic.PDFControl(txt_Company
                , txt_Adres,msk_VKN,msk_Phone,txt_Mail, pictureEdit1))
            {
                string base64String =UtilityHelper.ImageToBase64(pictureEdit1.Image, ImageFormat.Png);
                var status = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE CompanyPDF SET CompanyName = '" + txt_Company.Text.Trim() + "',  CompanyAdress='" + txt_Adres.Text.Trim() + "', CompanyVKN = '" + msk_VKN.Text.Trim() + "' , CompanyPhone='"+msk_Phone.Text.Trim()+ "' , CompanyMail='"+txt_Mail.Text.Trim()+ "' , CompanyPicture='"+base64String+"' ");
                if (status.Success)
                {
                    XtraMessageBox.Show("PDF Bilgileri Güncelleme İşlemi Başarılı", "SQL Kaydı Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(status.ErrorMessage, "Hatalı SQLite İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Company.Focus();
                    return;
                }
            }
        }
        private async void PDFSettingsForm_Load(object sender, EventArgs e)
        {
            bool status = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM CompanyPDF LIMIT 1");
            if (status)
            {
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM CompanyPDF LIMIT 1");
                txt_Company.Text = dt.Rows[0]["CompanyName"].ToString();
                txt_Adres.Text = dt.Rows[0]["CompanyAdress"].ToString();
                msk_VKN.Text = dt.Rows[0]["CompanyVKN"].ToString();
                msk_Phone.Text = dt.Rows[0]["CompanyPhone"].ToString();
                txt_Mail.Text = dt.Rows[0]["CompanyMail"].ToString();
                string base64String = dt.Rows[0]["CompanyPicture"].ToString();
                if (!string.IsNullOrEmpty(base64String))
                    pictureEdit1.Image = UtilityHelper.Base64ToImage(base64String);
            }
            txt_Company.Focus();
        }
        private void PDFSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
    }
}