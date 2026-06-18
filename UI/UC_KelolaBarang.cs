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

                txt_klbr_nama.Text = row.Cells[1].Value.ToString();
                cmb_klbr_kategori.Text = row.Cells[2].Value.ToString();
                txt_klbr_stok.Text = row.Cells[3].Value.ToString();
                cmb_admin_kondisi.Text = row.Cells[4].Value.ToString();
            }
        }
        private void btn_klbr_ubah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idBarangTerpilih))
            {
                MessageBox.Show("Silakan tentukan data barang pada tabel yang ingin diubah!", "Aksi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    // Mengirimkan parameter lengkap ke sp_UpdateBarang
                    cmd.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);
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
            if (string.IsNullOrEmpty(idBarangTerpilih))
            {
                MessageBox.Show("Silakan tentukan data barang pada tabel yang ingin dihapus!", "Aksi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                        cmd.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);

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

            
            txt_klbr_nama.Clear();
            txt_klbr_stok.Clear();
            cmb_klbr_kategori.SelectedIndex = -1;
            cmb_admin_kondisi.SelectedIndex = -1;

            txt_klbr_nama.Focus(); 
        }
    }
}