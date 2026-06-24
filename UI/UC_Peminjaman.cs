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
    public partial class UC_Peminjaman : Form
    {
        Koneksi db = new Koneksi();

        public UC_Peminjaman()
        {
            InitializeComponent();
        }

        // =========================================================================
        // ENGINE AWAL: Menarik data master ke dalam memori aplikasi
        // =========================================================================
        private void UC_Peminjaman_Load(object sender, EventArgs e)
        {
            RefreshSemuaData();
        }

        private void RefreshSemuaData()
        {
            LoadComboBoxUser();
            LoadComboBoxBarang();
            LoadDataTransaksiAktif();
        }

        // =========================================================================
        // PIPELINE 1: Mengisi ComboBox Peminjam dari Data User
        // =========================================================================
        private void LoadComboBoxUser()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetDataGridViewUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    cmb_pinjam_user.DataSource = dt;
                    cmb_pinjam_user.DisplayMember = "NamaUser"; // Teks yang diketik/dilihat penjaga
                    cmb_pinjam_user.ValueMember = "IDUser";     // Kunci rahasia yang dikirim ke database
                    cmb_pinjam_user.SelectedIndex = -1;         // Kosongkan pilihan saat awal
                }
                catch (Exception ex) { MessageBox.Show("Gagal memuat data pengguna: " + ex.Message); }
            }
        }

        // =========================================================================
        // PIPELINE 2: Mengisi ComboBox Barang (Hanya yang stoknya > 0)
        // =========================================================================
        private void LoadComboBoxBarang()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetBarangTersedia", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    cmb_pinjam_barang.DataSource = dt;
                    cmb_pinjam_barang.DisplayMember = "NamaBarang";
                    cmb_pinjam_barang.ValueMember = "IDBarang";
                    cmb_pinjam_barang.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Gagal memuat katalog barang: " + ex.Message); }
            }
        }

        // =========================================================================
        // PIPELINE 3: Memuat Riwayat Transaksi yang Sedang Aktif
        // =========================================================================
        private void LoadDataTransaksiAktif()
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

                    // Menyaring agar tabel hanya menampilkan barang yang statusnya 'Dipinjam'
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "StatusTrans = 'Dipinjam'";

                    dgv_Peminjaman.DataSource = dv;
                    dgv_Peminjaman.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show("Gagal memuat tabel peminjaman: " + ex.Message); }
            }
        }

        // =========================================================================
        // CORE TRANSACTION: Validasi, Potong Stok, dan Pencatatan Log Operasional
        // =========================================================================
        private void btn_proses_pinjam_Click(object sender, EventArgs e)
        {
            // Validasi mutlak agar penjaga tidak bisa melanjutkan transaksi jika data kosong
            if (cmb_pinjam_user.SelectedValue == null || cmb_pinjam_barang.SelectedValue == null)
            {
                MessageBox.Show("Sistem menolak transaksi. Pastikan Anda memilih Nama Peminjam dan Barang dari daftar yang tersedia!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();

                    // 1. Eksekusi Peminjaman Pokok (Memotong stok dan menambah tanggungan)
                    using (SqlCommand cmd = new SqlCommand("sp_InsertPeminjaman", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDBarang", cmb_pinjam_barang.SelectedValue);
                        cmd.Parameters.AddWithValue("@IDUser", cmb_pinjam_user.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Mengambil ID Transaksi yang baru saja dibuat
                    int lastTransID = 0;
                    using (SqlCommand cmdId = new SqlCommand("SELECT MAX(IDTransaksi) FROM Transaksi", conn))
                    {
                        lastTransID = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    // 3. Pencatatan Audit ke Log Transaksi
                    using (SqlCommand cmdLog = new SqlCommand("sp_InsertLogTransaksi", conn))
                    {
                        cmdLog.CommandType = CommandType.StoredProcedure;
                        cmdLog.Parameters.AddWithValue("@IDTransaksi", lastTransID);
                        cmdLog.Parameters.AddWithValue("@Aksi", "PINJAM");
                        cmdLog.Parameters.AddWithValue("@IDBarang", cmb_pinjam_barang.SelectedValue);
                        cmdLog.Parameters.AddWithValue("@IDUser", cmb_pinjam_user.SelectedValue);
                        cmdLog.Parameters.AddWithValue("@Keterangan", "Meminjam barang: " + cmb_pinjam_barang.Text);
                        cmdLog.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Barang {cmb_pinjam_barang.Text} berhasil dipinjamkan kepada {cmb_pinjam_user.Text}.", "Transaksi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Segarkan seluruh tampilan agar stok terbaru dan tabel terbarui
                    RefreshSemuaData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kegagalan integrasi database: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        // KENDALI NAVIGASI: Kembali ke antarmuka utama penjaga
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

        private void cmb_pinjam_user_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}