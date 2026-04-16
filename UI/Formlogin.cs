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

            using (SqlConnection conn = db.GetConn())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RoleUser FROM UserLab WHERE NamaUser = @user AND Password = @pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString();

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
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }

        private void txtPass_TextChanged(object sender, EventArgs e) { }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
