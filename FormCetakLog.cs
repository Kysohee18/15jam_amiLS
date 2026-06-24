using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Ucp_pabd_lab.DAL;

namespace Ucp_pabd_lab
{
    public partial class FormCetakLog : Form
    {
        Koneksi db = new Koneksi();
        private int? idTransaksi = null; // Nullable untuk menampung parameter

        // Constructor untuk Cetak Rekap (Semua)
        public FormCetakLog()
        {
            InitializeComponent();
        }

        // Constructor untuk Cetak Spesifik (Satu Baris)
        public FormCetakLog(int id)
        {
            InitializeComponent();
            idTransaksi = id;
        }

        private void FormCetakLog_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConn())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ReportLogTransaksi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    // Injeksi Parameter ke SQL
                    cmd.Parameters.AddWithValue("@IDTransaksi", (object)idTransaksi ?? DBNull.Value);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(Application.StartupPath + "\\Rpt_LogPenjaga.rpt");
                        rpt.SetDataSource(dt); // Crystal Reports otomatis memetakan dt ke Class1
                        crystalReportViewer1.ReportSource = rpt;
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
