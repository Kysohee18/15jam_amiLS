using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Ucp_pabd_lab.DAL;

namespace Ucp_pabd_lab.UI
{
    public partial class Formadmin : Form
    {
        Koneksi db = new Koneksi();
        private string idBarangTerpilih = "";
        private string idUserTerpilih = "";

        public Formadmin()
        {
            InitializeComponent();

            this.Load += Formadmin_Load;

            this.dgv_kelolabarang.CellClick += dgv_kelolabarang_CellClick;
            this.btn_klbr_simpan.Click += btn_klbr_simpan_Click;
            this.btn_klbr_ubah.Click += btn_klbr_ubah_Click;
            this.btn_klbr_hapus.Click += btn_klbr_hapus_Click;
            this.btn_klbr_refresh.Click += (s, e) => RefreshSemua();

            this.dgv_kelolauser.CellClick += dgv_kelolauser_CellClick;
            this.btn_klusr_simpan.Click += btn_klusr_simpan_Click;
            this.btn_klusr_ubah.Click += btn_klusr_ubah_Click;
            this.btn_klusr_hapus.Click += btn_klusr_hapus_Click;
            this.btn_klusr_refresh.Click += (s, e) => RefreshSemua();

            this.refresh_log_admin.LinkClicked += (s, e) => TampilDataLog();

            this.linkLabel_Admin_Logout.LinkClicked += (s, e) => { new Formlogin().Show(); this.Close(); };

            this.txtCariBarang.TextChanged += (s, e) => CariDataBarang(txtCariBarang.Text); // search box baru untuk admin cari barang

        }

        private void Formadmin_Load(object sender, EventArgs e)
        {
            SetupComboBoxKondisi();
            SetupComboBoxPeran();
            TampilKategori();
            RefreshSemua();
        }

        private void RefreshSemua()
        {
            TampilDataBarang();
            TampilDataUser();
            TampilDataLog(); 
            HitungTotalBarang();
            ClearInput();
        }

        private void SetupComboBoxKondisi()
        {
            cmb_admin_kondisi.Items.Clear();
            cmb_admin_kondisi.Items.Add("Baik");
            cmb_admin_kondisi.Items.Add("Rusak");
            cmb_admin_kondisi.Items.Add("Perbaikan");
            cmb_admin_kondisi.SelectedIndex = 0;
        }

        private void SetupComboBoxPeran()
        {
            cmb_klusr_peran.Items.Clear();
            cmb_klusr_peran.Items.Add("Siswa");
            cmb_klusr_peran.Items.Add("Guru");
            cmb_klusr_peran.Items.Add("Admin");
            cmb_klusr_peran.Items.Add("PenjagaLab");
            cmb_klusr_peran.SelectedIndex = 0;
        }

