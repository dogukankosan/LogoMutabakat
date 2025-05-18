using DevExpress.XtraEditors;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace ConsensusUI.Classes
{
    internal class EMailManager
    {
        internal async static Task ErrorMailSend(string errorMessage)
        {
            try
            {
                bool mailSettings = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM MailSettingsError LIMIT 1");
                if (!mailSettings) return;

                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM MailSettingsError LIMIT 1");
                string senderEmail = dt.Rows[0]["MailAdress"].ToString();
                string recipientEmail = senderEmail;
                string senderPassword = EncryptionHelper.Decrypt(dt.Rows[0]["Password"].ToString());
                string server = dt.Rows[0]["ServerName"].ToString();
                int port = Convert.ToInt32(dt.Rows[0]["Port"]);
                bool ssl = Convert.ToBoolean(dt.Rows[0]["SSL"]);
                string companyName = dt.Rows[0]["CompanyName"].ToString();
                string subject = $"{companyName} Firmasında Mutabakat Programında Hata Mesajı";

                using (var client = new SmtpClient(server, port))
                using (var mail = new MailMessage(senderEmail, recipientEmail, subject, errorMessage))
                {
                    client.EnableSsl = ssl;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    await client.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging(ex.Message + " ---- " + ex.ToString());
            }
        }
        internal async static Task<bool> TestMailSend(string senderEmail, string recipientEmail, string senderPassword, string server, int port, bool ssl)
        {
            try
            {
                using (var client = new SmtpClient(server, port))
                using (var mail = new MailMessage(senderEmail, recipientEmail)
                {
                    Subject = "Test E-posta Başlığı",
                    Body = ""
                })
                {
                    client.EnableSsl = ssl;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    await client.SendMailAsync(mail);
                }

                XtraMessageBox.Show("E-Mail Başarıyla Gönderildi.", "Başarılı Mail Gönderme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("E-Mail gönderilirken bir hata oluştu: " + ex.Message, "Hatalı E-Posta Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextLog.TextLogging(ex.Message + " ---- " + ex.ToString(),"1");
                return false;
            }
        }
        internal async static Task<bool> OrderMailSend(
            string senderEmail,
            string recipientEmail,
            string senderPassword,
            string server,
            int port,
            bool ssl,
            string customerName,
            string consensusDate,
            string WebToken,
            string WebPassword,
            string WebAdres,
            string consensID,
            string myCompany,
            byte[] pdfPath)
        {
            try
            {
                string tokenValue = $"{WebToken}|{WebPassword}|{consensID}";
                string encodedToken = HttpUtility.UrlEncode(tokenValue);
                string link = $"{WebAdres}/Consensus/Approve?token={encodedToken}";
                DataTable signMail = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM MailSignature LIMIT 1");
                string htmlSignature = string.Empty;
                string rawBase64 = signMail?.Rows[0]["CompanyImage"]?.ToString();
                if (signMail != null && signMail.Rows.Count > 0)
                {
                    string name = signMail.Rows[0]["CompanyName"]?.ToString();
                    string phone = signMail.Rows[0]["Phone"]?.ToString();
                    string address = signMail.Rows[0]["Adress"]?.ToString();
                    string website = signMail.Rows[0]["CompanyWebSite"]?.ToString();

                    if (!string.IsNullOrWhiteSpace(name) &&
                        !string.IsNullOrWhiteSpace(phone) &&
                        !string.IsNullOrWhiteSpace(address) &&
                        !string.IsNullOrWhiteSpace(website))
                    {
                        htmlSignature = $@"
<br/>
<hr />
<table style='font-family: Arial, sans-serif; font-size: 14px;'>
    <tr>
        <td style='vertical-align: top; padding-right: 15px;'>
            <img src='cid:firmaLogo' alt='Firma Logo' style='width: 150px; height: auto; border-radius: 5px;'/>
        </td>
        <td style='vertical-align: top;'>
            <p style='margin: 0;'><strong style='font-size: 16px; color: #333;'>{name}</strong></p>
            <p style='margin: 2px 0;'>📞 <a href='tel:{phone}' style='color: #000; text-decoration: none;'>{phone}</a></p>
            <p style='margin: 2px 0;'>💬 <a href='https://wa.me/{phone.Replace("+", "").Replace(" ", "")}' style='color: #25D366; text-decoration: none;'>WhatsApp ile yaz</a></p>
            <p style='margin: 2px 0;'>📍 {address}</p>
            <p style='margin: 2px 0;'>🌐 <a href='https://{website}' style='color: #1a0dab;' target='_blank'>{website}</a></p>
        </td>
    </tr>
</table>";
                    }
                }
                string subject = $"{myCompany} Firmasının Mutabakatı Onay Bekleniyor.";
                string body = $@"
<html>
<body>
    <p>Sn. <strong>{customerName}</strong>, <strong>{consensusDate}</strong> tarihli 
    <strong><i>{consensID}</i></strong> nolu mutabakat mektubu, 
    <strong>{myCompany}</strong> firmasına ait online mutabakat mektubu tarafınızdan onay <strong>beklenmektedir</strong>.
    Mutabakat detayları ekteki PDF'tedir.</p>
    <p>
        <a href='{link}' style='
            background-color: #4CAF50;
            color: white;
            padding: 10px 15px;
            text-decoration: none;
            border-radius: 5px;
            font-weight: bold;
        '>📄 Mutakabat Onayla Veya Reddet</a>
    </p>
    {htmlSignature}
</body>
</html>";
                using (var client = new SmtpClient(server, port))
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.To.Add(recipientEmail);
                    client.EnableSsl = ssl;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    AlternateView avHtml = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
                    if (!string.IsNullOrWhiteSpace(rawBase64))
                    {
                        byte[] logoBytes = Convert.FromBase64String(rawBase64);
                        var logoStream = new MemoryStream(logoBytes);
                        LinkedResource inlineLogo = new LinkedResource(logoStream, MediaTypeNames.Image.Jpeg)
                        {
                            ContentId = "firmaLogo",
                            TransferEncoding = TransferEncoding.Base64,
                            ContentType = new ContentType(MediaTypeNames.Image.Jpeg)
                        };
                        inlineLogo.ContentType.Name = "LOGO";
                        avHtml.LinkedResources.Add(inlineLogo);
                    }
                    mail.AlternateViews.Add(avHtml);
                    if (pdfPath != null && pdfPath.Length > 0)
                    {
                        var pdfStream = new MemoryStream(pdfPath);
                        Attachment pdfAttachment = new Attachment(pdfStream, $"{consensID}.pdf", "application/pdf");
                        mail.Attachments.Add(pdfAttachment);
                    }
                    await client.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging(ex.Message + " ---- " + ex.ToString(), "1");
                return false;
            }
            return true;
        }
    }
}