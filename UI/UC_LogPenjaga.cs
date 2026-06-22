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
    public partial class UC_LogPenjaga : Form
    {
        Koneksi db = new Koneksi();

        public UC_LogPenjaga()
        {
            InitializeComponent();
        }

        
        private void UC_LogPenjaga_Load(object sender, EventArgs e)
        {
            LoadDataLog();
        }

        private void LoadDataLog()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetLogTransaksi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dgv_log_trs.DataSource = dt;
                    dgv_log_trs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sistem gagal menarik data audit log dari database: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void linklable_log_refresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Memanggil ulang fungsi pipeline audit untuk memperbarui grid
            LoadDataLog();
        }

       
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