using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ConsensusUI.Classes;
using System.Diagnostics;
using System.IO;

namespace ConsensusUI.Forms
{
    public partial class ResponseNullConsensusForm : XtraForm
    {
        public ResponseNullConsensusForm()
        {
            InitializeComponent();
        }
        private async void List()
        {
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync(@"
    SELECT 
    ID AS 'KayıtNo',
    CustomerID AS 'CariReferansNo',
    CASE SendType
        WHEN 0 THEN 'Mail'
        WHEN 1 THEN 'Whatsapp'
        ELSE 'Bilinmiyor'
    END AS 'GönderimTürü',
    SendDate AS 'GönderimTarihi',
    ConMonth AS 'MutabakatAyı',
    ConYear AS 'MutabakatYılı'
FROM Consensus
    ");
            DataTable companyData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT LogoCompanyCode FROM CompanySettings LIMIT 1");
            DataTable sqlconnection = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            string sqlConnStr = sqlconnection.Rows[0]["SQLConnectString"].ToString();
            string companyCode = companyData.Rows[0]["LogoCompanyCode"].ToString();
            DataTable customerLogicalref = await SQLCrud.LoadDataIntoGridViewAsync(
                $"SELECT LOGICALREF, CODE, DEFINITION_ FROM LG_{companyCode}_CLCARD WITH (NOLOCK)",
                sqlConnStr
            );
            DataTable webData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT CompanyName,WebToken,WebPassword,SQLConnectString FROM WebSettings LIMIT 1");
            DataTable webCustomerID = await SQLCrud.LoadDataIntoGridViewAsync($@"
        SELECT TOP 1 ID 
        FROM CustomersConsensus WITH (NOLOCK)
        WHERE CustomerName = '{webData.Rows[0]["CompanyName"]}'
          AND CustomerToken = '{webData.Rows[0]["WebToken"]}'
          AND CustomerPassword = '{webData.Rows[0]["WebPassword"]}'
    ", webData.Rows[0]["SQLConnectString"].ToString());
            string webCustomerIDValue = webCustomerID.Rows[0]["ID"].ToString();
            DataTable webConses = await SQLCrud.LoadDataIntoGridViewAsync($@"
        SELECT SourceRef, ResponseMessage, ResponseDate ,ResponsePerson,ResponsePhone
        FROM Conseus WITH (NOLOCK)
        WHERE CustomerID = {webCustomerIDValue} AND ResponseMessage IS NULL 
    ", webData.Rows[0]["SQLConnectString"].ToString());
            var result = from consensusRow in dt.AsEnumerable()
                         join cardRow in customerLogicalref.AsEnumerable()
                         on Convert.ToInt32(consensusRow["CariReferansNo"]) equals Convert.ToInt32(cardRow["LOGICALREF"])
                         join webRow in webConses.AsEnumerable()
                         on Convert.ToInt32(consensusRow["KayıtNo"]) equals Convert.ToInt32(webRow["SourceRef"])
                         where string.IsNullOrWhiteSpace(webRow.Field<string>("ResponseMessage"))
                         select new
                         {
                             KayıtNo = consensusRow["KayıtNo"],
                             CariReferansNo = consensusRow["CariReferansNo"],
                             CariKodu = cardRow["CODE"],
                             CariAçıklama = cardRow["DEFINITION_"],
                             GönderimTürü = consensusRow["GönderimTürü"],
                             GönderimTarihi = consensusRow["GönderimTarihi"],
                             MutabakatAyı = consensusRow["MutabakatAyı"],
                             MutabakatYılı = consensusRow["MutabakatYılı"],
                             CevapMesajı = webRow.Field<string>("ResponseMessage"),
                             CevapTarihi = webRow.Field<DateTime?>("ResponseDate"),
                             OnaylayanKişi = webRow.Field<string>("ResponsePerson"),
                             Telefon = webRow.Field<string>("ResponsePhone")
                         };
            gridControl1.DataSource = result.ToList();
            gridView1.Columns["GönderimTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["GönderimTarihi"].DisplayFormat.FormatString = "g";
            gridView1.Columns["CevapTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["CevapTarihi"].DisplayFormat.FormatString = "g";
            UtilityHelper.CustomizeGridView(gridView1);
            gridView1.ClearSorting();
            gridView1.Columns["GönderimTarihi"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.ReadOnly = true;
        }
        private async void ResponseNullConsensusForm_Load(object sender, EventArgs e)
        {
            bool sqlStatus = await UtilityHelper.IsDataExistsSQLite("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            if (!sqlStatus)
            {
                XtraMessageBox.Show("SQL Bağlantı Hatalı Önce SQL Bağlantısı Yapınız", "Hatalı SQL Bağlantısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            bool webStatus = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM WebSettings LIMIT 1");
            if (!webStatus)
            {
                XtraMessageBox.Show("Web Servis Ayarları Hatalı Web Servis Ayarlarınızı Doldurunuz", "Hatalı Web Bağlantısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            bool companyStatus = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM CompanySettings LIMIT 1");
            if (!companyStatus)
            {
                XtraMessageBox.Show("Şirket Bilgileri Ayarlarınız Tamamlayınız", "Hatalı Şirket Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            List();
        }
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Excel'e Aktar";
                    saveDialog.FileName = "BekleyenMutabakatlar.xlsx";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        gridView1.OptionsPrint.PrintDetails = true;
                        gridControl1.ExportToXlsx(saveDialog.FileName);
                        XtraMessageBox.Show("Excel dosyası başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Excel İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private async void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int rowHandle = gridView1.FocusedRowHandle;
                if (rowHandle < 0)
                {
                    XtraMessageBox.Show("Lütfen bir satır seçiniz.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                object kayitNoObj = gridView1.GetRowCellValue(rowHandle, "KayıtNo");
                if (kayitNoObj == null || !int.TryParse(kayitNoObj.ToString(), out int kayitNo))
                {
                    XtraMessageBox.Show("Kayıt numarası okunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable pdfData = await SQLiteCrud.GetDataFromSQLiteAsync($"SELECT PDFFile FROM Consensus WHERE ID = {kayitNo} LIMIT 1");
                if (pdfData.Rows.Count == 0 || pdfData.Rows[0]["PDFFile"] == DBNull.Value)
                {
                    XtraMessageBox.Show("PDF bulunamadı veya oluşturulmamış.", "PDF Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                byte[] pdfBytes = (byte[])pdfData.Rows[0]["PDFFile"];
                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    XtraMessageBox.Show("PDF verisi boş.", "PDF Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string tempFilePath = Path.Combine(Path.GetTempPath(), $"Mutabakat_{kayitNo}.pdf");
                File.WriteAllBytes(tempFilePath, pdfBytes);
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı PDF İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResponseNullConsensusForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
    }
}