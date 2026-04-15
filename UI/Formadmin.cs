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
                    conn.Open();
                    string query = "SELECT IDKategori, NamaKategori FROM Kategori";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
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
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Barang", conn);
                    int total = (int)cmd.ExecuteScalar();
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
                    conn.Open();
                    string query = @"SELECT b.IDBarang, b.NamaBarang, k.NamaKategori, b.Stok, b.Kondisi 
                                     FROM Barang b JOIN Kategori k ON b.IDKategori = k.IDKategori";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgv_kelolabarang.DataSource = dt;
                    dgv_kelolabarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch { }
            }
        }

        private void btn_klbr_simpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_klbr_nama.Text) || string.IsNullOrWhiteSpace(txt_klbr_stok.Text)) return;

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Barang (NamaBarang, IDKategori, Stok, Kondisi) VALUES (@nama, @kat, @stok, @kondisi)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", txt_klbr_nama.Text);
                    cmd.Parameters.AddWithValue("@kat", cmb_klbr_kategori.SelectedValue);
                    cmd.Parameters.AddWithValue("@stok", txt_klbr_stok.Text);
                    cmd.Parameters.AddWithValue("@kondisi", cmb_admin_kondisi.Text);
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
                        conn.Open();
                        string query = "UPDATE Barang SET NamaBarang=@nama, IDKategori=@kat, Stok=@stok, Kondisi=@kondisi WHERE IDBarang=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nama", txt_klbr_nama.Text);
                        cmd.Parameters.AddWithValue("@kat", cmb_klbr_kategori.SelectedValue);
                        cmd.Parameters.AddWithValue("@stok", txt_klbr_stok.Text);
                        cmd.Parameters.AddWithValue("@kondisi", cmb_admin_kondisi.Text);
                        cmd.Parameters.AddWithValue("@id", idBarangTerpilih);
                        cmd.ExecuteNonQuery();
                        RefreshSemua();
                    }
                    catch { }
                }
            }
        }

        private void btn_klbr_hapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idBarangTerpilih)) return;
            if (MessageBox.Show("Yakin hapus barang?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = db.GetConn())
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Barang WHERE IDBarang=@id", conn);
                        cmd.Parameters.AddWithValue("@id", idBarangTerpilih);
                        cmd.ExecuteNonQuery();
                        RefreshSemua();
                    }
                    catch { }
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
                    conn.Open();
                    string query = "SELECT IDUser, NamaUser, RoleUser, TanggunganPinjam FROM UserLab";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgv_kelolauser.DataSource = dt;
                    dgv_kelolauser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show("Error Tampil User: " + ex.Message); }
            }
        }

        private void btn_klusr_simpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_klusr_nama.Text))
            {
                MessageBox.Show("Nama User tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO UserLab (NamaUser, RoleUser, Password, TanggunganPinjam) VALUES (@nama, @peran, '123456', 0)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", txt_klusr_nama.Text);
                    cmd.Parameters.AddWithValue("@peran", cmb_klusr_peran.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User berhasil ditambahkan! (Password default: 123456)");
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
                        conn.Open();
                        string query = "UPDATE UserLab SET NamaUser=@nama, RoleUser=@peran WHERE IDUser=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nama", txt_klusr_nama.Text);
                        cmd.Parameters.AddWithValue("@peran", cmb_klusr_peran.Text);
                        cmd.Parameters.AddWithValue("@id", idUserTerpilih);

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
                        conn.Open();
                        string query = "DELETE FROM UserLab WHERE IDUser=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idUserTerpilih);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User dihapus!");
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
                    conn.Open();
                    string query = @"SELECT 
                                        l.IDLog, 
                                        l.Aksi, 
                                        b.NamaBarang, 
                                        u.NamaUser AS 'Peminjam', 
                                        l.WaktuKejadian, 
                                        l.Keterangan 
                                     FROM LogTransaksi l
                                     JOIN Barang b ON l.IDBarang = b.IDBarang
                                     JOIN UserLab u ON l.IDUser = u.IDUser
                                     ORDER BY l.WaktuKejadian DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    dgv_log_admin.DataSource = dt;
                    dgv_log_admin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Log masih kosong atau error: " + ex.Message);
                }
            }
        }

    }
}