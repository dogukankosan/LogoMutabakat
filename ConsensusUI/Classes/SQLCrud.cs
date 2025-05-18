using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsensusUI.Classes
{
    internal class SQLCrud
    {
        internal static async Task<bool> ConnectionStringControlAddWeb(string serverName, string loginName, string password, string databaseName, string webURL, TextEdit company)
        {
            string token = "";
            string passwordToken = "";
            string connectionString = $"Server={serverName};Database={databaseName};User Id ={loginName}; Password={password};Connection Timeout=10;TrustServerCertificate=True;Max Pool Size=100;Min Pool Size=5;Pooling=true;";
            SqlConnection sqLConnection = new SqlConnection(connectionString);
            try
            {
                await sqLConnection.OpenAsync();
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Hatalı Veri Tabanı Bağlantısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sqLConnection.Close();
            DataTable Customer = await SQLCrud.LoadDataIntoGridViewAsync("SELECT * FROM CustomersConsensus WITH (NOLOCK) WHERE CustomerName='" + company.Text.Trim() + "'", EncryptionHelper.Encrypt(connectionString));
            if (company.Enabled == true && Customer.Rows.Count > 0)
            {
                XtraMessageBox.Show("Bu Müşteri Daha Önce Kayıt Edilmiş", "Hatalı Veri Tabanı Bağlantısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (company.Enabled == true)
            {
                token = Guid.NewGuid().ToString("N");
                passwordToken = Guid.NewGuid().ToString("N");
                DataTable CustomerControl = await SQLCrud.LoadDataIntoGridViewAsync("SELECT * FROM CustomersConsensus WITH (NOLOCK) WHERE CustomerToken='" + token + "' AND CustomerPassword='" + passwordToken + "' ", EncryptionHelper.Encrypt(connectionString));
                if (CustomerControl.Rows.Count > 0)
                {
                    XtraMessageBox.Show("Oluşturulan Token Ve Password Daha Önce Kullanılmış", "Hatalı Veri Tabanı Bağlantısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                bool status = await SQLCrud.InserUpdateDelete("INSERT INTO CustomersConsensus (CustomerName,CustomerToken,CustomerPassword) VALUES ('" + company.Text.Trim() + "','" + token + "','" + passwordToken + "')", EncryptionHelper.Encrypt(connectionString));
                if (!status)
                {
                    XtraMessageBox.Show("Oluşturulan Token Ve Password Web Tarafında Hata Oluştu", "Hatalı Veri Tabanı Bağlantısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                var statusUpdate = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE WebSettings SET CompanyName='" + company.Text.Trim() + "' , WebToken='" + token + "' , WebPassword='" + passwordToken + "' , SQLConnectString='" + EncryptionHelper.Encrypt(connectionString) + "' ,WebAdres='" + webURL + "'");
                if (statusUpdate.Success)
                    XtraMessageBox.Show("Web Servis Bilgileri Güncelleme İşlemi Başarılı", "Başarılı Web Servis Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    return false;
            }
            else
            {
                var statusUpdateSQLite = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE WebSettings SET SQLConnectString='" + EncryptionHelper.Encrypt(connectionString) + "' ,WebAdres='" + webURL + "'");
                if (statusUpdateSQLite.Success)
                    XtraMessageBox.Show("Web Servis Bilgileri Güncelleme İşlemi Başarılı", "Başarılı Web Servis Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    return false;
            }
            return true;
        }
        internal static async Task<bool> ConnectionStringControlAddAsync(string serverName, string loginName, string password, string databaseName)
        {
            string connectionString = $"Server={serverName};Database={databaseName};User Id={loginName};Password={password};Connection Timeout=10;TrustServerCertificate=True;Max Pool Size=100;Min Pool Size=5;Pooling=true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                }
                catch (Exception ex)
                {
                    TextLog.TextLogging("SQL Connection Error: " + ex.Message + " --- " + ex.ToString(),"1");
                    return false;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            var result = await SQLiteCrud.InsertUpdateDeleteAsync(
       $"UPDATE SqlConnectionString SET SQLConnectString = '{EncryptionHelper.Encrypt(connectionString)}'");
            return result.Success;
        }
        internal static async Task<DataTable> LoadDataIntoGridViewAsync(string query, string connection)
        {
            using (SqlConnection conn = new SqlConnection(EncryptionHelper.Decrypt(connection)))
            {
                try
                {
                    await conn.OpenAsync();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            try
                            {
                                da.Fill(dt);
                            }
                            catch (Exception ex)
                            {
                                TextLog.TextLogging("DataAdapter.Fill hatası: " + ex.Message + " --- " + ex.ToString(),"1");
                                return null;
                            }
                        }
                    }
                    return dt;
                }
                catch (Exception e)
                {
                    TextLog.TextLogging("SQL bağlantı veya komut hatası: " + e.Message + " --- " + e.ToString(),"1");
                    return null;
                }
            }
        }
        internal static async Task<bool> InserUpdateDelete(string query, string connection)
        {
            using (SqlConnection conn = new SqlConnection(EncryptionHelper.Decrypt(connection)))
            {
                try
                {
                    await conn.OpenAsync();
                    string[] commands = query.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string command in commands)
                    {
                        string cleanCommand = command.Replace("\n", " ").Replace("\r", " ").Trim();
                        if (!string.IsNullOrWhiteSpace(cleanCommand))
                        {
                            using (SqlCommand cmd = new SqlCommand(cleanCommand, conn))
                            {
                                cmd.CommandTimeout = 300;
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    TextLog.TextLogging(ex.Message + " --- " + ex.ToString(),"1");
                    return false;
                }
            }
        }
        internal static async Task<int> InsertAndReturnIDAsync(string connectionString, string customerID, byte[] pdfBytes, string sendType,int source)
        {
            int insertedID = 0;
            string query = @"INSERT INTO Conseus (SourceRef,CustomerID, PDFFile, SendDate, SendType)
                     VALUES (@SourceRef,@CustomerID, @PDFFile, @SendDate, @SendType);
                     SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SourceRef", source);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.Add("@PDFFile", SqlDbType.VarBinary).Value = (object)pdfBytes ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@SendDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SendType", sendType);

                    await conn.OpenAsync();
                    object result = await cmd.ExecuteScalarAsync();
                    if (result != null)
                        insertedID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging("INSERT INTO Conseus hatası: " + ex.Message + " -- " + ex.ToString(),"1");
            }
            return insertedID;
        }
    }
}