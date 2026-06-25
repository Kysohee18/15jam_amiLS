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
        private string idTargetCetak = "";
        private bool isModeRekap = false;

        // Constructor 1: Mode Rekap (Semua Data)
        public FormCetakLog()
        {
            InitializeComponent();
            isModeRekap = true;
        }

        // Constructor 2: Mode Spesifik (Satu Transaksi)
        public FormCetakLog(string idTransaksi)
        {
            InitializeComponent();
            idTargetCetak = idTransaksi;
            isModeRekap = false;
        }

        private void FormCetakLog_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConn())
                {
                    conn.Open();
                    // Menggunakan SP khusus laporan
                    SqlCommand cmd = new SqlCommand("sp_ReportLogTransaksi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Mengirim parameter dinamis (NULL untuk rekap, ID untuk spesifik)
                    cmd.Parameters.AddWithValue("@IDTransaksi", isModeRekap ? DBNull.Value : (object)Convert.ToInt32(idTargetCetak));

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ReportDocument rpt = new ReportDocument();
                        // Memuat file desain laporan Anda
                        rpt.Load(Application.StartupPath + "\\Rpt_LogPenjaga.rpt");
                        
                        // Menyuntikkan data ke Class1
                        rpt.SetDataSource(dt);

                        crv_log.ReportSource = rpt;
                        crv_log.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Data log tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Error pada modul pelaporan: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
