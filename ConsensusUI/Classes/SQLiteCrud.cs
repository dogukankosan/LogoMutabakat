using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsensusUI.Classes
{
    internal class SQLiteCrud
    {
        internal static string connectionString = $"Data Source={Application.StartupPath}\\Database\\Settings.db;Version=3;";
        internal static async Task<DataTable> GetDataFromSQLiteAsync(string query)
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                            dataTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    TextLog.TextLogging(ex.Message + " ------- " + ex.ToString(),"1");
                    return null;
                }
            }
            return dataTable;
        }
        internal static async Task<(bool Success, string ErrorMessage)> InsertUpdateDeleteAsync(string query)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    await cmd.ExecuteNonQueryAsync();
                    return (true, null);
                }
                catch (Exception ex)
                {
                    TextLog.TextLogging(ex.Message + " ---  " + ex.ToString(),"1");
                    return (false, ex.Message);
                }
            }
        }
        internal static async Task<bool> ConnectionStringControlAdd(string serverName, string loginName, string password, string databaseName)
        {
            string connectionString = $"Server={serverName};Database={databaseName};User Id={loginName};Password={password};Connection Timeout=10;TrustServerCertificate=True;Max Pool Size=100;Min Pool Size=5;Pooling=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                await sqlConnection.OpenAsync();
            }
            catch (Exception ex)
            {
                TextLog.TextLogging(ex.Message + " --- " + ex.ToString(),"1");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            string encryptedConnectionString = EncryptionHelper.Encrypt(connectionString);
            var statusDb = await SQLiteCrud.InsertUpdateDeleteAsync($"UPDATE SqlConnectionString SET SQLConnectString='{encryptedConnectionString}'");
            if (!statusDb.Success)
                return false;
            return true;
        }
        internal static async Task<int> InsertAndReturnIDSQLiteAsync(int customerID, int sendType, int conMonth, int conYear, byte[] pdfData)
        {
            int insertedID = 0;
            string query = @"
        INSERT INTO Consensus (CustomerID, SendType, SendDate, ConMonth, ConYear, PDFFile)
        VALUES (@CustomerID, @SendType, datetime('now', 'localtime'), @ConMonth, @ConYear, @PDFFile);
        SELECT last_insert_rowid();";
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerID);
                    command.Parameters.AddWithValue("@SendType", sendType);
                    command.Parameters.AddWithValue("@ConMonth", conMonth);
                    command.Parameters.AddWithValue("@ConYear", conYear);
                    command.Parameters.Add("@PDFFile", DbType.Binary).Value = (object)pdfData ?? DBNull.Value;
                    await connection.OpenAsync();
                    object result = await command.ExecuteScalarAsync();
                    if (result != null)
                        insertedID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging("INSERT INTO SQLite Consensus hatası: " + ex.Message + " -- " + ex.ToString(),"1");
            }
            return insertedID;
        }

    }
}