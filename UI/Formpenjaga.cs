using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ucp_pabd_lab.DAL; 

namespace Ucp_pabd_lab.UI
{
    public partial class Formpenjaga : Form
    {
        Koneksi db = new Koneksi(); 
        private int idBarangTerpilih = -1;
        private int idTransaksiTerpilih = -1;

        public Formpenjaga()
        {
            InitializeComponent();
        }

        private void Formpenjaga_Load(object sender, EventArgs e)
        {
            LoadDataBarang();
            LoadDataTransaksiAktif();
            LoadLogTransaksi();
        }

        // Load data

        private void LoadDataBarang()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    string query = "SELECT IDBarang, NamaBarang, Stok, Kondisi FROM Barang WHERE Stok > 0";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_Peminjaman.DataSource = dt; 
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void LoadDataTransaksiAktif()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    string query = @"SELECT t.IDTransaksi, b.NamaBarang, u.NamaUser, t.TanggalPinjam 
                                     FROM Transaksi t 
                                     JOIN Barang b ON t.IDBarang = b.IDBarang 
                                     JOIN UserLab u ON t.IDUser = u.IDUser 
                                     WHERE t.StatusTrans = 'Dipinjam'";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_pengembalian.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void LoadLogTransaksi()
        {
            using (SqlConnection conn = db.GetConn())
            {
                string query = "SELECT * FROM Transaksi ORDER BY TanggalPinjam DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_log_trs.DataSource = dt;
            }
        }

        // kurang stok(peminjaman)

        private void dgv_Peminjaman_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idBarangTerpilih = Convert.ToInt32(dgv_Peminjaman.Rows[e.RowIndex].Cells["IDBarang"].Value);
                txt_pinjaman_barang.Text = dgv_Peminjaman.Rows[e.RowIndex].Cells["NamaBarang"].Value.ToString();
            }
        }

        private void btn_pinjamkan_Click(object sender, EventArgs e)
        {
            if (idBarangTerpilih == -1 || string.IsNullOrWhiteSpace(txt_pinjaman_nama.Text))
            {
                MessageBox.Show("Pilih barang dan isi nama peminjam!");
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); 
                try
                {
                    // 1. Cari IDUser .executescalar
                    string getUser = "SELECT IDUser FROM UserLab WHERE NamaUser = @nama";
                    SqlCommand cmdUser = new SqlCommand(getUser, conn, transaction);
                    cmdUser.Parameters.AddWithValue("@nama", txt_pinjaman_nama.Text);
                    object userId = cmdUser.ExecuteScalar();

                    if (userId == null) throw new Exception("Nama User tidak terdaftar!");

                    // simpan transaksi
                    string insTrans = "INSERT INTO Transaksi (IDBarang, IDUser, TanggalPinjam, StatusTrans) VALUES (@idB, @idU, GETDATE(), 'Dipinjam')";
                    SqlCommand cmdIns = new SqlCommand(insTrans, conn, transaction);
                    cmdIns.Parameters.AddWithValue("@idB", idBarangTerpilih);
                    cmdIns.Parameters.AddWithValue("@idU", userId);
                    cmdIns.ExecuteNonQuery();

                    // 3. Update Stok Barang (Stok - 1)
                    string updStok = "UPDATE Barang SET Stok = Stok - 1 WHERE IDBarang = @idB";
                    SqlCommand cmdStok = new SqlCommand(updStok, conn, transaction);
                    cmdStok.Parameters.AddWithValue("@idB", idBarangTerpilih);
                    cmdStok.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Peminjaman Berhasil!");
                    LoadDataBarang();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Gagal: " + ex.Message);
                }
            }
        }

        //pengembalian

        private void dgv_pengembalian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idTransaksiTerpilih = Convert.ToInt32(dgv_pengembalian.Rows[e.RowIndex].Cells["IDTransaksi"].Value);
                txt_pengembalian_nama.Text = dgv_pengembalian.Rows[e.RowIndex].Cells["NamaUser"].Value.ToString();
            }
        }

        private void btn_kembalikan_Click(object sender, EventArgs e)
        {
            if (idTransaksiTerpilih == -1) return;

            using (SqlConnection conn = db.GetConn())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                   
                    string updTrans = "UPDATE Transaksi SET StatusTrans = 'Kembali', TanggalKembali = GETDATE() WHERE IDTransaksi = @idT";
                    SqlCommand cmdUpd = new SqlCommand(updTrans, conn, transaction);
                    cmdUpd.Parameters.AddWithValue("@idT", idTransaksiTerpilih);
                    cmdUpd.ExecuteNonQuery();

                    string updStok = "UPDATE Barang SET Stok = Stok + 1 WHERE IDBarang = (SELECT IDBarang FROM Transaksi WHERE IDTransaksi = @idT)";
                    SqlCommand cmdStok = new SqlCommand(updStok, conn, transaction);
                    cmdStok.Parameters.AddWithValue("@idT", idTransaksiTerpilih);
                    cmdStok.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Barang Telah Dikembalikan!");
                    LoadDataTransaksiAktif();
                    LoadDataBarang();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Gagal: " + ex.Message);
                }
            }
        }

        // logout

        private void linkLabel_penjaga_Logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Formlogin login = new Formlogin(); 
                login.Show();
                this.Hide(); 
            }
        }

       

        private void tab_peminjaman_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void btn_peminjam_tampil_Click(object sender, EventArgs e) => LoadDataBarang();
        private void btn_pengembalian_tampil_Click(object sender, EventArgs e) => LoadDataTransaksiAktif();
        private void linklable_log_refresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => LoadLogTransaksi();
    }
}