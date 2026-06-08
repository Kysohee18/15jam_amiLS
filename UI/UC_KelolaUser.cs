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
  
    public partial class UC_KelolaUser : Form
    {
        Koneksi db = new Koneksi();

        public UC_KelolaUser()
        {
            InitializeComponent();
        }

        
        private void UC_KelolaUser_Load(object sender, EventArgs e)
        {
            LoadDataUser(); 
        }

        
        private void LoadDataUser()
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
                    dgv_kelolauser.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sistem gagal mengambil data pengguna: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void btn_klusr_simpan_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txt_klusr_nama.Text) || cmb_klusr_peran.SelectedIndex == -1)
            {
                MessageBox.Show("Nama Pengguna dan Peran Akses wajib diisi secara lengkap!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@NamaUser", txt_klusr_nama.Text.Trim());
                    cmd.Parameters.AddWithValue("@RoleUser", cmb_klusr_peran.Text);

                    
                    cmd.Parameters.AddWithValue("@Password", "12345");

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Akun pengguna baru berhasil didaftarkan ke dalam database via SP.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    btn_klusr_refresh_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi masalah saat menyimpan data akun: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_klusr_ubah_Click(object sender, EventArgs e)
        {
            // Validasi apakah user sudah memilih data di grid terlebih dahulu
            if (string.IsNullOrEmpty(idUserTerpilih))
            {
                MessageBox.Show("Silakan pilih data pengguna pada tabel terlebih dahulu yang ingin diubah!", "Aksi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_klusr_nama.Text) || cmb_klusr_peran.SelectedIndex == -1)
            {
                MessageBox.Show("Nama Pengguna dan Peran Akses tidak boleh kosong!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@IDUser", idUserTerpilih);
                    cmd.Parameters.AddWithValue("@NamaUser", txt_klusr_nama.Text.Trim());
                    cmd.Parameters.AddWithValue("@RoleUser", cmb_klusr_peran.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data akun pengguna berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_klusr_refresh_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memperbarui data pengguna: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_klusr_hapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idUserTerpilih))
            {
                MessageBox.Show("Silakan pilih data pengguna pada tabel terlebih dahulu yang ingin dihapus!", "Aksi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            DialogResult dialog = MessageBox.Show($"Apakah Anda yakin ingin menghapus pengguna '{txt_klusr_nama.Text}' secara permanen?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                using (SqlConnection conn = db.GetConn())
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_DeleteUser", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Mengirimkan parameter sesuai spesifikasi sp_DeleteUser
                        cmd.Parameters.AddWithValue("@IDUser", idUserTerpilih);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Akun pengguna telah berhasil dihapus dari sistem.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_klusr_refresh_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus data pengguna: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btn_klusr_refresh_Click(object sender, EventArgs e)
        {
            LoadDataUser();

            
            txt_klusr_nama.Clear();
            cmb_klusr_peran.SelectedIndex = -1;

            txt_klusr_nama.Focus(); 
        }
    }
}