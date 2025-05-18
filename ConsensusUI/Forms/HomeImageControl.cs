using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ConsensusUI.Business;
using ConsensusUI.Classes;
using DevExpress.XtraCharts;

namespace ConsensusUI.Forms
{
    public partial class HomeImageControl : UserControl
    {
        public HomeImageControl()
        {
            InitializeComponent();
        }
        private async void ChartGraf()
        {
            try
            {
                string query = @"
        SELECT 
            CASE CAST(ConMonth AS INTEGER)
                WHEN 1 THEN 'Ocak'
                WHEN 2 THEN 'Şubat'
                WHEN 3 THEN 'Mart'
                WHEN 4 THEN 'Nisan'
                WHEN 5 THEN 'Mayıs'
                WHEN 6 THEN 'Haziran'
                WHEN 7 THEN 'Temmuz'
                WHEN 8 THEN 'Ağustos'
                WHEN 9 THEN 'Eylül'
                WHEN 10 THEN 'Ekim'
                WHEN 11 THEN 'Kasım'
                WHEN 12 THEN 'Aralık'
                ELSE 'Bilinmeyen'
            END AS Ay,
            COUNT(*) AS MutabakatSayisi
        FROM Consensus 
        GROUP BY ConMonth
        ORDER BY CAST(ConMonth AS INTEGER)";
                DataTable salesData = await SQLiteCrud.GetDataFromSQLiteAsync(query);
                chartControl1.Series.Clear();
                if (salesData.Rows.Count == 0)
                    return;
                Series series = new Series("Gönderilen Mutabakatlar", ViewType.Bar);
                foreach (DataRow row in salesData.Rows)
                    series.Points.Add(new SeriesPoint(row["Ay"], row["MutabakatSayisi"]));
                chartControl1.Series.Add(series);
                if (chartControl1.Diagram is XYDiagram diagram)
                    diagram.AxisX.Label.TextPattern = "{A}";
                chartControl1.Titles.Clear();
                chartControl1.Titles.Add(new ChartTitle
                {
                    Text = "Aylara Göre Mutabakat Sayıları"
                });
                series.ToolTipPointPattern = "Ay: {A}\nSayı: {V}";
                series.View.Color = Color.SteelBlue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grafik oluşturulurken bir hata oluştu:\n" + ex.Message);
            }
        }
        private async void GrafPie()
        {
            try
            {
                string querySendType = @"
        SELECT 
            CASE CAST(SendType AS INTEGER)
                WHEN 0 THEN 'Mail'
                WHEN 1 THEN 'Whatsapp'
                ELSE 'Diğer'
            END AS GönderimTipi,
            COUNT(*) AS Sayi
        FROM Consensus
        GROUP BY SendType";
                DataTable sendTypeData = await SQLiteCrud.GetDataFromSQLiteAsync(querySendType);
                chartControl2.Series.Clear();
                if (sendTypeData.Rows.Count == 0)
                    return;
                Series pieSeries = new Series("Gönderim Dağılımı", ViewType.Pie);
                foreach (DataRow row in sendTypeData.Rows)
                    pieSeries.Points.Add(new SeriesPoint(row["GönderimTipi"], row["Sayi"]));
                chartControl2.Series.Add(pieSeries);
                if (pieSeries.View is PieSeriesView pieView)
                {
                    foreach (SeriesPoint point in pieSeries.Points)
                    {
                        if (point.Argument?.ToString() == "Mail")
                        {
                            pieView.ExplodedPoints.Add(point);
                            break;
                        }
                    }
                    pieView.ExplodeMode = PieExplodeMode.UsePoints;
                }
                pieSeries.Label.TextPattern = "{A}: {VP:p}";
                pieSeries.ToolTipPointPattern = "Gönderim Tipi: {A}\nAdet: {V}\nOran: {VP:p}";
                chartControl2.Titles.Clear();
                chartControl2.Titles.Add(new ChartTitle { Text = "Gönderim Tipi Dağılımı" });
                chartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pie grafik oluşturulurken hata oluştu:\n" + ex.Message);
            }
        }
        private async void HomeImageControl_Load(object sender, EventArgs e)
        {
            bool sqlStatus = await UtilityHelper.IsDataExistsSQLite("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            if (!sqlStatus)
                return;
            bool webStatus = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM WebSettings LIMIT 1");
            if (!webStatus)
                return;
            bool companyStatus = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM CompanySettings LIMIT 1");
            if (!companyStatus)
                return;
            DataTable companyData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT LogoCompanyCode FROM CompanySettings LIMIT 1");
            DataTable sqlconnection = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            DataTable webData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT CompanyName,WebToken,WebPassword,SQLConnectString FROM WebSettings LIMIT 1");
            string sqlConnStr = sqlconnection.Rows[0]["SQLConnectString"].ToString();
            string companyCode = companyData.Rows[0]["LogoCompanyCode"].ToString();
            DataTable webCustomerID = await SQLCrud.LoadDataIntoGridViewAsync($@"
        SELECT TOP 1 ID 
        FROM CustomersConsensus WITH (NOLOCK)
        WHERE CustomerName = '{webData.Rows[0]["CompanyName"]}'
          AND CustomerToken = '{webData.Rows[0]["WebToken"]}'
          AND CustomerPassword = '{webData.Rows[0]["WebPassword"]}' 
    ", webData.Rows[0]["SQLConnectString"].ToString());
            string webCustomerIDValue = webCustomerID.Rows[0]["ID"].ToString();
            lbl_WaitCons.Text = await ReportHelper.GetPendingCountAsync(webCustomerIDValue, webData.Rows[0]["SQLConnectString"].ToString());
            lbl_unreadCancel.Text = await ReportHelper.GetUnreadRejectedCountAsync(webCustomerIDValue, webData.Rows[0]["SQLConnectString"].ToString());
            lbl_UnReadApprove.Text = await ReportHelper.GetUnreadApprovedCountAsync(webCustomerIDValue, webData.Rows[0]["SQLConnectString"].ToString());
            lbl_MonthCons.Text = await ReportHelper.GetCurrentMonthConsensusCountAsync();
            lbl_TotalCountCons.Text = await ReportHelper.GetTotalConsensusCountAsync();
            lbl_TotalApprove.Text = await ReportHelper.GetTotalApproveCountAsync(webCustomerIDValue, webData.Rows[0]["SQLConnectString"].ToString());
            lblCancelTotalCount.Text = await ReportHelper.GetCancelTotalCountAsync(webCustomerIDValue, webData.Rows[0]["SQLConnectString"].ToString());
            lbl_MonthName.Text = await ReportHelper.GetLastMonthNameAsync();
            lbl_NowMonthCancel.Text = await ReportHelper.GetCurrentMonthRejectedCountAsync(webCustomerIDValue, webData.Rows[0]["SQLConnectString"].ToString());
            ChartGraf();
            GrafPie();
        }
    }
}
