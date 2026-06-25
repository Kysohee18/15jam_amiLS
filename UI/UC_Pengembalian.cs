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
    public partial class UC_Pengembalian : Form
    {
        Koneksi db = new Koneksi();

        private string idTransaksiTerpilih = "";
        private string idBarangTerpilih = "";
        private string idUserTerpilih = "";

        public UC_Pengembalian()
        {
            InitializeComponent();
            
            // Mengatur textbox nama dan barang agar Read-Only (penjaga tidak boleh input manual)
            txt_nama_ucp.ReadOnly = true;
            txt_NamaBarang_ucp.ReadOnly = true;
            
            // Menghubungkan event click tombol cari ke fungsi pencarian
            btn_search_ucp.Click += btn_search_ucp_Click;
        }

        private void UC_Pengembalian_Load(object sender, EventArgs e)
        {
            RefreshTabelPengembalian();
        }

        private void RefreshTabelPengembalian()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetDataGridViewPinjam", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    DataView dv = new DataView(dt);
                    dv.RowFilter = "StatusTrans = 'Dipinjam'";

                    dgv_pengembalian.DataSource = dv;
                    dgv_pengembalian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    KosongkanValidasi();
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show("Gagal memuat tabel pengembalian: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
        }

        private void KosongkanValidasi()
        {
            txt_nama_ucp.Clear();
            txt_NamaBarang_ucp.Clear();

            idTransaksiTerpilih = "";
            idBarangTerpilih = "";
            idUserTerpilih = "";
        }

        private void dgv_pengembalian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_pengembalian.Rows[e.RowIndex];

                txt_nama_ucp.Text = row.Cells["NamaUser"].Value.ToString();
                txt_NamaBarang_ucp.Text = row.Cells["NamaBarang"].Value.ToString();
                idTransaksiTerpilih = row.Cells["IDTransaksi"].Value.ToString();

                // Melacak ID Asli untuk Barang dan User
                using (SqlConnection conn = db.GetConn())
                {
                    try
                    {
                        conn.Open();
                        string queryLacak = "SELECT IDBarang, IDUser FROM Transaksi WHERE IDTransaksi = @ID";
                        using (SqlCommand cmd = new SqlCommand(queryLacak, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", idTransaksiTerpilih);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                idBarangTerpilih = dr["IDBarang"].ToString();
                                idUserTerpilih = dr["IDUser"].ToString();
                            }
                        }
                    }
                    catch (Exception ex) 
                    { 
                        MessageBox.Show("Gagal melacak entitas transaksi: " + ex.Message); 
                    }
                }
            }
        }

        // =========================================================================
        // CORE TRANSACTION: Eksekusi Pengembalian Stok
        // =========================================================================
        private void btn_kembalikan_Click(object sender, EventArgs e)
        {
            // Validasi menggunakan memori siluman
            if (string.IsNullOrEmpty(idTransaksiTerpilih) || string.IsNullOrEmpty(idBarangTerpilih))
            {
                MessageBox.Show("Silakan klik salah satu transaksi pada tabel terlebih dahulu!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show($"Konfirmasi pengembalian barang '{txt_NamaBarang_ucp.Text}' oleh peminjam '{txt_nama_ucp.Text}'?", "Verifikasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                using (SqlConnection conn = db.GetConn())
                {
                    try
                    {
                        conn.Open();

                        // 1. Eksekusi SP Pengembalian Utama
                        using (SqlCommand cmd = new SqlCommand("sp_UpdatePengembalian", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IDTransaksi", idTransaksiTerpilih);
                            cmd.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);
                            cmd.Parameters.AddWithValue("@IDUser", idUserTerpilih);
                            cmd.ExecuteNonQuery();
                        }

                        // NOTE: Pencatatan Log KEMBALI sekarang diproses otomatis oleh SQL Trigger 'trg_Transaksi_UpdateLog'.

                        MessageBox.Show("Barang berhasil dikembalikan dan stok telah ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshTabelPengembalian();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kegagalan database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================================================================
        // SEARCH FUNCTION: Menyaring isi DataGridView berdasarkan Nama Peminjam
        // =========================================================================
        private void btn_search_ucp_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = (DataView)dgv_pengembalian.DataSource;
                if (dv != null)
                {
                    string filter = txt_cari_ucp.Text.Trim().Replace("'", "''");
                    dv.RowFilter = $"StatusTrans = 'Dipinjam' AND NamaUser LIKE '%{filter}%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyaring data peminjaman: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // NAVIGASI KEMBALI
        // =========================================================================
        private void btn_kembali_Click(object sender, EventArgs e)
        {
            Formpenjaga penjaga = (Formpenjaga)Application.OpenForms["Formpenjaga"];
            if (penjaga != null)
            {
                penjaga.Show();
            }
            this.Close();
        }
    }
}