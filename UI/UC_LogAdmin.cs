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
    
    public partial class UC_LogAdmin : Form
    {
        Koneksi db = new Koneksi();

        public UC_LogAdmin()
        {
            InitializeComponent();
        }

        
        private void UC_LogAdmin_Load(object sender, EventArgs e)
        {
            LoadLogTransaksi();
        }

        
        private void LoadLogTransaksi()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();

                   
                    SqlCommand cmd = new SqlCommand("sp_GetDataGridViewLog", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dgv_log_admin.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sistem gagal memuat catatan riwayat log audit: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void refresh_log_admin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadLogTransaksi(); 
        }
    }
}