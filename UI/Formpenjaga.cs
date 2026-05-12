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
        private string idBarangTerpilih = "";
        private string idUserTerpilih = "";

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
            txt_pinjaman_barang.ReadOnly = true;
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
            idBarangTerpilih = "";
            idUserTerpilih = "";
        }

        
        // peminjam
        
        private void TampilBarangTersedia()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetBarangTersedia", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

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
                idBarangTerpilih = row.Cells["IDBarang"].Value.ToString();
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

                    int idUser = 0;
                    using (SqlCommand cmdUser = new SqlCommand("sp_GetUserIDByName", conn))
                    {
                        cmdUser.CommandType = CommandType.StoredProcedure;
                        cmdUser.Parameters.AddWithValue("@NamaUser", txt_pinjaman_nama.Text);
                        object result = cmdUser.ExecuteScalar();
                        if (result == null) { MessageBox.Show("Nama User tidak terdaftar!"); return; }
                        idUser = Convert.ToInt32(result);
                    }

                    using (SqlCommand cmd = new SqlCommand("sp_InsertPeminjaman", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);
                        cmd.Parameters.AddWithValue("@IDUser", idUser);
                        cmd.ExecuteNonQuery();
                    }

                    int lastTransID = 0;
                    using (SqlCommand cmdId = new SqlCommand("SELECT MAX(IDTransaksi) FROM Transaksi", conn))
                    {
                        lastTransID = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    using (SqlCommand cmdLog = new SqlCommand("sp_InsertLogTransaksi", conn))
                    {
                        cmdLog.CommandType = CommandType.StoredProcedure;
                        cmdLog.Parameters.AddWithValue("@IDTransaksi", lastTransID);
                        cmdLog.Parameters.AddWithValue("@Aksi", "PINJAM");
                        cmdLog.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);
                        cmdLog.Parameters.AddWithValue("@IDUser", idUser);
                        cmdLog.Parameters.AddWithValue("@Keterangan", "Meminjam barang: " + txt_pinjaman_barang.Text);
                        cmdLog.ExecuteNonQuery();
                    }

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
                    SqlCommand cmd = new SqlCommand("sp_GetDataGridViewPinjam", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataView dv = new DataView(dt);
                    dv.RowFilter = "StatusTrans = 'Dipinjam'";

                    dgv_pengembalian.DataSource = dv;
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

                using (SqlConnection conn = db.GetConn())
                {
                    conn.Open();
                    string q = "SELECT IDBarang, IDUser FROM Transaksi WHERE IDTransaksi = @id";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idTransaksiTerpilih);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            idBarangTerpilih = dr["IDBarang"].ToString();
                            idUserTerpilih = dr["IDUser"].ToString();
                        }
                    }
                }
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

                    // 1. Jalankan SP Update Pengembalian
                    using (SqlCommand cmd = new SqlCommand("sp_UpdatePengembalian", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDTransaksi", idTransaksiTerpilih);
                        cmd.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);
                        cmd.Parameters.AddWithValue("@IDUser", idUserTerpilih);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Jalankan SP Log Transaksi
                    using (SqlCommand cmdLog = new SqlCommand("sp_InsertLogTransaksi", conn))
                    {
                        cmdLog.CommandType = CommandType.StoredProcedure;
                        cmdLog.Parameters.AddWithValue("@IDTransaksi", idTransaksiTerpilih);
                        cmdLog.Parameters.AddWithValue("@Aksi", "KEMBALI");
                        cmdLog.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);
                        cmdLog.Parameters.AddWithValue("@IDUser", idUserTerpilih);
                        cmdLog.Parameters.AddWithValue("@Keterangan", "Barang dikembalikan");
                        cmdLog.ExecuteNonQuery();
                    }

                    MessageBox.Show("Barang berhasil dikembalikan!", "Sukses");
                    RefreshSemua(); RefreshSemua();
                    
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
                    SqlCommand cmd = new SqlCommand("sp_GetLogTransaksi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

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