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
    public partial class Formadmin : Form
    {
        Koneksi db = new Koneksi();

        public Formadmin()
        {
            InitializeComponent();
        }

       
        private void Formadmin_Load(object sender, EventArgs e)
        {
           
            CekKoneksiDatabase();
        }

      
        private void CekKoneksiDatabase()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    // Koneksi berhasil dibuka tanpa masalah
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sistem mendeteksi kegagalan komunikasi dengan SQL Server: " + ex.Message,
                                    "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void btnMenuBarang_Click(object sender, EventArgs e)
        {
            
            UC_KelolaBarang formBarang = new UC_KelolaBarang();

            
            formBarang.Show();

            
            this.Hide();
        }

       
        private void btnMenuUser_Click(object sender, EventArgs e)
        {
           
            UC_KelolaUser formUser = new UC_KelolaUser();

           
            formUser.Show();

            
            this.Hide();
        }

        /
        private void btnMenuLog_Click(object sender, EventArgs e)
        {
           
            UC_LogAdmin formLog = new UC_LogAdmin();

           
            formLog.Show();

          
            this.Hide();
        }

      
        private void Formadmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
        }
    }
}