using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace ConsensusUI.Classes
{
    internal class ConsensusPDF
    {
        internal async static Task<byte[]> CreatePdfAsync(int customerLogicalRef, string customerName, string firstdate, string lastdate, int isTL, string date, decimal balance)
        {
            string companyName = "", companyAdres = "", companyVKN = "", companyPhone = "", companyMail = "", companyPicture = "";
            DataTable companyDT = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT LogoCompanyCode,LogoPeriod FROM CompanySettings LIMIT 1");
            DataTable sqlconnection = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            DataTable sqlQuery = new DataTable();
            if (isTL == 1)
            {
                sqlQuery = await SQLCrud.LoadDataIntoGridViewAsync($@"
SELECT 
    CASE 
        WHEN TRN.TRCURR = 0 THEN 'TL'
        WHEN TRN.TRCURR = 1 THEN 'USD'
        WHEN TRN.TRCURR = 17 THEN 'GBP'
        WHEN TRN.TRCURR = 20 THEN 'EUR'
        WHEN TRN.TRCURR = 5 THEN 'BEF'
        WHEN TRN.TRCURR = 11 THEN 'CHF'
        WHEN TRN.TRCURR = 13 THEN 'JPY'
        WHEN TRN.TRCURR = 17 THEN 'GBP'
        WHEN TRN.TRCURR = 51 THEN 'RUB'
        WHEN TRN.TRCURR = 53 THEN 'TRY'
        WHEN TRN.TRCURR = 160 THEN 'TL'
        WHEN TRN.TRCURR = 162 THEN 'AZN'
        WHEN TRN.TRCURR = 15 THEN 'KWD'
    END AS 'Döviz Türü',
    CONVERT(DECIMAL(20,2), ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN AMOUNT * (1 - SIGN) ELSE AMOUNT END), 0)) AS 'Borç',
    CONVERT(DECIMAL(20,2), ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN AMOUNT * SIGN ELSE AMOUNT END), 0)) AS 'Alacak',
    CONVERT(DECIMAL(20,2), ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN AMOUNT * (1 - SIGN) ELSE AMOUNT END), 0) - 
    ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN AMOUNT * SIGN ELSE AMOUNT END), 0)) AS 'TL Bakiye',
    CONVERT(DECIMAL(20,2), ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN TRNET * (1 - SIGN) ELSE TRNET END), 0)) AS 'Döviz Borç',
    CONVERT(DECIMAL(20,2), ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN TRNET * SIGN ELSE TRNET END), 0)) AS 'Döviz Alacak',
    CONVERT(DECIMAL(20,2), ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN TRNET * (1 - SIGN) ELSE TRNET END), 0) - 
    ISNULL(SUM(CASE WHEN ISNULL(PAIDINCASH, 0) = 0 THEN TRNET * SIGN ELSE TRNET END), 0)) AS 'Döviz Bakiye'
