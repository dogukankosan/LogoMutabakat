using ConsensusUI.Classes;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ConsensusUI.Business
{
    public static class ReportHelper
    {
        internal static async Task<DataTable> GetConsensusTableAsync(bool onlyUnread = false)
        {
            string query = onlyUnread
                ? @"SELECT ID AS 'KayıtNo', CustomerID AS 'CariReferansNo' FROM Consensus WHERE Read=0"
                : @"SELECT ID AS 'KayıtNo', CustomerID AS 'CariReferansNo' FROM Consensus";
            return await SQLiteCrud.GetDataFromSQLiteAsync(query);
        }
        internal static async Task<DataTable> GetWebConsensusTableAsync(string webCustomerID, string responseFilter, string connection)
        {
            string query = $@"
            SELECT SourceRef, ResponseMessage FROM Conseus WITH (NOLOCK)
            WHERE CustomerID = {webCustomerID} {responseFilter}";
            return await SQLCrud.LoadDataIntoGridViewAsync(query, connection);
        }
        internal static int GetJoinedCount(DataTable local, DataTable web, Func<DataRow, bool> filter)
        {
            var result = from localRow in local.AsEnumerable()
                         join webRow in web.AsEnumerable()
                         on Convert.ToInt32(localRow["KayıtNo"]) equals Convert.ToInt32(webRow["SourceRef"])
                         where filter(webRow)
                         select webRow;
            return result.Count();
        }
        internal static async Task<string> GetCancelTotalCountAsync(string webCustomerID, string connection)
        {
            var local = await GetConsensusTableAsync();
            var web = await GetWebConsensusTableAsync(webCustomerID, "AND ResponseMessage LIKE 'Reddedildi:%'", connection);
            return GetJoinedCount(local, web, row => !string.IsNullOrWhiteSpace(row.Field<string>("ResponseMessage"))).ToString();
        }
        internal static async Task<string> GetTotalApproveCountAsync(string webCustomerID, string connection)
        {
            var local = await GetConsensusTableAsync();
            var web = await GetWebConsensusTableAsync(webCustomerID, "AND ResponseMessage LIKE 'Onaylandı%'", connection);
            return GetJoinedCount(local, web, row => !string.IsNullOrWhiteSpace(row.Field<string>("ResponseMessage"))).ToString();
        }
        internal static async Task<string> GetPendingCountAsync(string webCustomerID, string connection)
        {
            var local = await GetConsensusTableAsync();
            var web = await GetWebConsensusTableAsync(webCustomerID, "AND ResponseMessage IS NULL", connection);
            return GetJoinedCount(local, web, row => string.IsNullOrWhiteSpace(row.Field<string>("ResponseMessage"))).ToString();
        }
        internal static async Task<string> GetUnreadRejectedCountAsync(string webCustomerID, string connection)
        {
            var local = await GetConsensusTableAsync(true);
            var web = await GetWebConsensusTableAsync(webCustomerID, "AND ResponseMessage LIKE 'Reddedildi:%'", connection);
            return GetJoinedCount(local, web, row => !string.IsNullOrWhiteSpace(row.Field<string>("ResponseMessage"))).ToString();
        }
        internal static async Task<string> GetUnreadApprovedCountAsync(string webCustomerID, string connection)
        {
            var local = await GetConsensusTableAsync(true);
            var web = await GetWebConsensusTableAsync(webCustomerID, "AND ResponseMessage LIKE '%Onaylandı%'", connection);
            return GetJoinedCount(local, web, row => !string.IsNullOrWhiteSpace(row.Field<string>("ResponseMessage"))).ToString();
        }
        internal static async Task<string> GetCurrentMonthConsensusCountAsync()
        {
            var dt = await SQLiteCrud.GetDataFromSQLiteAsync(@"
            SELECT COUNT(*) AS GonderilenMutabakatSayisi
            FROM Consensus
            WHERE strftime('%Y-%m', SendDate) = strftime('%Y-%m', 'now', 'localtime')");
            return dt.Rows[0][0].ToString();
        }
        internal static async Task<string> GetTotalConsensusCountAsync()
        {
            try
            {
                var dt = await SQLiteCrud.GetDataFromSQLiteAsync(@"SELECT COUNT(*) FROM Consensus");
                return dt?.Rows[0][0]?.ToString() ?? "0";
            }
            catch (Exception ex)
            {
                TextLog.TextLogging("GetTotalConsensusCountAsync Error: " + ex.Message);
                return "0";
            }
        }
        internal static async Task<string> GetLastMonthNameAsync()
        {
            try
            {
                var dt = await SQLiteCrud.GetDataFromSQLiteAsync(@"
                SELECT 
                    CASE ConMonth
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
                        ELSE 'Bilinmiyor'
                    END AS AyAdi
                FROM Consensus
                ORDER BY ConYear DESC, ConMonth DESC
                LIMIT 1");
                return dt.Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }
        internal static async Task<string> GetCurrentMonthRejectedCountAsync(string webCustomerID, string connection)
        {
            string currentMonthFilter = @"
        AND FORMAT(SendDate, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')";
            var local = await GetConsensusTableAsync();
            var web = await GetWebConsensusTableAsync(webCustomerID,
                $"AND ResponseMessage LIKE 'Reddedildi:%' {currentMonthFilter}", connection);
            return GetJoinedCount(local, web, row =>
                !string.IsNullOrWhiteSpace(row.Field<string>("ResponseMessage"))).ToString();
        }
    }
}