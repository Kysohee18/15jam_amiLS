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

        public Formadmin()
        {
            InitializeComponent();
            this.Load += Formadmin_Load;
        }

        private void Formadmin_Load(object sender, EventArgs e)
        {
            TampilDataBarang();
        }

        private void TampilDataBarang()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();


                    string query = @"SELECT 
                                        b.IDBarang AS 'ID', 
                                        b.NamaBarang AS 'Nama Barang', 
                                        k.NamaKategori AS 'Kategori', 
                                        b.Stok AS 'Stok', 
                                        b.Kondisi AS 'Kondisi'
                                     FROM Barang b
                                     INNER JOIN Kategori k ON b.IDKategori = k.IDKategori";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgv_kelolabarang.DataSource = dt;

                    dgv_kelolabarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data tabel: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}