using DevExpress.XtraEditors;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConsensusUI.Business
{
    internal class PDFLogic
    {
        internal static bool PDFControl(TextEdit companyName,TextEdit adress, MaskedTextBox vkn,MaskedTextBox phone,TextEdit mail, PictureEdit image)
        {
            #region CompanyName
            if (string.IsNullOrEmpty(companyName.Text.Trim()))
            {
                XtraMessageBox.Show("Şirket adı kutusu boş geçilemez", "Hatalı Şirket Adı Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyName.Focus();
                return false;
            }
            else if (companyName.Text.Trim().Length > 250)
            {
                XtraMessageBox.Show("Şirket adı 250 karakterden fazla olamaz", "Hatalı Şirket Adı Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyName.Focus();
                return false;
            }
            #endregion
            #region Adress
            if (string.IsNullOrEmpty(adress.Text.Trim()))
            {
                XtraMessageBox.Show("Adres kutusu boş geçilemez", "Hatalı Adres Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                adress.Focus();
                return false;
            }
            else if (adress.Text.Trim().Length > 250)
            {
                XtraMessageBox.Show("Adres 250 karakterden fazla olamaz", "Hatalı Adres Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                adress.Focus();
                return false;
            }
            #endregion
            #region VKN
            if (string.IsNullOrEmpty(vkn.Text.Trim()))
            {
                XtraMessageBox.Show("VKN (Vergi Kimlik Numarası) boş geçilemez", "Hatalı VKN Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vkn.Focus();
                return false;
            }
            else if (vkn.Text.Trim().Length != 10)
            {
                XtraMessageBox.Show("VKN 10 haneli olmalıdır", "Hatalı VKN Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vkn.Focus();
                return false;
            }
            else if (!vkn.Text.Trim().All(char.IsDigit))
            {
                XtraMessageBox.Show("VKN sadece sayılardan oluşmalıdır", "Hatalı VKN Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vkn.Focus();
                return false;
            }
            #endregion
            #region Phone
            if (string.IsNullOrEmpty(phone.Text.Trim()))
            {
                XtraMessageBox.Show("Telefon No kutusu boş geçilemez", "Hatalı Telefon No Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phone.Focus();
                return false;
            }
            else if (!(phone.Text.Trim().Length == 13 || phone.Text.Trim().Length == 11))
            {
                XtraMessageBox.Show("Telefon No kutusu 11 veya 13 karakter olmalıdır (+901234567890)", "Hatalı Telefon No Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phone.Focus();
                return false;
            }
            else if (!Regex.IsMatch(phone.Text.Trim(), @"^\+90(5\d{9}|[2-4]\d{9}|8\d{9})$"))
            {
                XtraMessageBox.Show("Telefon numarası +90 ile başlamalı ve geçerli bir Türk numarası olmalıdır. Örnek: +905321234567 veya +902122224444", "Hatalı Telefon No Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phone.Focus();
                return false;
            }
            #endregion
            #region MailControl
            if (string.IsNullOrEmpty(mail.Text))
            {
                XtraMessageBox.Show("E-Mail Kutusu Boş Geçilemez", "Hatalı E-Mail Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mail.Focus();
                return false;
            }
            else if (mail.Text.Length < 5)
            {
                XtraMessageBox.Show("E-Mail Kutusu 5 Haneden Daha Az Olamaz", "Hatalı E-Mail Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mail.Focus();
                return false;
            }
            else if (mail.Text.Length > 50)
            {
                XtraMessageBox.Show("E-Mail Kutusu 50 Haneden Fazla Olamaz", "Hatalı E-Mail Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mail.Focus();
                return false;
            }
            else if (!mail.Text.Contains("@"))
            {
                XtraMessageBox.Show("E-Mail Kutusunun İçinde @ İşareti Bulunmalıdır", "Hatalı E-Mail Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mail.Focus();
                return false;
            }
            else if (!mail.Text.Contains("."))
            {
                XtraMessageBox.Show("E-Mail Kutusunun İçinde . İşareti Bulunmalıdır", "Hatalı E-Mail Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mail.Focus();
                return false;
            }
            #endregion
            #region CompanyImage
            if (image.Image is null)
            {
                XtraMessageBox.Show("Resim kutusu boş geçilemez", "Hatalı Resim Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                image.Focus();
                return false;
            }
            #endregion
            return true;
        }
    }
}