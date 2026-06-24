using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Ucp_pabd_lab.DAL
{
    internal class Koneksi
    {

        public static string GetLocalIPAddress()
        {
            string localIP = string.Empty;
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting local IP address: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return localIP;
        }

        public static string GetConnectionString()
        {

            //string connectionString = $"Data Source={GetLocalIPAddress()};Initial Catalog=DBLabSekolah;User ID=sa;Password=PasswordSA;";
            
            // UNTUK LOCAL DEVELOPMENT
            // string connectionString = @"Data Source=DESKTOP-6V58GOQ\PUTRASQL;Initial Catalog=DBLabSekolah;Integrated Security=True";
             string connectionString = @"Data Source=DESKTOP-SCRRHRM;Initial Catalog=DBLabSekolah;Integrated Security=True";
            
            return connectionString;
        }

        public SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = GetConnectionString();
            return conn;
        }

        // 2. UserLab DAL 

        public string Login(string username, string password)
        {
            using (SqlConnection conn = GetConn())
            {
                string query = "SELECT RoleUser FROM UserLab WHERE NamaUser = @user AND Password = @pass";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        public DataTable GetUsers()
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDataGridViewUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void InsertUser(string namaUser, string roleUser, string password)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NamaUser", namaUser);
                    cmd.Parameters.AddWithValue("@RoleUser", roleUser);
                    cmd.Parameters.AddWithValue("@Password", password);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(string idUser, string namaUser, string roleUser, string password)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUser", idUser);
                    cmd.Parameters.AddWithValue("@NamaUser", namaUser);
                    cmd.Parameters.AddWithValue("@RoleUser", roleUser);
                    cmd.Parameters.AddWithValue("@Password", password);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(string idUser)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUser", idUser);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 3. Barang & Kategori 

        public DataTable GetBarang()
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDataGridViewBarang", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable GetKategori()
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetKategori", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void InsertBarang(string namaBarang, int idKategori, int stok, string kondisi)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertBarang", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NamaBarang", namaBarang);
                    cmd.Parameters.AddWithValue("@IDKategori", idKategori);
                    cmd.Parameters.AddWithValue("@Stok", stok);
                    cmd.Parameters.AddWithValue("@Kondisi", kondisi);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBarang(string idBarang, string namaBarang, int idKategori, int stok, string kondisi)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateBarang", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDBarang", idBarang);
                    cmd.Parameters.AddWithValue("@NamaBarang", namaBarang);
                    cmd.Parameters.AddWithValue("@IDKategori", idKategori);
                    cmd.Parameters.AddWithValue("@Stok", stok);
                    cmd.Parameters.AddWithValue("@Kondisi", kondisi);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBarang(string idBarang)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteBarang", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDBarang", idBarang);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. Transaksi & Log DAL 

        public DataTable GetBarangTersedia()
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetBarangTersedia", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable GetPeminjamanAktif()
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDataGridViewPinjam", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public object GetUserIDByName(string namaUser)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetUserIDByName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NamaUser", namaUser);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public void InsertPeminjaman(string idBarang, string idUser)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPeminjaman", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDBarang", idBarang);
                    cmd.Parameters.AddWithValue("@IDUser", idUser);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int GetLastTransactionID()
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MAX(IDTransaksi) FROM Transaksi", conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value && result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public void InsertLogTransaksi(int idTransaksi, string aksi, string idBarang, string idUser, string keterangan)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertLogTransaksi", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTransaksi", idTransaksi);
                    cmd.Parameters.AddWithValue("@Aksi", aksi);
                    cmd.Parameters.AddWithValue("@IDBarang", idBarang);
                    cmd.Parameters.AddWithValue("@IDUser", idUser);
                    cmd.Parameters.AddWithValue("@Keterangan", keterangan);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePengembalian(int idTransaksi, string idBarang, string idUser)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdatePengembalian", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTransaksi", idTransaksi);
                    cmd.Parameters.AddWithValue("@IDBarang", idBarang);
                    cmd.Parameters.AddWithValue("@IDUser", idUser);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetTransaksiDetails(string idTransaksi)
        {
            using (SqlConnection conn = GetConn())
            {
                string query = "SELECT IDBarang, IDUser FROM Transaksi WHERE IDTransaksi = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idTransaksi);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable GetLogTransaksi()
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetLogTransaksi", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable GetDataGridViewLog()
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDataGridViewLog", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
