using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ConsensusUI.Classes;
using ConsensusUI.Business;
using System.IO;
using ExcelDataReader;

namespace ConsensusUI.Forms
{
    public partial class CustomerTelAndMailForm : XtraForm
    {
        public CustomerTelAndMailForm()
        {
            InitializeComponent();
        }
        string companyCode = "", companyPeriod = "";
        private async void CompanySettingsGet()
        {
            bool status = await UtilityHelper.IsDataExistsSQLite("SELECT LogoCompanyCode,LogoPeriod FROM CompanySettings LIMIT 1");
            if (!status)
            {
                XtraMessageBox.Show("Şirket Bilgileri Okuma İşlemi Hatalı Şirket Bilgilerinizi Doldurunuz", "Hatalı Bağlantı İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT LogoCompanyCode,LogoPeriod FROM CompanySettings LIMIT 1");
            DataTable sql = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            companyCode = dt.Rows[0][0].ToString();
            companyPeriod = dt.Rows[0][1].ToString();
            string query = $@"SELECT LOGICALREF,CODE 'Cari Kodu',DEFINITION_ 'Cari Açıklaması',TELNRS1 'Telefon',EMAILADDR 'Mail' FROM LG_{companyCode}_CLCARD WITH (NOLOCK) ORDER BY 2";
            try
            {
                gridControl1.DataSource = await SQLCrud.LoadDataIntoGridViewAsync(query, sql.Rows[0]["SQLConnectString"].ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı SQL Veritabanı Okuma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextLog.TextLogging(ex.Message + " -- " + ex.ToString(),"1");
                this.Close();
            }

        }
        private void dışarıAktarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                saveDialog.FileName = "MüşterilerTelefonMail.xlsx";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(saveDialog.FileName);
                    XtraMessageBox.Show("Excel dosyası başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        private void LoadExcelToGrid(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    DataTable dataTable = result.Tables[0];
                    gridControl1.DataSource = dataTable;
                }
            }
        }
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel Files|*.xls;*.xlsx";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        LoadExcelToGrid(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Excel Seçimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private async void btn_Logo_Click(object sender, EventArgs e)
        {
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            bool status = false;
            bool GeneralStatus = true;
            Random rd = new Random();

            bool va = await SQLCrud.InserUpdateDelete($@"
    SELECT LOGICALREF, EMAILADDR, TELNRS1 
    INTO YEDEK_LG_{companyCode}_CLCARD_{DateTime.Now.ToString("ddMMyyyy")}_{rd.Next(1000, 9999)} 
    FROM LG_{companyCode}_CLCARD WITH (NOLOCK);",
        dt.Rows[0][0].ToString());
            if (!va)
            {
                XtraMessageBox.Show($"LG_{companyCode}_CLCARD Tablosu Yedek Alınamadı", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var logicalRef = gridView1.GetListSourceRowCellValue(i, "LOGICALREF")?.ToString();
                var customerName = gridView1.GetRowCellValue(i, "Cari Açıklaması")?.ToString();
                var customerCode = gridView1.GetRowCellValue(i, "Cari Kodu")?.ToString();
                var telefon = gridView1.GetRowCellValue(i, "Telefon")?.ToString();
                var mail = gridView1.GetRowCellValue(i, "Mail")?.ToString();
                if (!(CustomerLogic.IsValidMailAdres(mail) && CustomerLogic.IsValidPhoneNumber(telefon)))
                {
                    GeneralStatus = false;
                    break;
                }
                status = await SQLCrud.InserUpdateDelete($"UPDATE LG_{companyCode}_CLCARD SET TELNRS1='{telefon}', EMAILADDR='{mail}' WHERE LOGICALREF='{logicalRef}' AND CODE='" + customerCode + "' ", dt.Rows[0][0].ToString());
                if (!status)
                {
                    GeneralStatus = false;
                    XtraMessageBox.Show($"Satır {i + 1} güncellenemedi. Müşteri Kodu {customerCode}  Müşteri Adı: {customerName}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            if (GeneralStatus)
                XtraMessageBox.Show("Aktarım İşlemi Tamamlandı", "Başarılı Logoya Aktarım", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CustomerTelAndMailForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
        private void CustomerTelAndMailForm_Load(object sender, EventArgs e)
        {
            CompanySettingsGet();
            UtilityHelper.CustomizeGridView(gridView1);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.ReadOnly = true;
        }
    }
}