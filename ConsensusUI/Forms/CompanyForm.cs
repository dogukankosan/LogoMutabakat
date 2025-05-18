using System;
using System.Data;
using DevExpress.XtraEditors;
using ConsensusUI.Classes;
using ConsensusUI.Business;
using System.Windows.Forms;

namespace ConsensusUI.Forms
{
    public partial class CompanyForm : XtraForm
    {
        private string IsAdmin = "";
        public CompanyForm(string username)
        {
            IsAdmin=username;
            InitializeComponent();
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (CompanySettingLogic.CompanyControl(txt_CompanyNumber
                , txt_CompanyPeriod,txt_CompanyName))
            {
                DataTable sqlConenction = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
                DataTable sqlData = await SQLCrud.LoadDataIntoGridViewAsync($"SELECT TOP 1 LOGICALREF FROM LG_{txt_CompanyNumber.Text.Trim()}_{txt_CompanyPeriod.Text.Trim()}_CLFICHE WITH (NOLOCK)", sqlConenction.Rows[0]["SQLConnectString"].ToString());
                if (sqlData is null || sqlData.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("Girilen Şirket Kodu Ve Şirket Dönemi Logoda Bulunamadı", "SQL Kaydı Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_CompanyNumber.Focus();
                    return;
                }
                int Ismonth = chk_IsMont.Checked ? 1 : 0;
                int IsTL = chk_ISTL.Checked ? 1 : 0;
                var status = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE CompanySettings SET ISTL="+ IsTL + " ,IsConMonth="+ Ismonth + ", CompanyName='" + txt_CompanyName.Text.Trim()+"' , LogoPeriod = '" + txt_CompanyPeriod.Text.Trim() + "',  LogoCompanyCode = '" + txt_CompanyNumber.Text.Trim() + "'");
                if (status.Success)
                {
                    XtraMessageBox.Show("Şirket Bilgileri Güncelleme İşlemi Başarılı", "SQL Kaydı Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(status.ErrorMessage, "Hatalı SQLite İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_CompanyNumber.Focus();
                    return;
                }
            }
        }
        private async void CompanyForm_Load(object sender, EventArgs e)
        {
            
            bool sqlStatus = await UtilityHelper.IsDataExistsSQLite("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            if (!sqlStatus)
            {
                XtraMessageBox.Show("SQL Bağlantı Ayalarını Tamamlayınız", "Hatalı SQL Bağlantı Ayarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            bool status = await UtilityHelper.IsDataExistsSQLite("SELECT LogoCompanyCode,LogoPeriod,CompanyName FROM CompanySettings LIMIT 1");
            if (status)
            {
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT LogoCompanyCode,LogoPeriod,CompanyName,IsConMonth,ISTL FROM CompanySettings LIMIT 1");
                txt_CompanyNumber.Text = dt.Rows[0][0].ToString();
                txt_CompanyPeriod.Text = dt.Rows[0][1].ToString();
                txt_CompanyName.Text = dt.Rows[0][2].ToString();
                int statusIsMonth = int.Parse(dt.Rows[0][3].ToString());
                int statusIsTL = int.Parse(dt.Rows[0][4].ToString());
                chk_IsMont.Checked = statusIsMonth == 1;
                chk_ISTL.Checked = statusIsTL == 1;
            }
            if (IsAdmin != "admin")
            {
                txt_CompanyNumber.Enabled = false;
                txt_CompanyPeriod.Enabled = false;
            }
            txt_CompanyNumber.Focus();
        }
        private void txt_CompanyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void txt_CompanyPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void txt_CompanyNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }
        private void CompanyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
    }
}