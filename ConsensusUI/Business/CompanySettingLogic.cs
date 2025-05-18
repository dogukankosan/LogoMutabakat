using DevExpress.XtraEditors;
using System.Linq;
using System.Windows.Forms;

namespace ConsensusUI.Business
{
    internal class CompanySettingLogic
    {
        internal static bool CompanyControl(TextEdit companyCode, TextEdit companyPeriod,TextEdit companyName)
        {
            #region CompanyCode
            if (string.IsNullOrEmpty(companyCode.Text.Trim()))
            {
                XtraMessageBox.Show("Şirket kodu kutusu boş geçilemez", "Hatalı Şirket Kodu Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyCode.Focus();
                return false;
            }
            else if (!companyCode.Text.Trim().All(char.IsDigit))
            {
                XtraMessageBox.Show("Şirket kodu sadece sayısal karakterlerden oluşmalıdır", "Hatalı Şirket Kodu Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyCode.Focus();
                return false;
            }
            else if (companyCode.Text.Trim().Length > 10)
            {
                XtraMessageBox.Show("Şirket kodu 10 karakterden fazla olamaz", "Hatalı Şirket Kodu Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyCode.Focus();
                return false;
            }
            #endregion

            #region CompanyPeriod
            if (string.IsNullOrEmpty(companyPeriod.Text.Trim()))
            {
                XtraMessageBox.Show("Şirket periyod kutusu boş geçilemez", "Hatalı Şirket Periyod Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyPeriod.Focus();
                return false;
            }
            else if (!companyPeriod.Text.Trim().All(char.IsDigit))
            {
                XtraMessageBox.Show("Şirket periyod sadece sayısal karakterlerden oluşmalıdır", "Hatalı Şirket Periyod Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyPeriod.Focus();
                return false;
            }
            else if (companyPeriod.Text.Trim().Length > 10)
            {
                XtraMessageBox.Show("Şirket periyod 10 karakterden fazla olamaz", "Hatalı Şirket Periyod Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyPeriod.Focus();
                return false;
            }
            #endregion

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
            return true;
        }
    }
}