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
                    cmb_pinjam_user.ValueMember = "IDUser";    
                    cmb_pinjam_user.SelectedIndex = -1;         // Kosongkan pilihan saat awal
                }
                catch (Exception ex) { MessageBox.Show("Gagal memuat data pengguna: " + ex.Message); }
            }
        }

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

                    // NOTE: Pencatatan Log PINJAM sebelumnya diproses manual di sini, 
                    // sekarang di pindah ke databaase 
                    // menggunakan trigger 'trg_Transaksi_InsertLog' pada tabel 'Transaksi'.

                    MessageBox.Show($"Barang {cmb_pinjam_barang.Text} berhasil dipinjamkan kepada {cmb_pinjam_user.Text}.", "Transaksi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // refresh seluruh tampilan agar stok terbaru dan tabel terbarui
                    RefreshSemuaData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kegagalan integrasi database: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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