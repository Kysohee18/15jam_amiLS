using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Ucp_pabd_lab.DAL;

namespace Ucp_pabd_lab.UI
{
    public partial class Formpenjaga : Form
    {
        Koneksi db = new Koneksi();

        
        private string idTransaksiTerpilih = "";

        public Formpenjaga()
        {
            InitializeComponent();

            
            this.Load += Formpenjaga_Load;

            
            this.dgv_Peminjaman.CellClick += dgv_Peminjaman_CellClick;
            this.dgv_pengembalian.CellClick += dgv_pengembalian_CellClick;

            
            this.btn_pinjamkan.Click += btn_pinjamkan_Click;
            this.btn_kembalikan.Click += btn_kembalikan_Click;

            this.btn_peminjam_tampil.Click += (s, e) => TampilBarangTersedia();
            this.btn_pengembalian_tampil.Click += (s, e) => TampilPeminjamanAktif();
            this.linklable_log_refresh.LinkClicked += (s, e) => TampilDataLog();

           
            txt_pengembalian_nama.ReadOnly = true;
            txt_pengembalian_peran.ReadOnly = true;
        }

        private void Formpenjaga_Load(object sender, EventArgs e)
        {
            RefreshSemua();
        }

        private void RefreshSemua()
        {
            TampilBarangTersedia();
            TampilPeminjamanAktif();
            TampilDataLog();
            ClearInput();
        }

        private void ClearInput()
        {
            txt_pinjaman_nama.Clear();
            txt_pinjaman_barang.Clear();
            txt_pengembalian_nama.Clear();
            txt_pengembalian_peran.Clear();
            idTransaksiTerpilih = "";
        }

        
        // peminjam
        
