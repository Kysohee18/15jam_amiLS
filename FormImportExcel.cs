using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;
using Ucp_pabd_lab.DAL; // Pastikan namespace ini sesuai dengan lokasi kelas Koneksi Anda

namespace Ucp_pabd_lab
{
    public partial class FormImportExcel : Form
    {
        // Inisialisasi kelas koneksi database terpusat
        private Koneksi db = new Koneksi();
        
        // Variabel penanda untuk mengunci mode operasi form
        private string modeImport = ""; 

        /// <summary>
        /// Constructor utama Form yang mewajibkan penentuan mode operasi
        /// </summary>
        /// <param name="mode">Masukkan "BARANG", "USER", atau "BARANG_BARU"</param>
        public FormImportExcel(string mode)
        {
            InitializeComponent();
            this.modeImport = mode.ToUpper();
        }

        /// <summary>
        /// Mengatur elemen antarmuka secara dinamis saat jendela dimuat ke memori
        /// </summary>
        private void FormImportExcel_Load(object sender, EventArgs e)
        {
            // Konfigurasi standar jendela dialog profesional
            this.StartPosition = FormStartPosition.CenterScreen;
            // Menjaga tampilan form tetap seperti form biasa (resizable) sesuai request sebelumnya
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            // Percabangan pengaturan UI berdasarkan parameter inisialisasi
            if (modeImport == "BARANG")
            {
                this.Text = "Utilitas Sistem - Migrasi Data Inventaris";
                lbl_Judul.Text = "IMPORT DATA BARANG VIA EXCEL";
                lbl_Petunjuk.Text = "Struktur Kolom Excel: [IDBarang] | [NamaBarang] | [IDKategori] | [Stok]";
            }
            else if (modeImport == "USER")
            {
                this.Text = "Utilitas Sistem - Migrasi Data Pengguna";
                lbl_Judul.Text = "IMPORT DATA USER VIA EXCEL";
                lbl_Petunjuk.Text = "Struktur Kolom Excel: [IDUser] | [NamaUser] | [Password] | [Role] | [TanggunganPinjam]";
            }
            else if (modeImport == "BARANG_BARU")
            {
                this.Text = "Utilitas Sistem - Migrasi Transaksi Bersama";
                lbl_Judul.Text = "IMPORT BARANG SEKALIGUS KATEGORI BARU";
                lbl_Petunjuk.Text = "Struktur Kolom Excel: [IDKategori] | [NamaKategori] | [IDBarang] | [NamaBarang] | [Stok]";
            }
            else
            {
                MessageBox.Show("Parameter arsitektur form tidak valid atau tidak dikenali sistem.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Membuka berkas penjelajah untuk mencari file Excel workspace
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
        /// Mengeksekusi pembacaan data memori lokal Excel ke database SQL Server
        /// </summary>
        private void btn_Proses_Click(object sender, EventArgs e)
        {
            // Proteksi awal: Validasi keberadaan file fisik
            if (string.IsNullOrEmpty(txt_FilePath.Text) || !File.Exists(txt_FilePath.Text))
            {
                MessageBox.Show("Silakan pilih berkas Excel yang valid terlebih dahulu.", "Verifikasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Membuka aliran data (FileStream) berkas secara aman
                using (var stream = File.Open(txt_FilePath.Text, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        // Konfigurasi engine agar baris pertama dijadikan nama kolom DataTable di memori
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });

                        // Mengambil lembar kerja (sheet) pertama dari file Excel
                        DataTable dtSource = result.Tables[0];
                        int suksesCount = 0;

                        if (dtSource.Rows.Count == 0)
                        {
                            MessageBox.Show("Berkas Excel tidak memiliki baris data untuk diproses.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Membuka pipa koneksi ke server database
                        using (SqlConnection conn = db.GetConn())
                        {
                            conn.Open();

                            // =========================================================================
                            // MODE 1: IMPORT BARANG (Hanya data barang dengan Kategori yang sudah eksis)
                            // =========================================================================
                            if (modeImport == "BARANG")
                            {
                                foreach (DataRow row in dtSource.Rows)
                                {
                                    using (SqlCommand cmd = new SqlCommand("sp_InsertBarang", conn))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        
                                        // Parameter sp_InsertBarang: @NamaBarang, @IDKategori, @Stok, @Kondisi
                                        cmd.Parameters.AddWithValue("@NamaBarang", row["NamaBarang"].ToString().Trim());
                                        cmd.Parameters.AddWithValue("@IDKategori", GetOrCreateKategoriId(conn, row));
                                        cmd.Parameters.AddWithValue("@Stok", SafeToInt(row["Stok"]));
                                        
                                        string kondisi = "Baik";
                                        if (dtSource.Columns.Contains("Kondisi") && row["Kondisi"] != DBNull.Value)
                                        {
                                            kondisi = row["Kondisi"].ToString().Trim();
                                        }
                                        cmd.Parameters.AddWithValue("@Kondisi", kondisi);
                                        
                                        cmd.ExecuteNonQuery();
                                        suksesCount++;
                                    }
                                }
                            }
                            // =========================================================================
                            // MODE 2: IMPORT USER (Data pengguna massal awal semester)
                            // =========================================================================
                            else if (modeImport == "USER")
                            {
                                foreach (DataRow row in dtSource.Rows)
                                {
                                    using (SqlCommand cmd = new SqlCommand("sp_InsertUser", conn))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        
                                        // Parameter sp_InsertUser: @NamaUser, @RoleUser, @Password
                                        cmd.Parameters.AddWithValue("@NamaUser", row["NamaUser"].ToString().Trim());
                                        
                                        string roleVal = "";
                                        if (dtSource.Columns.Contains("RoleUser"))
                                        {
                                            roleVal = row["RoleUser"].ToString().Trim();
                                        }
                                        else if (dtSource.Columns.Contains("Role"))
                                        {
                                            roleVal = row["Role"].ToString().Trim();
                                        }
                                        cmd.Parameters.AddWithValue("@RoleUser", roleVal);
                                        
                                        string passwordVal = "12345";
                                        if (dtSource.Columns.Contains("Password") && row["Password"] != DBNull.Value)
                                        {
                                            passwordVal = row["Password"].ToString();
                                        }
                                        cmd.Parameters.AddWithValue("@Password", passwordVal);
                                        
                                        cmd.ExecuteNonQuery();
                                        suksesCount++;
                                    }
                                }
                            }
                            // =========================================================================
                            // MODE 3: IMPORT BARANG BARU (Eksekusi bersamaan dengan Kategori baru)
                            // =========================================================================
                            else if (modeImport == "BARANG_BARU")
                            {
                                foreach (DataRow row in dtSource.Rows)
                                {
                                    // Memanggil Stored Procedure Transaksi Bersama
                                    using (SqlCommand cmd = new SqlCommand("sp_InsertKategoriDanBarang", conn))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        
                                        // Parameter Entitas Tabel Kategori
                                        cmd.Parameters.AddWithValue("@IDKategori", GetOrCreateKategoriId(conn, row));
                                        cmd.Parameters.AddWithValue("@NamaKategori", row["NamaKategori"].ToString().Trim());
                                        
                                        // Parameter Entitas Tabel Barang
                                        cmd.Parameters.AddWithValue("@IDBarang", row["IDBarang"].ToString().Trim());
                                        cmd.Parameters.AddWithValue("@NamaBarang", row["NamaBarang"].ToString().Trim());
                                        cmd.Parameters.AddWithValue("@Stok", SafeToInt(row["Stok"]));
                                        
                                        cmd.ExecuteNonQuery();
                                        suksesCount++;
                                    }
                                }
                            }
                        }

                        // Mengirimkan sinyal keberhasilan operasional massal
                        MessageBox.Show($"Proses migrasi selesai. Total {suksesCount} baris data {modeImport.ToLower().Replace("_", " ")} berhasil diunggah ke sistem.", 
                                        "Operasi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.DialogResult = DialogResult.OK; // Memberi tahu parent form untuk me-refresh grid tampilan
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Menangkap kegagalan aliran file atau pembatalan transaksi SQL Server (Rollback)
                MessageBox.Show("Gagal mengeksekusi migrasi data ke database.\nDetail Masalah: " + ex.Message, 
                                "Database Transaksi Batal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mengonversi nilai objek dari Excel ke tipe data int secara aman.
        /// </summary>
        private int SafeToInt(object value, int defaultValue = 0)
        {
            if (value == null || value == DBNull.Value)
                return defaultValue;
            
            string valStr = value.ToString().Trim();
            if (string.IsNullOrEmpty(valStr))
                return defaultValue;
                
            if (double.TryParse(valStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double dbVal))
            {
                return Convert.ToInt32(dbVal);
            }
            
            if (int.TryParse(valStr, out int intVal))
            {
                return intVal;
            }
            
            return defaultValue;
        }

        /// <summary>
        /// Mengambil ID Kategori berdasarkan ID murni (jika valid) atau nama kategori.
        /// Jika nama kategori belum ada di database, kategori baru akan dibuat secara otomatis.
        /// </summary>
        private int GetOrCreateKategoriId(SqlConnection conn, DataRow row)
        {
            string inputID = "";
            string inputNama = "";

            if (row.Table.Columns.Contains("IDKategori") && row["IDKategori"] != DBNull.Value)
            {
                inputID = row["IDKategori"].ToString().Trim();
            }
            if (row.Table.Columns.Contains("NamaKategori") && row["NamaKategori"] != DBNull.Value)
            {
                inputNama = row["NamaKategori"].ToString().Trim();
            }

            // 1. Coba cari berdasarkan ID Kategori (jika berupa angka)
            if (!string.IsNullOrEmpty(inputID) && int.TryParse(inputID, out int idKategori))
            {
                using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM Kategori WHERE IDKategori = @IDKategori", conn))
                {
                    cmdCheck.Parameters.AddWithValue("@IDKategori", idKategori);
                    int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (count > 0)
                    {
                        return idKategori;
                    }
                }
            }

            // 2. Jika ID tidak ditemukan/tidak valid, coba cari berdasarkan Nama Kategori
            string searchNama = !string.IsNullOrEmpty(inputNama) ? inputNama : inputID;
            if (!string.IsNullOrEmpty(searchNama))
            {
                using (SqlCommand cmdFind = new SqlCommand("SELECT IDKategori FROM Kategori WHERE NamaKategori = @NamaKategori", conn))
                {
                    cmdFind.Parameters.AddWithValue("@NamaKategori", searchNama);
                    object result = cmdFind.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                // 3. Jika tidak ditemukan, buat Kategori baru (hindari murni angka untuk nama kategori baru)
                if (!int.TryParse(searchNama, out _))
                {
                    using (SqlCommand cmdInsert = new SqlCommand("INSERT INTO Kategori (NamaKategori) OUTPUT INSERTED.IDKategori VALUES (@NamaKategori)", conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@NamaKategori", searchNama);
                        return Convert.ToInt32(cmdInsert.ExecuteScalar());
                    }
                }
            }

            throw new Exception($"ID Kategori '{inputID}' atau Nama Kategori '{inputNama}' tidak valid/tidak ditemukan di database.");
        }

        /// <summary>
        /// Menutup form secara aman tanpa melakukan modifikasi data apa pun
        /// </summary>
        private void btn_Batal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
