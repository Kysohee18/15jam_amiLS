using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ucp_pabd_lab.DAL;

namespace Ucp_pabd_lab
{
    public partial class Formlogin : Form
    {
        Koneksi db = new Koneksi();


        public Formlogin()
        {
            InitializeComponent();
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
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RoleUser FROM UserLab WHERE IDUser = @username AND Password = @password";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);

                    object role = cmd.ExecuteScalar();

                    if (role != null)
                    {
                        MessageBox.Show("Login Berhasil! Anda masuk sebagai: " + role.ToString(), "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan pada database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }

        private void txtPass_TextChanged(object sender, EventArgs e) { }
    
    }
}