        private void TampilBarangTersedia()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                   
                    string query = "SELECT IDBarang, NamaBarang, Stok, Kondisi FROM Barang WHERE Stok > 0";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgv_Peminjaman.DataSource = dt;
                    dgv_Peminjaman.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show("Error Tampil Barang: " + ex.Message); }
            }
        }

        private void dgv_Peminjaman_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Peminjaman.Rows[e.RowIndex];
                txt_pinjaman_barang.Text = row.Cells["NamaBarang"].Value.ToString();
            }
        }

        private void btn_pinjamkan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_pinjaman_nama.Text) || string.IsNullOrWhiteSpace(txt_pinjaman_barang.Text))
            {
                MessageBox.Show("Nama Peminjam dan Nama Barang harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                   
                    string query = @"
                        DECLARE @IDU INT = (SELECT TOP 1 IDUser FROM UserLab WHERE NamaUser = @namaUser);
                        DECLARE @IDB INT = (SELECT TOP 1 IDBarang FROM Barang WHERE NamaBarang = @namaBarang);
                        
                        IF @IDU IS NULL RAISERROR('Nama User tidak terdaftar!', 16, 1);
                        ELSE IF @IDB IS NULL RAISERROR('Nama Barang tidak ditemukan!', 16, 1);
                        ELSE IF (SELECT Stok FROM Barang WHERE IDBarang = @IDB) < 1 RAISERROR('Stok barang habis!', 16, 1);
                        ELSE
                        BEGIN
                            -- 1.Transaksi
                            INSERT INTO Transaksi (IDBarang, IDUser, TanggalPinjam, StatusTrans) 
                            VALUES (@IDB, @IDU, GETDATE(), 'Dipinjam');
                            
                            -- 2. Ambil ID Transaksi
                            DECLARE @NewTransID INT = SCOPE_IDENTITY();
                            
                            -- 3. Catat ke Log
                            INSERT INTO LogTransaksi (IDTransaksi, Aksi, IDBarang, IDUser, WaktuKejadian, Keterangan)
                            VALUES (@NewTransID, 'PINJAM', @IDB, @IDU, GETDATE(), 'Dipinjam oleh ' + @namaUser);
                            
                            -- 4. Kurangi Stok
                            UPDATE Barang SET Stok = Stok - 1 WHERE IDBarang = @IDB;
                            
                            -- 5. Tambah Tanggungan User
                            UPDATE UserLab SET TanggunganPinjam = TanggunganPinjam + 1 WHERE IDUser = @IDU;
                        END";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@namaUser", txt_pinjaman_nama.Text);
                    cmd.Parameters.AddWithValue("@namaBarang", txt_pinjaman_barang.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Barang berhasil dipinjamkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshSemua();
                }
                catch (SqlException ex)
                {
                    
                    MessageBox.Show(ex.Message, "Gagal Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        // pengembalian
        
        private void TampilPeminjamanAktif()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT t.IDTransaksi, u.NamaUser, u.RoleUser AS 'Peran', b.NamaBarang, t.TanggalPinjam 
                        FROM Transaksi t
                        JOIN UserLab u ON t.IDUser = u.IDUser
                        JOIN Barang b ON t.IDBarang = b.IDBarang
                        WHERE t.StatusTrans = 'Dipinjam'";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgv_pengembalian.DataSource = dt;
                    dgv_pengembalian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show("Error Tampil Pengembalian: " + ex.Message); }
            }
        }

        private void dgv_pengembalian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_pengembalian.Rows[e.RowIndex];
                idTransaksiTerpilih = row.Cells["IDTransaksi"].Value.ToString();
                txt_pengembalian_nama.Text = row.Cells["NamaUser"].Value.ToString();
                txt_pengembalian_peran.Text = row.Cells["Peran"].Value.ToString();
            }
        }

        private void btn_kembalikan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTransaksiTerpilih))
            {
                MessageBox.Show("Pilih transaksi di tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        DECLARE @IDB INT = (SELECT IDBarang FROM Transaksi WHERE IDTransaksi = @idTrans);
                        DECLARE @IDU INT = (SELECT IDUser FROM Transaksi WHERE IDTransaksi = @idTrans);
                        
                        -- 1. Update Status Transaksi
                        UPDATE Transaksi 
                        SET TanggalKembali = GETDATE(), StatusTrans = 'Dikembalikan' 
                        WHERE IDTransaksi = @idTrans;
                        
                        -- 2. Catat ke Log
                        INSERT INTO LogTransaksi (IDTransaksi, Aksi, IDBarang, IDUser, WaktuKejadian, Keterangan)
                        VALUES (@idTrans, 'KEMBALI', @IDB, @IDU, GETDATE(), 'Dikembalikan dalam kondisi baik');
                        
                        -- 3. Tambah Stok Kembali
                        UPDATE Barang SET Stok = Stok + 1 WHERE IDBarang = @IDB;
                        
                        -- 4. Kurangi Tanggungan User
                        UPDATE UserLab SET TanggunganPinjam = TanggunganPinjam - 1 WHERE IDUser = @IDU;
                    ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idTrans", idTransaksiTerpilih);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Barang berhasil dikembalikan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshSemua();
                }
                catch (Exception ex) { MessageBox.Show("Gagal Mengembalikan: " + ex.Message); }
            }
        }


        // log transaksi

        private void TampilDataLog()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT l.IDLog, l.Aksi, b.NamaBarang, u.NamaUser AS 'Aktor', l.WaktuKejadian, l.Keterangan 
                                     FROM LogTransaksi l
                                     JOIN Barang b ON l.IDBarang = b.IDBarang
                                     JOIN UserLab u ON l.IDUser = u.IDUser
                                     ORDER BY l.WaktuKejadian DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgv_log_trs.DataSource = dt;
                    dgv_log_trs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch { }
            }
        }

       
        private void label3_Click(object sender, EventArgs e) { }
        
        private void tab_peminjaman_Click(object sender, EventArgs e)
        {
        }
        private void linkLabel_penjaga_Logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Formlogin login = new Formlogin();
            login.Show();
            this.Close();
        }

    }
}