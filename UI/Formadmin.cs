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
            this.Resize += Formadmin_Resize;
        }

        private void Formadmin_Resize(object sender, EventArgs e)
        {
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Box ukuran virtual group menu: Lebar 508, Tinggi 317
            int startX = centerX - 254;
            int startY = centerY - 158;

            label1.Left = startX + 181;
            label1.Top = startY + 0;

            btnMenuBarang.Left = startX + 0;
            btnMenuBarang.Top = startY + 121;

            btnMenuUser.Left = startX + 198;
            btnMenuUser.Top = startY + 121;

            btnMenuLog.Left = startX + 382;
            btnMenuLog.Top = startY + 121;

            btn_logout.Left = startX + 198;
            btn_logout.Top = startY + 231;
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

        
        private void btnMenuLog_Click(object sender, EventArgs e)
        {
           
            UC_LogAdmin formLog = new UC_LogAdmin();

           
            formLog.Show();

          
            this.Hide();
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Apakah Anda yakin ingin mengakhiri sesi dan keluar dari sistem?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Formlogin login = new Formlogin();
                login.Show();
                this.Hide();
            }
        }


        private void Formadmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
        }

        private void btn_ImportExcel_Click(object sender, EventArgs e)
        {

        }
    }
}