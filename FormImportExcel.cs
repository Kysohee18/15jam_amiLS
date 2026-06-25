using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;
using Ucp_pabd_lab.DAL;

namespace Ucp_pabd_lab
{
    public partial class FormImportExcel : Form
    {
        // Inisialisasi kelas koneksi database
        private Koneksi db = new Koneksi();
        
        // Variabel penanda untuk membedakan mode import
        private string modeImport = ""; 

        /// <summary>
        /// Constructor Form yang mewajibkan penentuan mode saat dipanggil
        /// </summary>
        /// <param name="mode">Kirim "BARANG" atau "USER"</param>
        public FormImportExcel(string mode)
        {
            InitializeComponent();
            this.modeImport = mode.ToUpper();
        }

        /// <summary>
        /// Mengatur elemen antarmuka secara dinamis saat form pertama kali dimuat
        /// </summary>
        private void FormImportExcel_Load(object sender, EventArgs e)
        {
            // Set posisi form agar muncul di tengah layar monitor
            this.StartPosition = FormStartPosition.CenterScreen;

            if (modeImport == "BARANG")
            {
                this.Text = "Utilitas Sistem - Migrasi Data Inventaris";
                lbl_Judul.Text = "IMPORT DATA BARANG BARU VIA EXCEL";
                lbl_Petunjuk.Text = "Struktur Kolom Excel: [IDBarang] | [NamaBarang] | [IDKategori] | [Stok]";
            }
            else if (modeImport == "USER")
            {
                this.Text = "Utilitas Sistem - Migrasi Data Pengguna";
                lbl_Judul.Text = "IMPORT DATA USER BARU VIA EXCEL";
                lbl_Petunjuk.Text = "Struktur Kolom Excel: [IDUser] | [NamaUser] | [Password] | [Role] | [TanggunganPinjam]";
            }
            else
            {
                MessageBox.Show("Parameter arsitektur form tidak dikenali sistem.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Membuka jendela pencarian berkas Excel
        /// </summary>
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Worksheets|*.xlsx;*.xls";
                ofd.Title = "Pilih Berkas Excel Template " + modeImport;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txt_FilePath.Text = ofd.FileName;
                }
            }
        }

        /// <summary>
        /// Memproses pembacaan berkas Excel dan menyimpannya ke SQL Server
        /// </summary>
        private void btn_Proses_Click(object sender, EventArgs e)
        {
            // Validasi input awal
            if (string.IsNullOrEmpty(txt_FilePath.Text) || !File.Exists(txt_FilePath.Text))
            {
                MessageBox.Show("Silakan pilih file Excel yang valid terlebih dahulu.", "Verifikasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Membuka stream berkas Excel secara aman
                using (var stream = File.Open(txt_FilePath.Text, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        // Konfigurasi pembacaan agar baris pertama dijadikan nama kolom DataTable
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });

                        // Ambil sheet pertama dari dokumen Excel
                        DataTable dtSource = result.Tables[0];
                        int suksesCount = 0;

                        if (dtSource.Rows.Count == 0)
                        {
                            MessageBox.Show("Berkas Excel tidak memiliki data untuk diproses.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Membuka koneksi terpusat ke database
                        using (SqlConnection conn = db.GetConn())
                        {
                            conn.Open();

                            // Percabangan Eksekusi Berdasarkan Mode Operasi
                            if (modeImport == "BARANG")
                            {
                                foreach (DataRow row in dtSource.Rows)
                                {
                                    using (SqlCommand cmd = new SqlCommand("sp_InsertBarang", conn))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        
                                        // Mapping sesuai SP sp_InsertBarang (@NamaBarang, @IDKategori, @Stok, @Kondisi)
                                        cmd.Parameters.AddWithValue("@NamaBarang", row["NamaBarang"].ToString().Trim());
                                        cmd.Parameters.AddWithValue("@IDKategori", Convert.ToInt32(row["IDKategori"]));
                                        cmd.Parameters.AddWithValue("@Stok", Convert.ToInt32(row["Stok"]));
                                        cmd.Parameters.AddWithValue("@Kondisi", "Baik"); // Default kondisi barang baru
                                        
                                        cmd.ExecuteNonQuery();
                                        suksesCount++;
                                    }
                                }
                            }
                            else if (modeImport == "USER")
                            {
                                foreach (DataRow row in dtSource.Rows)
                                {
                                    using (SqlCommand cmd = new SqlCommand("sp_InsertUser", conn))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        
                                        // Mapping sesuai SP sp_InsertUser (@NamaUser, @RoleUser, @Password)
                                        cmd.Parameters.AddWithValue("@NamaUser", row["NamaUser"].ToString().Trim());
                                        cmd.Parameters.AddWithValue("@RoleUser", row["Role"].ToString().Trim());
                                        cmd.Parameters.AddWithValue("@Password", row["Password"].ToString());
                                        
                                        cmd.ExecuteNonQuery();
                                        suksesCount++;
                                    }
                                }
                            }
                        }

                        // Notifikasi sukses eksekusi massal
                        MessageBox.Show($"Proses migrasi selesai. {suksesCount} data {modeImport.ToLower()} berhasil diunggah ke sistem.", 
                                        "Operasi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.DialogResult = DialogResult.OK; // Memberi sinyal sukses ke halaman utama
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Menangkap kegagalan jika file sedang dibuka oleh program lain atau tipe data tidak cocok
                MessageBox.Show("Gagal mengeksekusi migrasi data.\nDetail Error: " + ex.Message, 
                                "Database Transaksi Batal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Membatalkan proses dan menutup jendela utilitas secara aman
        /// </summary>
        private void btn_Batal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Memberi sinyal pembatalan
            this.Close();
        }
    }
}