        private void TampilKategori()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetKategori", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmb_klbr_kategori.DataSource = dt;
                    cmb_klbr_kategori.DisplayMember = "NamaKategori";
                    cmb_klbr_kategori.ValueMember = "IDKategori";
                }
                catch { }
            }
        }

        private void HitungTotalBarang()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_HitungTotalBarang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }
        }

        private void ClearInput()
        {
            txt_klbr_nama.Clear();
            txt_klbr_stok.Clear();
            cmb_admin_kondisi.SelectedIndex = 0;
            idBarangTerpilih = "";

            txt_klusr_nama.Clear();
            cmb_klusr_peran.SelectedIndex = 0;
            idUserTerpilih = "";
        }

        private void TampilDataBarang()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetDataGridViewBarang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_kelolabarang.DataSource = dt;
                    dgv_kelolabarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch { }
            }
        }
        private bool ValidasiNama(string teks) // validasi nama hanya boleh huruf dan spasi
        { 
            return System.Text.RegularExpressions.Regex.IsMatch(teks, @"^[a-zA-Z ]+$");
        }

        private void btn_klbr_simpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_klbr_nama.Text) || string.IsNullOrWhiteSpace(txt_klbr_stok.Text)) return;
            
           
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertBarang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NamaBarang", txt_klbr_nama.Text);
                    cmd.Parameters.AddWithValue("@IDKategori", cmb_klbr_kategori.SelectedValue);
                    cmd.Parameters.AddWithValue("@Stok", txt_klbr_stok.Text);
                    cmd.Parameters.AddWithValue("@Kondisi", cmb_admin_kondisi.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Barang berhasil ditambahkan!");
                    RefreshSemua();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }


        private void btn_klbr_ubah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idBarangTerpilih)) return;
            if (MessageBox.Show("Yakin ubah barang?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = db.GetConn())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_UpdateBarang", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);
                        cmd.Parameters.AddWithValue("@NamaBarang", txt_klbr_nama.Text);
                        cmd.Parameters.AddWithValue("@IDKategori", cmb_klbr_kategori.SelectedValue);
                        cmd.Parameters.AddWithValue("@Stok", txt_klbr_stok.Text);
                        cmd.Parameters.AddWithValue("@Kondisi", cmb_admin_kondisi.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        RefreshSemua();
                    }
                    catch { }
                }
            }
        }

        private void btn_klbr_hapus_Click(object sender, EventArgs e) // BELUM sempurna ini  *shahky
        {
            
            if (string.IsNullOrEmpty(idBarangTerpilih))
            {
                MessageBox.Show("Silakan pilih barang yang akan dihapus dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            if (MessageBox.Show("Apakah Anda yakin ingin menghapus barang ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = db.GetConn())
                {
                    try
                    {
                        conn.Open();

                        SqlCommand checkCmd = new SqlCommand("sp_CheckPeminjamBarang", conn);
                        checkCmd.CommandType = CommandType.StoredProcedure;
                        checkCmd.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);

                        SqlParameter outParam = new SqlParameter("@Jumlah", SqlDbType.Int);
                        outParam.Direction = ParameterDirection.Output;
                        checkCmd.Parameters.Add(outParam);

                        checkCmd.ExecuteNonQuery();
                        int jumlahPeminjam = (int)outParam.Value;

                        if (jumlahPeminjam > 0)
                        {
                            
                            MessageBox.Show("Barang tidak dapat dihapus karena masih dipinjam oleh " + jumlahPeminjam + " orang. Harap selesaikan pengembalian terlebih dahulu!",
                                            "Gagal Hapus", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return; 
                        }


                        SqlCommand deleteCmd = new SqlCommand("sp_DeleteBarang", conn);
                        deleteCmd.CommandType = CommandType.StoredProcedure;
                        deleteCmd.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);

                        deleteCmd.ExecuteNonQuery();

                        MessageBox.Show("Barang berhasil dihapus dari sistem.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshSemua();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Terjadi kesalahan sistem: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgv_kelolabarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_kelolabarang.Rows[e.RowIndex];
                idBarangTerpilih = row.Cells["IDBarang"].Value.ToString();
                txt_klbr_nama.Text = row.Cells["NamaBarang"].Value.ToString();
                txt_klbr_stok.Text = row.Cells["Stok"].Value.ToString();
                cmb_klbr_kategori.Text = row.Cells["NamaKategori"].Value.ToString();
                cmb_admin_kondisi.Text = row.Cells["Kondisi"].Value.ToString();
            }
        }

        private void TampilDataUser()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetDataGridViewUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_kelolauser.DataSource = dt;
                    dgv_kelolauser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show("Error Tampil User: " + ex.Message); }
            }
        }

        private void btn_klusr_simpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_klusr_nama.Text)) return;
            if (!ValidasiNama(txt_klusr_nama.Text))
            {
                MessageBox.Show("Nama User tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidasiNama(txt_klusr_nama.Text)) //validasi baru
            {
                MessageBox.Show("Nama hanya boleh berisi huruf (A-Z) dan spasi. Angka dan simbol tidak diperbolehkan!",
                                "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NamaUser", txt_klusr_nama.Text);
                    cmd.Parameters.AddWithValue("@RoleUser", cmb_klusr_peran.Text);
                    cmd.Parameters.AddWithValue("@Password", "123456"); //kasih pw default

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User berhasil ditambahkan!");
                    RefreshSemua();
                }
                catch (Exception ex) { MessageBox.Show("Gagal Simpan User: " + ex.Message); }
            }
        }

        private void btn_klusr_ubah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idUserTerpilih)) { MessageBox.Show("Pilih user di tabel dulu!"); return; }

            if (MessageBox.Show("Yakin ingin mengubah user ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = db.GetConn())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDUser", idUserTerpilih);
                        cmd.Parameters.AddWithValue("@NamaUser", txt_klusr_nama.Text);
                        cmd.Parameters.AddWithValue("@RoleUser", cmb_klusr_peran.Text);
                        cmd.Parameters.AddWithValue("@Password", "123456");

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User berhasil diubah!");
                        RefreshSemua();
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal Ubah User: " + ex.Message); }
                }
            }
        }

        private void btn_klusr_hapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idUserTerpilih)) { MessageBox.Show("Pilih user yang akan dihapus!"); return; }

            if (MessageBox.Show("Yakin hapus user ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = db.GetConn())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_DeleteUser", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDUser", idUserTerpilih);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        RefreshSemua();
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal Hapus User (Mungkin user masih punya transaksi pinjam): " + ex.Message); }
                }
            }
        }

        private void dgv_kelolauser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_kelolauser.Rows[e.RowIndex];
                idUserTerpilih = row.Cells["IDUser"].Value.ToString();
                txt_klusr_nama.Text = row.Cells["NamaUser"].Value.ToString();
                cmb_klusr_peran.Text = row.Cells["RoleUser"].Value.ToString();
            }
        }

        private void TampilDataLog()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetDataGridViewLog", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_log_admin.DataSource = dt;
                    dgv_log_admin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Log masih kosong atau error: " + ex.Message);
                }
            }
        }

        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConn())
                {
                    conn.Open();
                    
                    string query = "UPDATE Barang SET Stok = 0, Kondisi = 'Rusak' WHERE NamaBarang = '" + txt_klbr_nama.Text + "'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show(result + " data barang berhasil dirusak/diinjeksi!", "Peringatan Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                RefreshSemua(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CariDataBarang(string kataKunci)
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_CariBarang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KataKunci", kataKunci);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_kelolabarang.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mencari data: " + ex.Message);
                }
            }
        }

        private void CariDataBarang(string kataKunci) // ini method search box nya
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_CariBarang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KataKunci", kataKunci);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                
                    dgv_kelolabarang.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mencari data: " + ex.Message);
                }
            }
        }

        private void txtCariBarang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}