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
using Ucp_pabd_lab.UI;

namespace Ucp_pabd_lab
{
    public partial class Formlogin : Form
    {
        Koneksi db = new Koneksi();


        public Formlogin()
        {
            InitializeComponent();
            this.Resize += Formlogin_Resize;
        }

        private void Formlogin_Resize(object sender, EventArgs e)
        {
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Box ukuran virtual login group: Lebar 460, Tinggi 340
            int startX = centerX - 230;
            int startY = centerY - 170;

            // Reposisi kontrol secara presisi di tengah layar
            pictureBox1.Left = startX + 6;
            pictureBox1.Top = startY + 3;

            label.Left = startX + 112;
            label.Top = startY + 3;

            label3.Left = startX + 118;
            label3.Top = startY + 38;

            label1.Left = startX + 3;
            label1.Top = startY + 127;

            label2.Left = startX + 5;
            label2.Top = startY + 164;

            txtUsername.Left = startX + 107;
            txtUsername.Top = startY + 126;

            txtPass.Left = startX + 107;
            txtPass.Top = startY + 160;

            cb_showpw.Left = startX + 325;
            cb_showpw.Top = startY + 162;

            btnLogin.Left = startX + 135;
            btnLogin.Top = startY + 215;

            lblStatus.Left = startX + 82;
            lblStatus.Top = startY + 308;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CekStatusKoneksi();
        }

        private void CekStatusKoneksi()
        {
            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    lblStatus.Text = "Status: Terhubung ke Database";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Status: Gagal Terhubung!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show("Error Koneksi: " + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        { // Perbaikan: Tadi kurung buka ini hilang
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!");
                return;
            }

            try
            {
                string role = db.Login(txtUsername.Text, txtPass.Text);

                if (role != null)
                {
                    if (role == "Admin")
                    {
                        Formadmin adminForm = new Formadmin();
                        adminForm.Show();
                        this.Hide();
                    }
                    else if (role == "PenjagaLab")
                    {
                        Formpenjaga penjagaForm = new Formpenjaga();
                        penjagaForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Role Anda tidak memiliki akses ke sistem ini.");
                    }
                }
                else
                {
                    MessageBox.Show("Username atau Password salah!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }

        private void txtPass_TextChanged(object sender, EventArgs e) { }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void cb_showpw_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showpw.Checked)
            {
                // Menampilkan password asli
                txtPass.PasswordChar = '\0';
            }
            else
            {
                // Menyembunyikan password dengan karakter bintang
                txtPass.PasswordChar = '*';
            }
        }
    }
}