FROM LG_{companyDT.Rows[0]["LogoCompanyCode"]}_{companyDT.Rows[0]["LogoPeriod"]}_CLFLINE TRN WITH (NOLOCK)
RIGHT JOIN LG_{companyDT.Rows[0]["LogoCompanyCode"]}_CLCARD CL ON CL.LOGICALREF = TRN.CLIENTREF
WHERE TRN.STATUS = 0 AND TRN.CANCELLED = 0 AND TRN.TRCODE <> 12
AND CL.ACTIVE = 0 AND CL.LOGICALREF = {customerLogicalRef}
AND TRN.DATE_ BETWEEN CONVERT(DATETIME, '{firstdate}', 101) AND CONVERT(DATETIME, '{lastdate}', 101)
GROUP BY CL.CODE, CL.DEFINITION_, TRN.TRCURR", sqlconnection.Rows[0]["SQLConnectString"].ToString());
            }
            bool statusCompany = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM CompanyPDF LIMIT 1");
            if (statusCompany)
            {
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM CompanyPDF LIMIT 1");
                companyName = dt.Rows[0]["CompanyName"].ToString();
                companyAdres = dt.Rows[0]["CompanyAdress"].ToString();
                companyVKN = dt.Rows[0]["CompanyVKN"].ToString();
                companyPhone = dt.Rows[0]["CompanyPhone"].ToString();
                companyMail = dt.Rows[0]["CompanyMail"].ToString();
                companyPicture = dt.Rows[0]["CompanyPicture"].ToString();
            }
            using (MemoryStream stream = new MemoryStream())
            {
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Cari Mutabakat Mektubu";
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont headerFont = new XFont("Arial", 10, XFontStyle.Regular);
                XFont titleFont = new XFont("Arial", 14, XFontStyle.Bold);
                XFont normalFont = new XFont("Arial", 11, XFontStyle.Regular);
                XFont boldFont = new XFont("Arial", 11, XFontStyle.Bold);
                XFont boldUnderlineFont = new XFont("Arial", 11, XFontStyle.Bold | XFontStyle.Underline);
                int y = 40;
                if (!string.IsNullOrEmpty(companyPicture))
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(companyPicture);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            XImage logo = XImage.FromStream(ms);
                            gfx.DrawImage(logo, 40, 30, 100, 100);
                        }
                    }
                    catch (Exception ex)
                    {
                        TextLog.TextLogging("Logo base64 okunamadı: " + ex.Message,"1");
                    }
                }
                string tarihStr = DateTime.Now.ToString("dd MMMM yyyy dddd", new CultureInfo("tr-TR"));
                XFont underlineFont = new XFont("Arial", 10, XFontStyle.Underline);
               gfx.DrawString(tarihStr, underlineFont, XBrushes.Black, new XRect(0, y, page.Width - 50, 20), XStringFormats.TopRight);
                y += 70;
                gfx.DrawString("CARİ MUTABAKAT MEKTUBU", titleFont, XBrushes.Black, new XRect(0, y, page.Width, 30), XStringFormats.TopCenter);
                y += 30;
                gfx.DrawLine(XPens.Black, 50, y, page.Width - 50, y); y += 20;
                gfx.DrawString("SAYIN:  " + customerName, boldFont, XBrushes.Black, 50, y); y += 30;
                gfx.DrawString($"Mutabakat Tarihi: {date}", boldFont, XBrushes.Black, 50, y); y += 25;
                gfx.DrawString($"Şirketimiz nezdindeki cari hesabınız incelenmiş olup; {date} tarihi itibariyle bakiyeniz:", normalFont, XBrushes.Black, 50, y); y += 20;
                string bakiyeText = balance.ToString("N2", new CultureInfo("tr-TR")) + " ₺";
                gfx.DrawString(bakiyeText, boldFont, XBrushes.Black, 70, y);
                double bakiyeWidth = gfx.MeasureString(bakiyeText, boldFont).Width;
                string bakiyeDurum = balance >= 0 ? "Borç" : "Alacak";
                gfx.DrawString($"  {bakiyeDurum} bakiyesi olduğu tespit edilmiştir. Mutabık olup, olmadığınızı bildirmenizi rica ederiz.", normalFont, XBrushes.Black, 70 + bakiyeWidth, y);
                y += 40;
                if (sqlQuery.Rows.Count > 0)
                {
                    gfx.DrawString("Döviz Bazlı Hesap Özeti", boldUnderlineFont, XBrushes.Black, 30, y);
                    y += 25;
                    int startX = 1; 
                    int cellHeight = 22;
                    int[] columnWidths = { 70, 85, 85, 80, 90, 90, 90 };
                    int currentX = startX;
                    XSolidBrush headerBackground = new XSolidBrush(XColor.FromArgb(180, 200, 230));
                    for (int i = 0; i < sqlQuery.Columns.Count; i++)
                    {
                        gfx.DrawRectangle(XPens.Black, headerBackground, currentX, y, columnWidths[i], cellHeight);
                        gfx.DrawString(sqlQuery.Columns[i].ColumnName, boldFont, XBrushes.Black, new XRect(currentX + 4, y + 4, columnWidths[i], cellHeight), XStringFormats.TopLeft);
                        currentX += columnWidths[i];
                    }
                    y += cellHeight;
                    foreach (DataRow row in sqlQuery.Rows)
                    {
                        currentX = startX;
                        for (int i = 0; i < sqlQuery.Columns.Count; i++)
                        {
                            gfx.DrawRectangle(XPens.Black, currentX, y, columnWidths[i], cellHeight);

                            object cellValue = row[i];
                            string formattedValue;
                            if (cellValue is decimal || cellValue is double || cellValue is float || cellValue is int)
                            {
                                try
                                {
                                    formattedValue = string.Format("{0:#,##0.00}", Convert.ToDecimal(cellValue));
                                }
                                catch
                                {
                                    formattedValue = cellValue.ToString();
                                }
                            }
                            else
                                formattedValue = cellValue.ToString();
                            gfx.DrawString(formattedValue, normalFont, XBrushes.Black, new XRect(currentX + 4, y + 4, columnWidths[i], cellHeight), XStringFormats.TopLeft);
                            currentX += columnWidths[i];
                        }
                        y += cellHeight;
                    }
                    y += 30;
                }
                gfx.DrawRectangle(XBrushes.LightGray, 45, y - 15, page.Width - 90, 25);
                gfx.DrawString("NOTLAR :", boldFont, XBrushes.Black, 50, y); y += 30;
                gfx.DrawString("1- Mutabakat veya itirazınızı 15 (on beş) gün içinde bildirmediğiniz takdirde,", normalFont, XBrushes.Black, 50, y); y += 20;
                gfx.DrawString("    Türk Ticaret Kanunu’nun 94. maddesi gereğince mutabık sayılacağınızı hatırlatırız.", normalFont, XBrushes.Black, 50, y); y += 20;
                gfx.DrawString("2- Bakiyede mutabık olmadığınız takdirde;", normalFont, XBrushes.Black, 50, y); y += 20;
                gfx.DrawString("    Cari Hesap Ekstresini 15 günlük süre dolmadan, mutabakat mektubunu gönderen", normalFont, XBrushes.Black, 50, y); y += 20;
                gfx.DrawString("    ilgililere iade etmeniz veya durumu yazılı olarak bildirmeniz gerekmektedir.", normalFont, XBrushes.Black, 50, y); y += 20;
                gfx.DrawString("3- Mutabakat mektubuna itirazlarınızı noter, taahhütlü mektup, telgraf veya güvenli", normalFont, XBrushes.Black, 50, y); y += 20;
                gfx.DrawString("    elektronik imza içeren bir yazıyla bildirmeniz geçerlilik açısından önemlidir.", normalFont, XBrushes.Black, 50, y); y += 40;
                gfx.DrawString("Saygılarımızla", boldUnderlineFont, XBrushes.Black, 50, y); y += 40;
                gfx.DrawString($"Şirket Adı        :  {companyName}", normalFont, XBrushes.Black, 50, y); y += 20;
                gfx.DrawString($"Şirket VKN      :  {companyVKN}", normalFont, XBrushes.Black, 50, y); y += 20;
                string adresPrefix = "Şirket Adres    :  ";
                int maxLineLength = 70;
                if (companyAdres.Length <= maxLineLength)
                {
                    gfx.DrawString(adresPrefix + companyAdres, normalFont, XBrushes.Black, 50, y);
                    y += 20;
                }
                else
                {
                    gfx.DrawString(adresPrefix + companyAdres.Substring(0, maxLineLength), normalFont, XBrushes.Black, 50, y);
                    y += 20;
                    int startIndex = maxLineLength;
                    while (startIndex < companyAdres.Length)
                    {
                        int length = Math.Min(maxLineLength, companyAdres.Length - startIndex);
                        string linePart = companyAdres.Substring(startIndex, length);
                        gfx.DrawString(" ".PadLeft(adresPrefix.Length) + linePart, normalFont, XBrushes.Black, 50, y);
                        y += 20;
                        startIndex += length;
                    }
                }
                gfx.DrawString($"Şirket Mail       :  {companyMail}", normalFont, XBrushes.Black, 50, y); y += 20;
                gfx.DrawString($"Şirket Tel         :  {companyPhone}", normalFont, XBrushes.Black, 50, y); y += 20;
                gfx.DrawString($"Bu belge sistem tarafından otomatik olarak oluşturulmuştur.", headerFont, XBrushes.Gray,
                    new XRect(0, page.Height - 40, page.Width, 20), XStringFormats.Center);
                document.Save(stream, false);
                return await Task.FromResult(stream.ToArray());
            }
        }
    }
}
