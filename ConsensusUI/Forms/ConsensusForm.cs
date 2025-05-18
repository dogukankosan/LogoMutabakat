using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ConsensusUI.Classes;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ConsensusUI.Forms
{
    public partial class ConsensusForm : XtraForm
    {
        public ConsensusForm()
        {
            InitializeComponent();
        }
        Dictionary<int, bool> secimDurumu = new Dictionary<int, bool>();
        private HashSet<int> sentCustomerIDs = new HashSet<int>();
        private async void wpSendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool statusCustomerSendMonth = false;
            DataTable companyIsMonth = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT IsConMonth FROM CompanySettings LIMIT 1");
            if (companyIsMonth.Rows[0][0].ToString() == "1")
                statusCustomerSendMonth = true;
            bool enAzBirSeciliVar = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var rawValue = gridView1.GetRowCellValue(i, "Seç");
                if (rawValue != null && rawValue != DBNull.Value && Convert.ToBoolean(rawValue))
                {
                    enAzBirSeciliVar = true;
                    break;
                }
            }
            if (!enAzBirSeciliVar)
            {
                XtraMessageBox.Show("Lütfen en az bir cari seçiniz.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = XtraMessageBox.Show("Seçili Tüm Carilere Online Mutabakat Whatsapp Gönderilecektir Emin Misiniz ?", "Mutabakat Whatsapp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                List<int> seciliCariListesi = new List<int>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var selected = gridView1.GetRowCellValue(i, "Seç");
                    if (selected != null && Convert.ToBoolean(selected))
                    {
                        var row = gridView1.GetDataRow(i);
                        if (row != null && int.TryParse(row["LOGICALREF"].ToString(), out int logicalRef))
                            seciliCariListesi.Add(logicalRef);
                    }
                }
                bool dahaOnceGonderilenVar = false;
                List<string> buAyZatenGonderilenler = new List<string>();
                foreach (int logicalRef in seciliCariListesi)
                {
                    string query = $@"
        SELECT COUNT(1) FROM Consensus
        WHERE CustomerID = {logicalRef} AND ConMonth = {dateTimePicker1.Value.Month} AND ConYear = {dateTimePicker1.Value.Year}";
                    DataTable resultMonth = await SQLiteCrud.GetDataFromSQLiteAsync(query);
                    if (resultMonth != null && resultMonth.Rows.Count > 0 && Convert.ToInt32(resultMonth.Rows[0][0]) > 0)
                    {
                        dahaOnceGonderilenVar = true;
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            var refVal = gridView1.GetRowCellValue(i, "LOGICALREF");
                            if (refVal != null && int.TryParse(refVal.ToString(), out int rowRef) && rowRef == logicalRef)
                            {
                                string code = gridView1.GetRowCellValue(i, "Cari Hesap Kodu")?.ToString();
                                string definition = gridView1.GetRowCellValue(i, "Cari Açıklama")?.ToString();
                                buAyZatenGonderilenler.Add($"{code} - {definition} bu ay zaten gönderilmiş.");
                                break;
                            }
                        }
                    }
                }
                if (buAyZatenGonderilenler.Count > 0)
                {
                    memoExEdit1.Text += string.Join(Environment.NewLine, buAyZatenGonderilenler);
                    var memoStatus = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE ConsensusLog SET MemoDescp='" + memoExEdit1.Text.Trim() + "'");
                    if (!memoStatus.Success)
                    {
                        XtraMessageBox.Show("Log Temizleme İşlemi Hatalı", "Hatalı Log Temizleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (dahaOnceGonderilenVar)
                {
                    if (statusCustomerSendMonth)
                    {
                        var uyari = XtraMessageBox.Show(
                            "Seçtiğiniz carilerden bazılarına bu ay zaten mutabakat gönderilmiş.\nYine de göndermek istiyor musunuz?",
                            "Tekrar Gönderim Uyarısı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        if (uyari == DialogResult.No)
                            return;
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            "Seçili carilerden bazılarına bu ay zaten mutabakat gönderilmiş. Tekrar gönderime izin verilmiyor.",
                            "Gönderim Engellendi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                bool wpStatus = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM WhatsappSettings LIMIT 1");
                if (!wpStatus)
                {
                    XtraMessageBox.Show("Lütfen Önce Whatsapp Bilgileri Ayarlarınızı Giriniz", "Hatalı Whatsapp Gönderme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
                DataTable WpSettingsData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM WhatsappSettings LIMIT 1");
                DataTable companyData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM CompanySettings LIMIT 1");
                DataTable linkData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT WebAdres,WebToken,WebPassword,SQLConnectString,CompanyName FROM WebSettings LIMIT 1");
                DataTable WebData = await SQLCrud.LoadDataIntoGridViewAsync(
    "SELECT WpCount,ID FROM CustomersConsensus WHERE CustomerName='" + linkData.Rows[0]["CompanyName"].ToString() +
    "' AND CustomerToken='" + linkData.Rows[0]["WebToken"].ToString() +
    "' AND CustomerPassword='" + linkData.Rows[0]["WebPassword"].ToString() + "'",
    linkData.Rows[0]["SQLConnectString"].ToString());
                if ((WebData is null) || WebData.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("Web Servis Bilgileri Okunamadı Hatalı", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int wpCount = 0;
                try
                {
                    if (string.IsNullOrEmpty(WebData.Rows[0]["WpCount"].ToString()))
                    {
                        XtraMessageBox.Show("Whatsapp Kontör Okuma İşlemi Hatalı", "Hatalı Whatsapp Gönderme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    wpCount = int.Parse(EncryptionHelper.Decrypt(WebData.Rows[0]["WpCount"].ToString()));
                    if (wpCount <= 0)
                    {
                        XtraMessageBox.Show("Whatsapp Kontör Okuma İşlemi Hatalı", "Hatalı Whatsapp Gönderme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Whatsapp Kontör Okuma İşlemi Hatalı", "Hatalı Whatsapp Gönderme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<string> errorList = new List<string>();
                SplashScreen1 splash = new SplashScreen1();
                splash.StartPosition = FormStartPosition.CenterParent;
                splash.Show(this);
                Application.DoEvents();
                await Task.Delay(1000);
                int toplamSecilen = seciliCariListesi.Count;
                int gonderilenSayisi = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (splash.IsCancelled)
                    {
                        for (int j = i; j < gridView1.RowCount; j++)
                        {
                            var rowCheck = gridView1.GetDataRow(j);
                            if (rowCheck == null) continue;

                            var selectedVal = gridView1.GetRowCellValue(j, "Seç");
                            if (selectedVal != null && selectedVal != DBNull.Value && Convert.ToBoolean(selectedVal))
                            {
                                int refId = rowCheck["LOGICALREF"] != DBNull.Value ? Convert.ToInt32(rowCheck["LOGICALREF"]) : 0;
                            }
                        }
                        gridView1.RefreshData();
                        splash.Close();
                        XtraMessageBox.Show("Gönderim İşlemi iptal edildi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    var row = gridView1.GetDataRow(i);
                    if (row == null) continue;
                    bool seciliMi = false;
                    var rawValue = gridView1.GetRowCellValue(i, "Seç");
                    if (rawValue != null && rawValue != DBNull.Value)
                        seciliMi = Convert.ToBoolean(rawValue);
                    if (!seciliMi) continue;
                    string cariCode = row["Cari Hesap Kodu"]?.ToString();
                    int logicalRef = row["LOGICALREF"] != DBNull.Value ? Convert.ToInt32(row["LOGICALREF"]) : 0;
                    splash.UpdateStatus($"Gönderilen Cari Kodu : {cariCode}  Kalan: {gonderilenSayisi + 1}/{toplamSecilen}");
                    if (string.IsNullOrWhiteSpace(cariCode))
                    {
                        errorList.Add($"{i}. Nolu Satırda Cari Hesap Kodu Boş Cari Hesap Kodu Boş Olamaz.");
                        continue;
                    }
                    if (wpCount <= 0)
                    {
                        splash.Close();
                        XtraMessageBox.Show("Kontörünüz Bitmiştir Lütfen Köntör Eklemesi Yapınız", "Hatalı Kontör İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorList.Add($"{cariCode} Cari Koduda Dahil Ve Sonrakiler Gönderilemedi Kontörünüz Bitmiştir.");
                        break;
                    }
                    string wp = row["Telefon"]?.ToString();
                    if (string.IsNullOrWhiteSpace(wp))
                    {
                        errorList.Add($"{cariCode} Cari Kodunun Telefonu Boş.");
                        continue;
                    };
                    wp = "whatsapp:" + wp;
                    string cariUnvan = row["Cari Açıklama"]?.ToString();
                    string tarihFormatted = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                    string tarih = dateTimePicker1.Value.ToString("M-d-yyyy");
                    DataTable companyIsTl = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT ISTL FROM CompanySettings LIMIT 1");
                    int isTlStatus = 0;
                    int.TryParse(companyIsTl.Rows[0][0]?.ToString(), out isTlStatus);
                    decimal bakiye = 0;
                    decimal.TryParse(row["TL Bakiye"]?.ToString(), out bakiye);
                    byte[] pdfBytes = await ConsensusPDF.CreatePdfAsync(logicalRef, cariUnvan, "1-1-1900", tarih, isTlStatus, tarihFormatted, bakiye);
                    if (pdfBytes == null || pdfBytes.Length == 0)
                    {
                        errorList.Add($"{cariCode} Cari Kodunun PDF Oluşturma İşlemi Hatalı.");
                        continue;
                    }
                    int ay = dateTimePicker1.Value.Month;
                    int yil = dateTimePicker1.Value.Year;
                    int sqliteID = await SQLiteCrud.InsertAndReturnIDSQLiteAsync(logicalRef, 1, ay, yil, pdfBytes);
                    if (sqliteID <= 0)
                    {
                        errorList.Add($"{cariCode} Cari Kodunun Consensus SQLite Ekleme İşlemi Hatalı");
                        continue;
                    }
                    int sqlInsertStatus = await SQLCrud.InsertAndReturnIDAsync(
                        EncryptionHelper.Decrypt(linkData.Rows[0]["SQLConnectString"].ToString()),
                        WebData.Rows[0]["ID"].ToString(),
                        pdfBytes,
                        "1", sqliteID
                    );
                    if (sqlInsertStatus <= 0)
                    {
                        errorList.Add($"{cariCode} Cari Kodunun Web Service Whatsapp Kaydetme İşlemi Hatalı.");
                        await SQLiteCrud.InsertUpdateDeleteAsync("DELETE FROM Consensus WHERE ID=" + sqliteID + " ");
                        continue;
                    }

                    string accountSid = EncryptionHelper.Decrypt(WpSettingsData.Rows[0]["WpClientID"].ToString());
                    string authToken = EncryptionHelper.Decrypt(WpSettingsData.Rows[0]["WpToken"].ToString());
                    string messagingServiceSid = EncryptionHelper.Decrypt(WpSettingsData.Rows[0]["WpServiceID"].ToString());
                    string templateSid = EncryptionHelper.Decrypt(WpSettingsData.Rows[0]["TemplateID"].ToString());
                    string token = $"{linkData.Rows[0]["WebToken"].ToString()}|{linkData.Rows[0]["WebPassword"].ToString()}|{sqlInsertStatus}";
                    string code = $"{token}";
                    string contentVariables = JsonConvert.SerializeObject(new
                    {
                        customer = cariUnvan,
                        date = tarihFormatted,
                        no = sqlInsertStatus.ToString(),
                        company = companyData.Rows[0]["CompanyName"].ToString(),
                        token = token,
                        mergedParam = code
                    });
                    try
                    {
                        TwilioClient.Init(accountSid, authToken);
                        var message = MessageResource.Create(
                             messagingServiceSid: messagingServiceSid,
                             to: new PhoneNumber(wp),
                             body: "",
                             contentSid: templateSid,
                             contentVariables: contentVariables
                              );
                        if (message.ErrorCode != null)
                        {
                            errorList.Add($"{cariCode}: {message.ErrorMessage}");
                            await SQLiteCrud.InsertUpdateDeleteAsync("DELETE FROM Consensus WHERE ID=" + sqliteID + " ");
                            continue;
                        }
                        if (message.ErrorCode == null)
                        {
                            gonderilenSayisi++;
                            wpCount--;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorList.Add($"{cariCode}: {ex.ToString()} + {ex.Message}");
                        await SQLiteCrud.InsertUpdateDeleteAsync("DELETE FROM Consensus WHERE ID=" + sqliteID + " ");
                        continue;
                    }            
                }
                await LoadSentConsensusAsync();
                for (int rowHandle = 0; rowHandle < gridView1.RowCount; rowHandle++)
                {
                    var rowLogicalRefObj = gridView1.GetRowCellValue(rowHandle, "LOGICALREF");
                    if (rowLogicalRefObj != null && int.TryParse(rowLogicalRefObj.ToString(), out int currentRef))
                        RefreshRowStatus(currentRef);
                }
                splash.Close();
                bool mailCountUpdateStatus = await SQLCrud.InserUpdateDelete("UPDATE CustomersConsensus SET WpCount= '" + EncryptionHelper.Encrypt(wpCount.ToString()) + "' WHERE ID= " + WebData.Rows[0]["ID"].ToString() + "", linkData.Rows[0]["SQLConnectString"].ToString());
                if (mailCountUpdateStatus)
                {
                    XtraMessageBox.Show($"Mutabakat Gönderme İşlemi Başarılı Kalan Whatsapp Kontör Sayınız: {wpCount}", "Whatsapp Kontör Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    XtraMessageBox.Show($"Mutabakat Kontör Güncelleme İşlemi Hatalı", "Mail Kontör Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (errorList.Count > 0)
                {
                    XtraMessageBox.Show("Mutabakat Gönderilirken Hata İle Karşılaşıldı Log Listesinden Kontrol Ediniz", "Whatsapp Gönderme Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    memoExEdit1.Focus();
                    foreach (string item in errorList)
                        memoExEdit1.Text += item + Environment.NewLine;
                    var memoStatus = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE ConsensusLog SET MemoDescp='" + memoExEdit1.Text.Trim() + "'");
                    if (!memoStatus.Success)
                    {
                        XtraMessageBox.Show("Log Temizleme İşlemi Hatalı", "Hatalı Log Temizleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
        private async void sendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool statusCustomerSendMonth = false;
            DataTable companyIsMonth = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT IsConMonth FROM CompanySettings LIMIT 1");
            if (companyIsMonth.Rows[0][0].ToString() == "1")
                statusCustomerSendMonth = true;
            bool enAzBirSeciliVar = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var rawValue = gridView1.GetRowCellValue(i, "Seç");
                if (rawValue != null && rawValue != DBNull.Value && Convert.ToBoolean(rawValue))
                {
                    enAzBirSeciliVar = true;
                    break;
                }
            }
            if (!enAzBirSeciliVar)
            {
                XtraMessageBox.Show("Lütfen en az bir cari seçiniz.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = XtraMessageBox.Show("Seçili Tüm Carilere Online Mutabakat Maili Gönderilecektir Emin Misiniz ?", "Mutabakat Maili", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                List<int> seciliCariListesi = new List<int>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var selected = gridView1.GetRowCellValue(i, "Seç");
                    if (selected != null && Convert.ToBoolean(selected))
                    {
                        var row = gridView1.GetDataRow(i);
                        if (row != null && int.TryParse(row["LOGICALREF"].ToString(), out int logicalRef))
                            seciliCariListesi.Add(logicalRef);
                    }
                }
                bool dahaOnceGonderilenVar = false;
                List<string> buAyZatenGonderilenler = new List<string>();
                foreach (int logicalRef in seciliCariListesi)
                {
                    string query = $@"
        SELECT COUNT(1) FROM Consensus
        WHERE CustomerID = {logicalRef} AND ConMonth = {dateTimePicker1.Value.Month} AND ConYear = {dateTimePicker1.Value.Year}";
                    DataTable resultMonth = await SQLiteCrud.GetDataFromSQLiteAsync(query);
                    if (resultMonth != null && resultMonth.Rows.Count > 0 && Convert.ToInt32(resultMonth.Rows[0][0]) > 0)
                    {
                        dahaOnceGonderilenVar = true;
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            var refVal = gridView1.GetRowCellValue(i, "LOGICALREF");
                            if (refVal != null && int.TryParse(refVal.ToString(), out int rowRef) && rowRef == logicalRef)
                            {
                                string code = gridView1.GetRowCellValue(i, "Cari Hesap Kodu")?.ToString();
                                string definition = gridView1.GetRowCellValue(i, "Cari Açıklama")?.ToString();
                                buAyZatenGonderilenler.Add($"{code} - {definition} bu ay zaten gönderilmiş.");
                                break;
                            }
                        }
                    }
                }
                if (buAyZatenGonderilenler.Count > 0)
                {
                    memoExEdit1.Text += string.Join(Environment.NewLine, buAyZatenGonderilenler);
                    var memoStatus = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE ConsensusLog SET MemoDescp='" + memoExEdit1.Text.Trim() + "'");
                    if (!memoStatus.Success)
                    {
                        XtraMessageBox.Show("Log Temizleme İşlemi Hatalı", "Hatalı Log Temizleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (dahaOnceGonderilenVar)
                {
                    if (statusCustomerSendMonth)
                    {
                        var uyari = XtraMessageBox.Show(
                            "Seçtiğiniz carilerden bazılarına bu ay zaten mutabakat gönderilmiş.\nYine de göndermek istiyor musunuz?",
                            "Tekrar Gönderim Uyarısı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        if (uyari == DialogResult.No)
                            return;
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            "Seçili carilerden bazılarına bu ay zaten mutabakat gönderilmiş. Tekrar gönderime izin verilmiyor.",
                            "Gönderim Engellendi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                bool mailStatus = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM MailSettings LIMIT 1");
                if (!mailStatus)
                {
                    XtraMessageBox.Show("Lütfen Önce Mail Bilgileri Ayarlarınızı Giriniz", "Hatalı Mail Gönderme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
                DataTable MailSettingsData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM MailSettings LIMIT 1");
                DataTable companyData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM CompanySettings LIMIT 1");
                DataTable linkData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT WebAdres,WebToken,WebPassword,SQLConnectString,CompanyName FROM WebSettings LIMIT 1");
                DataTable WebData = await SQLCrud.LoadDataIntoGridViewAsync(
    "SELECT MailCount,ID FROM CustomersConsensus WHERE CustomerName='" + linkData.Rows[0]["CompanyName"].ToString() +
    "' AND CustomerToken='" + linkData.Rows[0]["WebToken"].ToString() +
    "' AND CustomerPassword='" + linkData.Rows[0]["WebPassword"].ToString() + "'",
    linkData.Rows[0]["SQLConnectString"].ToString());
                if ((WebData is null) || WebData.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("Web Servis Bilgileri Okunamadı Hatalı", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int mailCount = 0;
                try
                {
                    if (string.IsNullOrEmpty(WebData.Rows[0]["MailCount"].ToString()))
                    {
                        XtraMessageBox.Show("Mail Kontör Okuma İşlemi Hatalı", "Hatalı Mail Gönderme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    mailCount = int.Parse(EncryptionHelper.Decrypt(WebData.Rows[0]["MailCount"].ToString()));
                    if (mailCount <= 0)
                    {
                        XtraMessageBox.Show("Mail Kontör Okuma İşlemi Hatalı", "Hatalı Mail Gönderme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Mail Kontör Okuma İşlemi Hatalı", "Hatalı Mail Gönderme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<string> errorList = new List<string>();
                SplashScreen1 splash = new SplashScreen1();
                splash.StartPosition = FormStartPosition.CenterParent;
                splash.Show(this);
                Application.DoEvents();
                await Task.Delay(1000);
                int toplamSecilen = seciliCariListesi.Count;
                int gonderilenSayisi = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (splash.IsCancelled)
                    {
                        for (int j = i; j < gridView1.RowCount; j++)
                        {
                            var rowCheck = gridView1.GetDataRow(j);
                            if (rowCheck == null) continue;

                            var selectedVal = gridView1.GetRowCellValue(j, "Seç");
                            if (selectedVal != null && selectedVal != DBNull.Value && Convert.ToBoolean(selectedVal))
                            {
                                int refId = rowCheck["LOGICALREF"] != DBNull.Value ? Convert.ToInt32(rowCheck["LOGICALREF"]) : 0;
                            }
                        }
                        gridView1.RefreshData();
                        splash.Close();
                        XtraMessageBox.Show("Gönderim İşlemi iptal edildi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    var row = gridView1.GetDataRow(i);
                    if (row == null) continue;
                    bool seciliMi = false;
                    var rawValue = gridView1.GetRowCellValue(i, "Seç");
                    if (rawValue != null && rawValue != DBNull.Value)
                        seciliMi = Convert.ToBoolean(rawValue);
                    if (!seciliMi) continue;
                    string cariCode = row["Cari Hesap Kodu"]?.ToString();
                    int logicalRef = row["LOGICALREF"] != DBNull.Value ? Convert.ToInt32(row["LOGICALREF"]) : 0;
                    splash.UpdateStatus($"Gönderilen Cari Kodu : {cariCode}  Kalan: {gonderilenSayisi + 1}/{toplamSecilen}");
                    if (string.IsNullOrWhiteSpace(cariCode))
                    {
                        errorList.Add($"{i}. Nolu Satırda Cari Hesap Kodu Boş Cari Hesap Kodu Boş Olamaz.");
                        continue;
                    }
                    if (mailCount <= 0)
                    {
                        splash.Close();
                        XtraMessageBox.Show("Kontörünüz Bitmiştir Lütfen Köntör Eklemesi Yapınız", "Hatalı Kontör İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorList.Add($"{cariCode} Cari Koduda Dahil Ve Sonrakiler Gönderilemedi Kontörünüz Bitmiştir.");
                        break;
                    }
                    string mail = row["Mail"]?.ToString();
                    if (string.IsNullOrWhiteSpace(mail))
                    {
                        errorList.Add($"{cariCode} Cari Kodunun Mail Adresi Boş.");

                        continue;
                    };
                    string cariUnvan = row["Cari Açıklama"]?.ToString();
                    string tarihFormatted = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                    string tarih = dateTimePicker1.Value.ToString("M-d-yyyy");
                    DataTable companyIsTl = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT ISTL FROM CompanySettings LIMIT 1");
                    int isTlStatus = int.Parse(companyIsTl.Rows[0][0].ToString());
                    decimal bakiye = 0;
                    decimal.TryParse(row["TL Bakiye"]?.ToString(), out bakiye);
                    byte[] pdfBytes = await ConsensusPDF.CreatePdfAsync(logicalRef, cariUnvan, "1-1-1900", tarih, isTlStatus, tarihFormatted, bakiye);
                    if (pdfBytes == null || pdfBytes.Length == 0)
                    {
                        errorList.Add($"{cariCode} Cari Kodunun PDF Oluşturma İşlemi Hatalı.");
                        continue;
                    }
                    int ay = dateTimePicker1.Value.Month;
                    int yil = dateTimePicker1.Value.Year;
                    int sqliteID = await SQLiteCrud.InsertAndReturnIDSQLiteAsync(logicalRef, 0, ay, yil, pdfBytes);
                    if (sqliteID <= 0)
                    {
                        errorList.Add($"{cariCode} Cari Kodunun Consensus SQLite Ekleme İşlemi Hatalı");
                        continue;
                    }
                    int sqlInsertStatus = await SQLCrud.InsertAndReturnIDAsync(
                        EncryptionHelper.Decrypt(linkData.Rows[0]["SQLConnectString"].ToString()),
                        WebData.Rows[0]["ID"].ToString(),
                        null,
                        "0", sqliteID
                    );
                    if (sqlInsertStatus <= 0)
                    {
                        errorList.Add($"{cariCode} Cari Kodunun Web Service Mail Kaydetme İşlemi Hatalı.");
                        await SQLiteCrud.InsertUpdateDeleteAsync("DELETE FROM Consensus WHERE ID=" + sqliteID + " ");
                        continue;
                    }
                    bool mailSendStatus = await EMailManager.OrderMailSend(
                        senderEmail: MailSettingsData.Rows[0]["MailAdress"].ToString(),
                        recipientEmail: mail,
                        senderPassword: EncryptionHelper.Decrypt(MailSettingsData.Rows[0]["Password"].ToString()),
                        server: MailSettingsData.Rows[0]["ServerName"].ToString(),
                        port: Convert.ToInt32(MailSettingsData.Rows[0]["Port"]),
                        ssl: Convert.ToBoolean(MailSettingsData.Rows[0]["SSL"]),
                        customerName: cariUnvan,
                        consensusDate: tarihFormatted,
                        WebToken: linkData.Rows[0]["WebToken"].ToString(),
                        WebPassword: linkData.Rows[0]["WebPassword"].ToString(),
                        WebAdres: linkData.Rows[0]["WebAdres"].ToString(),
                        consensID: sqlInsertStatus.ToString(),
                        myCompany: companyData.Rows[0]["CompanyName"].ToString(),
                        pdfPath: pdfBytes
                    );
                    if (!mailSendStatus)
                    {
                        errorList.Add($"{cariCode} Cari Kodunun Mail Gönderme İşlemi Hatalı Loglardan Kontrol Ediniz.");
                        await SQLiteCrud.InsertUpdateDeleteAsync("DELETE FROM Consensus WHERE ID=" + sqliteID + " ");
                        continue;
                    }
                    mailCount--;
                    gonderilenSayisi++;

                }
                for (int rowHandle = 0; rowHandle < gridView1.RowCount; rowHandle++)
                {
                    var rowLogicalRefObj = gridView1.GetRowCellValue(rowHandle, "LOGICALREF");
                    if (rowLogicalRefObj != null && int.TryParse(rowLogicalRefObj.ToString(), out int currentRef))
                        RefreshRowStatus(currentRef);
                }
                splash.Close();
                bool mailCountUpdateStatus = await SQLCrud.InserUpdateDelete("UPDATE CustomersConsensus SET MailCount= '" + EncryptionHelper.Encrypt(mailCount.ToString()) + "' WHERE ID= " + WebData.Rows[0]["ID"].ToString() + "", linkData.Rows[0]["SQLConnectString"].ToString());
                if (mailCountUpdateStatus)
                {
                    XtraMessageBox.Show($"Mutabakat Gönderme İşlemi Başarılı Kalan Mail Kontör Sayınız: {mailCount}", "Mail Kontör Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    XtraMessageBox.Show($"Mutabakat Kontör Güncelleme İşlemi Hatalı", "Mail Kontör Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (errorList.Count > 0)
                {
                    XtraMessageBox.Show("Mutabakat Gönderilirken Hata İle Karşılaşıldı Log Listesinden Kontrol Ediniz", "Mail Gönderme Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    memoExEdit1.Focus();
                    foreach (string item in errorList)
                        memoExEdit1.Text += item + Environment.NewLine;
                    var memoStatus = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE ConsensusLog SET MemoDescp='" + memoExEdit1.Text.Replace("'","").Trim() + "'");
                    if (!memoStatus.Success)
                    {
                        XtraMessageBox.Show("Log Temizleme İşlemi Hatalı", "Hatalı Log Temizleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                await LoadSentConsensusAsync();
            }
        }
        private async void List()
        {
            DataTable companyData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM CompanySettings LIMIT 1");
            DataTable sqlconnection = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            string tarih = dateTimePicker1.Value.ToString("M-d-yyyy");
            string quertList = QueryCustomer(companyData.Rows[0]["LogoCompanyCode"].ToString(), companyData.Rows[0]["LogoPeriod"].ToString(), "1-1-1900", tarih);
            gridControl1.DataSource = await SQLCrud.LoadDataIntoGridViewAsync(quertList, sqlconnection.Rows[0]["SQLConnectString"].ToString());
            if (gridView1.DataSource is null)
            {
                XtraMessageBox.Show("SQL Verileri Çekerken Hata Oluştur", "Hatalı SQL İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            secimDurumu.Clear();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var refVal = gridView1.GetRowCellValue(i, "LOGICALREF");
                if (refVal != null && int.TryParse(refVal.ToString(), out int logicalRef))
                    secimDurumu[logicalRef] = false;
            }
            await LoadSentConsensusAsync();
            gridView1.RefreshData();
            UtilityHelper.CustomizeGridView(gridView1);
            gridView1.Columns["Borç"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["Borç"].DisplayFormat.FormatString = "n2";
            gridView1.Columns["Alacak"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["Alacak"].DisplayFormat.FormatString = "n2";
            gridView1.Columns["TL Bakiye"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["TL Bakiye"].DisplayFormat.FormatString = "n2";
            if (!gridView1.Columns.Contains(gridView1.Columns["Seç"]))
            {
                gridView1.Columns.AddVisible("Seç", "Seç");
                gridView1.Columns["Seç"].UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
                gridView1.Columns["Seç"].VisibleIndex = 0;
                gridView1.Columns["Seç"].Width = 40;
                RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit();
                gridControl1.RepositoryItems.Add(checkEdit);
                gridView1.Columns["Seç"].ColumnEdit = checkEdit;
            }
            if (gridView1.Columns["Seç"] != null)
            {
                gridView1.Columns["Seç"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["Seç"].OptionsColumn.ReadOnly = false;
            }
            if (gridView1.Columns["LOGICALREF"] != null)
                gridView1.Columns["LOGICALREF"].Visible = false;
        }
        private string QueryCustomer(string companyCode, string companyPeriod, string startDate, string lastDate)
        {
            return $@"
SELECT 
    ISNULL(CL.LOGICALREF, '') AS 'LOGICALREF',
    ISNULL(CL.CODE, '') AS 'Cari Hesap Kodu',
    ISNULL(CL.DEFINITION_, '') AS 'Cari Açıklama',
    ISNULL(CL.SPECODE, '') AS 'Özel Kod',
    ISNULL(CL.SPECODE2, '') AS 'Özel Kod 2',
    ISNULL(CL.SPECODE3, '') AS 'Özel Kod 3',
    ISNULL(CL.SPECODE4, '') AS 'Özel Kod 4',
    ISNULL(CL.TELNRS1, '') AS 'Telefon',
    ISNULL(CL.EMAILADDR, '') AS 'Mail',
  CONVERT(DECIMAL(20,2), ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN AMOUNT * (1 - SIGN) ELSE AMOUNT END), 0)) AS 'Borç',
    CONVERT(DECIMAL(20,2), ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN AMOUNT * SIGN ELSE AMOUNT END), 0)) AS 'Alacak',
    CONVERT(DECIMAL(20,2), ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN AMOUNT * (1 - SIGN) ELSE AMOUNT END), 0) - 
    ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN AMOUNT * SIGN ELSE AMOUNT END), 0)) AS 'TL Bakiye'
FROM LG_{companyCode}_{companyPeriod}_CLFLINE TRN WITH(NOLOCK)
RIGHT JOIN LG_{companyCode}_CLCARD CL WITH (NOLOCK)  ON CL.LOGICALREF = TRN.CLIENTREF AND TRN.TRCURR=0 AND TRN.STATUS = 0 
AND TRN.CANCELLED = 0 AND TRN.TRCODE <> 12 AND
TRN.DATE_ BETWEEN  TRY_CONVERT(datetime, '{startDate}', 101)  AND TRY_CONVERT(datetime, '{lastDate}', 101)
WHERE  CL.ACTIVE = 0   
GROUP BY 
CL.LOGICALREF,
    CL.DEFINITION_, CL.CODE, CL.SPECODE,
    CL.SPECODE2, CL.SPECODE3, CL.SPECODE4,
    CL.TELNRS1, CL.EMAILADDR
ORDER BY CL.CODE";
        }
        private void RefreshRowStatus(int logicalRef)
        {
            for (int rowHandle = 0; rowHandle < gridView1.RowCount; rowHandle++)
            {
                var rowLogicalRefObj = gridView1.GetRowCellValue(rowHandle, "LOGICALREF");
                if (rowLogicalRefObj != null && int.TryParse(rowLogicalRefObj.ToString(), out int currentRef))
                {
                    if (currentRef == logicalRef)
                    {
                        gridView1.RefreshRow(rowHandle);
                        gridView1.InvalidateRow(rowHandle);
                        break;
                    }
                }
            }
        }
        private async void testPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow selectedRow = gridView1.GetFocusedDataRow();
                if (selectedRow == null)
                {
                    XtraMessageBox.Show("Lütfen bir satır seçiniz.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string tarihFormatted = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                string tarih = dateTimePicker1.Value.ToString("M-d-yyyy");
                DataTable companyIsTl = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT ISTL FROM CompanySettings LIMIT 1");
                string cariUnvan = selectedRow["Cari Açıklama"]?.ToString();
                int isTlStatus = int.Parse(companyIsTl.Rows[0][0].ToString());
                decimal bakiye = 0;
                decimal.TryParse(selectedRow["TL Bakiye"]?.ToString(), out bakiye);
                int logicalRef = selectedRow["LOGICALREF"] != DBNull.Value ? Convert.ToInt32(selectedRow["LOGICALREF"]) : 0;
                byte[] pdfBytes = await ConsensusPDF.CreatePdfAsync(logicalRef, cariUnvan, "1-1-1900", tarih, isTlStatus, tarihFormatted, bakiye);
                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    XtraMessageBox.Show("PDF Oluşturulamadı", "PDF Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string tempFilePath = Path.Combine(Path.GetTempPath(), "CariHesapRaporu.pdf");
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
                return;
            }
        }
        private async void ConsensusForm_Load(object sender, EventArgs e)
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
            bool memoEdit = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM ConsensusLog LIMIT 1");
            if (memoEdit)
            {
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM ConsensusLog LIMIT 1");
                memoExEdit1.Text = dt.Rows[0][0].ToString();
            }
            List();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            List();
        }
        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle < 0) return;
            if (int.TryParse(view.GetRowCellValue(e.RowHandle, "LOGICALREF")?.ToString(), out int logicalRef))
            {
                if (sentCustomerIDs.Contains(logicalRef))
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.HighPriority = true;
                }
            }
        }
        private void removeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = string.Empty;
        }
        private void allCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
                gridView1.SetRowCellValue(i, "Seç", true);
        }
        private void allRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
                gridView1.SetRowCellValue(i, "Seç", false);
        }
        private async void sendCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT CustomerID FROM Consensus WHERE ConMonth=" + dateTimePicker1.Value.Month + " AND ConYear=" + dateTimePicker1.Value.Year + " ");
            HashSet<int> successfulCodes = new HashSet<int>(
                dt.AsEnumerable().Select(r => Convert.ToInt32(r["CustomerID"]))
            );
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var refVal = gridView1.GetRowCellValue(i, "LOGICALREF");
                if (refVal != null && int.TryParse(refVal.ToString(), out int logicalRef))
                    gridView1.SetRowCellValue(i, "Seç", successfulCodes.Contains(logicalRef));
                else
                    gridView1.SetRowCellValue(i, "Seç", false);
            }
        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "Seç") return;
            if (e.ListSourceRowIndex < 0) return;
            var logicalRefObj = gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "LOGICALREF");
            if (logicalRefObj == null || !int.TryParse(logicalRefObj.ToString(), out int logicalRef))
                return;
            if (e.IsGetData)
                e.Value = secimDurumu.TryGetValue(logicalRef, out bool val) && val;
            else if (e.IsSetData)
                secimDurumu[logicalRef] = Convert.ToBoolean(e.Value);
        }
        private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName != "Seç")
                e.Cancel = true;
        }
        private async void emptCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT CustomerID FROM Consensus WHERE ConMonth=" + dateTimePicker1.Value.Month + " AND ConYear=" + dateTimePicker1.Value.Year + "");
            HashSet<int> existingRefs = new HashSet<int>(
                dt.AsEnumerable().Select(r => Convert.ToInt32(r["CustomerID"]))
            );
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var refVal = gridView1.GetRowCellValue(i, "LOGICALREF");
                if (refVal != null && int.TryParse(refVal.ToString(), out int logicalRef))
                    secimDurumu[logicalRef] = !existingRefs.Contains(logicalRef);
            }
            gridView1.RefreshData();
        }
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName != "Seç") return;
            var row = gridView1.GetDataRow(e.RowHandle);
            if (row == null) return;
            if (int.TryParse(row["LOGICALREF"]?.ToString(), out int logicalRef))
            {
                if (secimDurumu.ContainsKey(logicalRef))
                    secimDurumu[logicalRef] = !secimDurumu[logicalRef];
                else
                    secimDurumu[logicalRef] = true;
                gridView1.RefreshRow(e.RowHandle);
            }
        }
        private void btn_LogClear_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_LogClear, "Logları Temizle");
        }
        private async void btn_LogClear_Click(object sender, EventArgs e)
        {
            var uyari = XtraMessageBox.Show(
                            "Tüm Hata Loglar Temizlenicektir Emin Misiniz ?",
                            "Hata Logları",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if (uyari == DialogResult.No)
                return;
            var values = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE ConsensusLog SET MemoDescp=''");
            if (!values.Success)
            {
                XtraMessageBox.Show("Log Temizleme İşlemi Hatalı", "Hatalı Log Temizleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            memoExEdit1.Text = "";
        }
        private void ConsensusForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
       private async Task LoadSentConsensusAsync()
        {
            string query = $"SELECT DISTINCT CustomerID FROM Consensus WHERE ConMonth = {dateTimePicker1.Value.Month} AND ConYear = {dateTimePicker1.Value.Year}";
            DataTable sentTable = await SQLiteCrud.GetDataFromSQLiteAsync(query);
            sentCustomerIDs.Clear();
            foreach (DataRow row in sentTable.Rows)
            {
                if (int.TryParse(row["CustomerID"]?.ToString(), out int id))
                    sentCustomerIDs.Add(id);
            }
        }
    }
}