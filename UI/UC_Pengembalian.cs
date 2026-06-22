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
                catch (Exception ex) { MessageBox.Show("Gagal memuat tabel pengembalian: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void KosongkanValidasi()
        {
            txt_pengembalian_nama.Clear();
            txt_pengembalian_peran.Clear();
            idTransaksiTerpilih = "";
            idBarangTerpilih = "";
            idUserTerpilih = "";
        }

        
        private void dgv_pengembalian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_pengembalian.Rows[e.RowIndex];

                txt_pengembalian_nama.Text = row.Cells["NamaUser"].Value.ToString();

                txt_pengembalian_peran.Text = row.Cells["NamaBarang"].Value.ToString();

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
                    catch (Exception ex) { MessageBox.Show("Gagal melacak entitas transaksi: " + ex.Message); }
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

            DialogResult dialog = MessageBox.Show($"Konfirmasi pengembalian barang '{txt_pengembalian_peran.Text}' oleh peminjam '{txt_pengembalian_nama.Text}'?", "Verifikasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                        // 2. Pencatatan Audit ke Log Transaksi
                        using (SqlCommand cmdLog = new SqlCommand("sp_InsertLogTransaksi", conn))
                        {
                            cmdLog.CommandType = CommandType.StoredProcedure;
                            cmdLog.Parameters.AddWithValue("@IDTransaksi", idTransaksiTerpilih);
                            cmdLog.Parameters.AddWithValue("@Aksi", "KEMBALI");
                            cmdLog.Parameters.AddWithValue("@IDBarang", idBarangTerpilih);
                            cmdLog.Parameters.AddWithValue("@IDUser", idUserTerpilih);
                            cmdLog.Parameters.AddWithValue("@Keterangan", "Restorasi stok: " + txt_pengembalian_peran.Text);
                            cmdLog.ExecuteNonQuery();
                        }

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