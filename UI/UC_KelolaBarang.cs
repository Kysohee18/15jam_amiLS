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
    public partial class UC_KelolaBarang : Form
    {
        Koneksi db = new Koneksi();

        private string idBarangTerpilih = "";
        
        public UC_KelolaBarang()
        {
            InitializeComponent();
        }

        private void UC_KelolaBarang_Load(object sender, EventArgs e)
        {
            // ini untuk mengisi data ke dalam tabel Barang saat form dimuat
            this.barangTableAdapter.Fill(this.dBLabSekolahDataSet.Barang);
            LoadKategori();   
            LoadDataBarang(); 
        }

        
        private void LoadKategori()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetKategori", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    cmb_klbr_kategori.DataSource = dt;
                    cmb_klbr_kategori.DisplayMember = "NamaKategori"; 
                    cmb_klbr_kategori.ValueMember = "IDKategori";     
                    cmb_klbr_kategori.SelectedIndex = -1;             
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengambil data kategori: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void LoadDataBarang()
        {
            // changes: agar binding navigator bisa sinkron

            try
            {
                this.barangTableAdapter.Fill(this.dBLabSekolahDataSet.Barang);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem gagal menyinkronkan Binding Navigator: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetDataGridViewBarang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgv_kelolabarang.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal merender tabel barang: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //insert data barang baru ke database dengan menggunakan stored procedure
        private void btn_klbr_simpan_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txt_klbr_nama.Text) ||
                string.IsNullOrWhiteSpace(txt_klbr_stok.Text) ||
                cmb_klbr_kategori.SelectedValue == null ||
                string.IsNullOrWhiteSpace(cmb_admin_kondisi.Text))
            {
                MessageBox.Show("Seluruh baris parameter input wajib terisi, jangan dikosongkan!", "Validasi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertBarang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Mengirimkan parameter ke Stored Procedure secara aman
                    cmd.Parameters.AddWithValue("@NamaBarang", txt_klbr_nama.Text.Trim());
                    cmd.Parameters.AddWithValue("@IDKategori", cmb_klbr_kategori.SelectedValue);
                    cmd.Parameters.AddWithValue("@Stok", int.Parse(txt_klbr_stok.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Kondisi", cmb_admin_kondisi.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Injeksi data barang baru berhasil diproses oleh Stored Procedure.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    btn_klbr_refresh_Click(sender, e);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Kolom input Stok hanya menerima tipe data angka integer bulat!", "Tipe Data Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi masalah pada transaksi database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgv_kelolabarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_kelolabarang.Rows[e.RowIndex];

                idBarangTerpilih = row.Cells[0].Value.ToString();

                // agar binding navigator bisa sinkron sama data yg di pilih di dgv
                int index = barangBindingSource.Find("IDBarang", idBarangTerpilih);
                if (index >= 0)
                {
                     barangBindingSource.Position = index;
                }
                else
                {
                    // Fallback jika tidak ditemukan di BindingSource
                    txt_klbr_nama.Text = row.Cells[1].Value.ToString();
                    cmb_klbr_kategori.Text = row.Cells[2].Value.ToString();
                    txt_klbr_stok.Text = row.Cells[3].Value.ToString();
                    cmb_admin_kondisi.Text = row.Cells[4].Value.ToString();
                }
            }
        }
        private void btn_klbr_ubah_Click(object sender, EventArgs e)
        {
            string idBarang = "";
            if (barangBindingSource.Current != null)
            {
                idBarang = ((System.Data.DataRowView)barangBindingSource.Current)["IDBarang"].ToString();
            }
            if (string.IsNullOrWhiteSpace(idBarang))
            {
                idBarang = idBarangTerpilih;
            }

            if (string.IsNullOrEmpty(idBarang))
            {
                MessageBox.Show("Silakan tentukan barang pada tabel atau masukkan ID secara manual.", "Aksi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_klbr_nama.Text) ||
                string.IsNullOrWhiteSpace(txt_klbr_stok.Text) ||
                cmb_klbr_kategori.SelectedValue == null ||
                string.IsNullOrWhiteSpace(cmb_admin_kondisi.Text))
            {
                MessageBox.Show("Form input tidak boleh dikosongkan saat memperbarui data!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateBarang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@IDBarang", idBarang);
                    cmd.Parameters.AddWithValue("@NamaBarang", txt_klbr_nama.Text.Trim());
                    cmd.Parameters.AddWithValue("@IDKategori", cmb_klbr_kategori.SelectedValue);
                    cmd.Parameters.AddWithValue("@Stok", int.Parse(txt_klbr_stok.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Kondisi", cmb_admin_kondisi.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Spesifikasi data barang berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_klbr_refresh_Click(sender, e);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Input Stok harus berupa angka integer!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memperbarui database barang: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_klbr_hapus_Click(object sender, EventArgs e)
        {
            string idBarang = "";
            if (barangBindingSource.Current != null)
            {
                idBarang = ((System.Data.DataRowView)barangBindingSource.Current)["IDBarang"].ToString();
            }
            if (string.IsNullOrWhiteSpace(idBarang))
            {
                idBarang = idBarangTerpilih;
            }

            if (string.IsNullOrEmpty(idBarang))
            {
                MessageBox.Show("Silakan tentukan barang pada tabel atau masukkan ID secara manual.", "Aksi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult konfirmasi = MessageBox.Show($"Apakah Anda yakin ingin menghapus barang '{txt_klbr_nama.Text}' dari inventaris secara permanen?", "Konfirmasi Penghapusan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                using (SqlConnection conn = db.GetConn())
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_DeleteBarang", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        
                        cmd.Parameters.AddWithValue("@IDBarang", idBarang);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Barang telah berhasil dihapus dari sistem logistik.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_klbr_refresh_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus data barang: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btn_kembali_Click(object sender, EventArgs e)
        {

            Formadmin admin = (Formadmin)Application.OpenForms["Formadmin"];

            if (admin != null)
            {
                admin.Show();

                this.Close();
            }
        }


        private void btn_klbr_refresh_Click(object sender, EventArgs e)
        {
            LoadDataBarang();

            barangBindingSource.CancelEdit();

            txt_klbr_nama.Focus(); 
        }
        private void btn_cari_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgv_kelolabarang.DataSource;

                if (dt != null)
                {
                    // Telah diselaraskan menggunakan standar nama txt_cari_barang
                    dt.DefaultView.RowFilter = $"NamaBarang LIKE '%{txt_cari_barang.Text.Trim()}%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem mendeteksi kegagalan penyaringan data: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_cari_barang_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb_admin_kondisi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}