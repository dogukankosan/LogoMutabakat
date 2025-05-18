using System;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using ConsensusUI.Classes;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using System.Diagnostics;
using System.IO;

namespace ConsensusUI.Forms
{
    public partial class CancelConsensusListForm : XtraForm
    {
        public CancelConsensusListForm()
        {
            InitializeComponent();
        }
        Dictionary<int, bool> secimDurumu = new Dictionary<int, bool>();
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
    ConYear AS 'MutabakatYılı',
    CASE Read
        WHEN 0 THEN 'Görülmedi'
        WHEN 1 THEN 'Görüldü'
        ELSE 'Bilinmiyor'
    END AS 'OkunmaDurumu'
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
        WHERE CustomerID = {webCustomerIDValue} AND ResponseMessage LIKE 'Reddedildi:%'
    ", webData.Rows[0]["SQLConnectString"].ToString());
            var result = from consensusRow in dt.AsEnumerable()
                         join cardRow in customerLogicalref.AsEnumerable()
                         on Convert.ToInt32(consensusRow["CariReferansNo"]) equals Convert.ToInt32(cardRow["LOGICALREF"])
                         join webRow in webConses.AsEnumerable()
                         on Convert.ToInt32(consensusRow["KayıtNo"]) equals Convert.ToInt32(webRow["SourceRef"]) into gj
                         from webMatched in gj.DefaultIfEmpty()
                         where webMatched != null && !string.IsNullOrWhiteSpace(webMatched.Field<string>("ResponseMessage"))
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
                             CevapMesajı = webMatched.Field<string>("ResponseMessage"),
                             CevapTarihi = webMatched.Field<DateTime?>("ResponseDate"),
                             OkunmaDurumu = consensusRow["OkunmaDurumu"],
                             ReddedenKişi = webMatched.Field<string>("ResponsePerson"),
                             Telefon = webMatched.Field<string>("ResponsePhone")
                         };
            gridControl1.DataSource = result.ToList();
            gridView1.Columns["GönderimTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["GönderimTarihi"].DisplayFormat.FormatString = "g";
            gridView1.Columns["CevapTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["CevapTarihi"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            UtilityHelper.CustomizeGridView(gridView1);
            gridView1.ClearSorting();
            gridView1.Columns["OkunmaDurumu"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridView1.Columns["GönderimTarihi"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            if (!gridView1.Columns.Contains(gridView1.Columns["Seç"]))
            {
                gridView1.Columns.AddVisible("Seç", "Seç");
                gridView1.Columns["Seç"].UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
                gridView1.Columns["Seç"].VisibleIndex = 0;
                gridView1.Columns["Seç"].Width = 40;
                RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit();
                gridControl1.RepositoryItems.Add(checkEdit);
                gridView1.Columns["Seç"].ColumnEdit = checkEdit;
                gridView1.Columns["Seç"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["Seç"].OptionsColumn.ReadOnly = false;
            }
        }
        private async void CancelConsensusListForm_Load(object sender, EventArgs e)
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
        private async void checkReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedIDs = new List<int>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowVisible(i) < 0) continue;
                var idObj = gridView1.GetRowCellValue(i, "KayıtNo");
                if (idObj != null && int.TryParse(idObj.ToString(), out int id))
                {
                    if (secimDurumu.TryGetValue(id, out bool secili) && secili)
                        selectedIDs.Add(id);
                }
            }
            if (selectedIDs.Count == 0)
            {
                XtraMessageBox.Show("Lütfen en az bir satır seçiniz.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string idList = string.Join(",", selectedIDs);
            string updateQuery = $"UPDATE Consensus SET Read = 1 WHERE ID IN ({idList})";
            var result = await SQLiteCrud.InsertUpdateDeleteAsync(updateQuery);
            if (result.Success)
            {
                XtraMessageBox.Show("Seçilen kayıtlar okundu olarak işaretlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List();
            }
            else
                XtraMessageBox.Show(result.ErrorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Excel'e Aktar";
                    saveDialog.FileName = "ReddedilenMutabakatlar.xlsx";

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
        private void gridView1_ShowingEditor_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName != "Seç")
                e.Cancel = true;
        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "Seç") return;
            if (e.ListSourceRowIndex < 0) return;
            var idObj = gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "KayıtNo");
            if (idObj == null || !int.TryParse(idObj.ToString(), out int id)) return;
            if (e.IsGetData)
                e.Value = secimDurumu.ContainsKey(id) && secimDurumu[id];
            else if (e.IsSetData)
                secimDurumu[id] = Convert.ToBoolean(e.Value);
        }
        private void gridView1_RowStyle_1(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var view = sender as GridView;
            string okumaDurumu = view.GetRowCellDisplayText(e.RowHandle, "OkunmaDurumu");
            if (okumaDurumu == "Görüldü")
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.HighPriority = true;
            }
            else if (okumaDurumu == "Görülmedi")
            {
                e.Appearance.BackColor = Color.LightCoral;
                e.HighPriority = true;
            }
        }
        private async void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedIDs = secimDurumu
                    .Where(kvp => kvp.Value) 
                    .Select(kvp => kvp.Key)
                    .ToList();
                if (selectedIDs.Count == 0)
                {
                    XtraMessageBox.Show("Lütfen bir satır seçiniz.", "Seçim Yok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (selectedIDs.Count > 1)
                {
                    XtraMessageBox.Show("Lütfen sadece bir satır seçiniz.", "Birden Fazla Seçim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int kayitNo = selectedIDs[0];
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
        private void unreadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            secimDurumu.Clear(); 
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowVisible(i) < 0) continue;
                var idObj = gridView1.GetRowCellValue(i, "KayıtNo");
                var durum = gridView1.GetRowCellDisplayText(i, "OkunmaDurumu");
                if (idObj != null && durum == "Görülmedi" && int.TryParse(idObj.ToString(), out int id))
                    secimDurumu[id] = true;
            }
            gridView1.RefreshData();
        }
        private void AllSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
                gridView1.SetRowCellValue(i, "Seç", true);
        }
        private void allUnSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
                gridView1.SetRowCellValue(i, "Seç", false);
        }
        private void filtreKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = string.Empty;
        }
        private void CancelConsensusListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
    }
}