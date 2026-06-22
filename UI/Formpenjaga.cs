using System;
using System.Windows.Forms;
using Ucp_pabd_lab.DAL;

namespace Ucp_pabd_lab.UI
{
    public partial class Formpenjaga : Form
    {
        Koneksi db = new Koneksi();

        public Formpenjaga()
        {
            InitializeComponent();
        }

      
        private void btnMenuPeminjaman_Click(object sender, EventArgs e)
        {
            UC_Peminjaman formPinjam = new UC_Peminjaman();
            formPinjam.Show();
            this.Hide(); // Sembunyikan portal utama
        }

        
        private void btnMenuPengembalian_Click(object sender, EventArgs e)
        {
            UC_Pengembalian formKembali = new UC_Pengembalian();
            formKembali.Show();
            this.Hide();
        }

  
        private void btnMenuLog_Click(object sender, EventArgs e)
        {
            UC_LogPenjaga formLog = new UC_LogPenjaga();
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

        // =========================================================================
        // PROTEKSI MEMORI: Pembersihan Paksa Jika Form Disilang (X)
        // =========================================================================
        private void Formpenjaga_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Mencegah program terus berjalan di Task Manager secara diam-diam
            Application.Exit();
        }
    }
}