namespace Ucp_pabd_lab.UI
{
    partial class Formadmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_kelolabarang = new System.Windows.Forms.TabPage();
            this.btn_klbr_refresh = new System.Windows.Forms.Button();
            this.btn_klbr_hapus = new System.Windows.Forms.Button();
            this.btn_klbr_ubah = new System.Windows.Forms.Button();
            this.dgv_kelolabarang = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_klbr_stok = new System.Windows.Forms.TextBox();
            this.txt_klbr_nama = new System.Windows.Forms.TextBox();
            this.btn_klbr_simpan = new System.Windows.Forms.Button();
            this.tab_kelolauser = new System.Windows.Forms.TabPage();
            this.cmb_klusr_peran = new System.Windows.Forms.ComboBox();
            this.btn_klusr_refresh = new System.Windows.Forms.Button();
            this.btn_klusr_hapus = new System.Windows.Forms.Button();
            this.btn_klusr_ubah = new System.Windows.Forms.Button();
            this.dgv_kelolauser = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_klusr_nama = new System.Windows.Forms.TextBox();
            this.btn_klusr_simpan = new System.Windows.Forms.Button();
            this.tab_log_admin = new System.Windows.Forms.TabPage();
            this.refresh_log_admin = new System.Windows.Forms.LinkLabel();
            this.dgv_log_admin = new System.Windows.Forms.DataGridView();
            this.linkLabel_Admin_Logout = new System.Windows.Forms.LinkLabel();
            this.cmb_klbr_kategori = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_admin_kondisi = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tab_kelolabarang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kelolabarang)).BeginInit();
            this.tab_kelolauser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kelolauser)).BeginInit();
            this.tab_log_admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_admin)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_kelolabarang);
            this.tabControl1.Controls.Add(this.tab_kelolauser);
            this.tabControl1.Controls.Add(this.tab_log_admin);
            this.tabControl1.Location = new System.Drawing.Point(26, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 394);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_kelolabarang
            // 
            this.tab_kelolabarang.Controls.Add(this.cmb_admin_kondisi);
            this.tab_kelolabarang.Controls.Add(this.label6);
            this.tab_kelolabarang.Controls.Add(this.cmb_klbr_kategori);
            this.tab_kelolabarang.Controls.Add(this.btn_klbr_refresh);
            this.tab_kelolabarang.Controls.Add(this.btn_klbr_hapus);
            this.tab_kelolabarang.Controls.Add(this.btn_klbr_ubah);
            this.tab_kelolabarang.Controls.Add(this.dgv_kelolabarang);
            this.tab_kelolabarang.Controls.Add(this.label4);
            this.tab_kelolabarang.Controls.Add(this.label3);
            this.tab_kelolabarang.Controls.Add(this.label2);
            this.tab_kelolabarang.Controls.Add(this.label1);
            this.tab_kelolabarang.Controls.Add(this.txt_klbr_stok);
            this.tab_kelolabarang.Controls.Add(this.txt_klbr_nama);
            this.tab_kelolabarang.Controls.Add(this.btn_klbr_simpan);
            this.tab_kelolabarang.Location = new System.Drawing.Point(4, 25);
            this.tab_kelolabarang.Name = "tab_kelolabarang";
            this.tab_kelolabarang.Padding = new System.Windows.Forms.Padding(3);
            this.tab_kelolabarang.Size = new System.Drawing.Size(732, 365);
            this.tab_kelolabarang.TabIndex = 0;
            this.tab_kelolabarang.Text = "Kelola Barang";
            this.tab_kelolabarang.UseVisualStyleBackColor = true;
            // 
            // btn_klbr_refresh
            // 
            this.btn_klbr_refresh.Location = new System.Drawing.Point(534, 126);
            this.btn_klbr_refresh.Name = "btn_klbr_refresh";
            this.btn_klbr_refresh.Size = new System.Drawing.Size(166, 22);
            this.btn_klbr_refresh.TabIndex = 16;
            this.btn_klbr_refresh.Text = "Refresh";
            this.btn_klbr_refresh.UseVisualStyleBackColor = true;
            // 
            // btn_klbr_hapus
            // 
            this.btn_klbr_hapus.Location = new System.Drawing.Point(534, 98);
            this.btn_klbr_hapus.Name = "btn_klbr_hapus";
            this.btn_klbr_hapus.Size = new System.Drawing.Size(166, 22);
            this.btn_klbr_hapus.TabIndex = 15;
            this.btn_klbr_hapus.Text = "Hapus";
            this.btn_klbr_hapus.UseVisualStyleBackColor = true;
            // 
            // btn_klbr_ubah
            // 
            this.btn_klbr_ubah.Location = new System.Drawing.Point(534, 70);
            this.btn_klbr_ubah.Name = "btn_klbr_ubah";
            this.btn_klbr_ubah.Size = new System.Drawing.Size(166, 22);
            this.btn_klbr_ubah.TabIndex = 14;
            this.btn_klbr_ubah.Text = "Ubah";
            this.btn_klbr_ubah.UseVisualStyleBackColor = true;
            // 
            // dgv_kelolabarang
            // 
            this.dgv_kelolabarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_kelolabarang.Location = new System.Drawing.Point(9, 203);
            this.dgv_kelolabarang.Name = "dgv_kelolabarang";
            this.dgv_kelolabarang.RowHeadersWidth = 51;
            this.dgv_kelolabarang.RowTemplate.Height = 24;
            this.dgv_kelolabarang.Size = new System.Drawing.Size(717, 156);
            this.dgv_kelolabarang.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Kategori";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Stok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nama Barang:";
            // 
            // txt_klbr_stok
            // 
            this.txt_klbr_stok.Location = new System.Drawing.Point(152, 98);
            this.txt_klbr_stok.Name = "txt_klbr_stok";
            this.txt_klbr_stok.Size = new System.Drawing.Size(264, 22);
            this.txt_klbr_stok.TabIndex = 8;
            // 
            // txt_klbr_nama
            // 
            this.txt_klbr_nama.Location = new System.Drawing.Point(152, 42);
            this.txt_klbr_nama.Name = "txt_klbr_nama";
            this.txt_klbr_nama.Size = new System.Drawing.Size(264, 22);
            this.txt_klbr_nama.TabIndex = 6;
            // 
            // btn_klbr_simpan
            // 
            this.btn_klbr_simpan.Location = new System.Drawing.Point(534, 42);
            this.btn_klbr_simpan.Name = "btn_klbr_simpan";
            this.btn_klbr_simpan.Size = new System.Drawing.Size(166, 22);
            this.btn_klbr_simpan.TabIndex = 0;
            this.btn_klbr_simpan.Text = "Simpan";
            this.btn_klbr_simpan.UseVisualStyleBackColor = true;
            // 
            // tab_kelolauser
            // 
            this.tab_kelolauser.Controls.Add(this.cmb_klusr_peran);
            this.tab_kelolauser.Controls.Add(this.btn_klusr_refresh);
            this.tab_kelolauser.Controls.Add(this.btn_klusr_hapus);
            this.tab_kelolauser.Controls.Add(this.btn_klusr_ubah);
            this.tab_kelolauser.Controls.Add(this.dgv_kelolauser);
            this.tab_kelolauser.Controls.Add(this.label5);
            this.tab_kelolauser.Controls.Add(this.label7);
            this.tab_kelolauser.Controls.Add(this.label8);
            this.tab_kelolauser.Controls.Add(this.txt_klusr_nama);
            this.tab_kelolauser.Controls.Add(this.btn_klusr_simpan);
            this.tab_kelolauser.Location = new System.Drawing.Point(4, 25);
            this.tab_kelolauser.Name = "tab_kelolauser";
            this.tab_kelolauser.Padding = new System.Windows.Forms.Padding(3);
            this.tab_kelolauser.Size = new System.Drawing.Size(732, 365);
            this.tab_kelolauser.TabIndex = 1;
            this.tab_kelolauser.Text = "Kelola User";
            this.tab_kelolauser.UseVisualStyleBackColor = true;
            // 
            // cmb_klusr_peran
            // 
            this.cmb_klusr_peran.FormattingEnabled = true;
            this.cmb_klusr_peran.Items.AddRange(new object[] {
            "Siswa",
            "Guru"});
            this.cmb_klusr_peran.Location = new System.Drawing.Point(152, 58);
            this.cmb_klusr_peran.Name = "cmb_klusr_peran";
            this.cmb_klusr_peran.Size = new System.Drawing.Size(264, 24);
            this.cmb_klusr_peran.TabIndex = 29;
            // 
            // btn_klusr_refresh
            // 
            this.btn_klusr_refresh.Location = new System.Drawing.Point(534, 108);
            this.btn_klusr_refresh.Name = "btn_klusr_refresh";
            this.btn_klusr_refresh.Size = new System.Drawing.Size(166, 22);
            this.btn_klusr_refresh.TabIndex = 28;
            this.btn_klusr_refresh.Text = "Refresh";
            this.btn_klusr_refresh.UseVisualStyleBackColor = true;
            // 
            // btn_klusr_hapus
            // 
            this.btn_klusr_hapus.Location = new System.Drawing.Point(534, 80);
            this.btn_klusr_hapus.Name = "btn_klusr_hapus";
            this.btn_klusr_hapus.Size = new System.Drawing.Size(166, 22);
            this.btn_klusr_hapus.TabIndex = 27;
            this.btn_klusr_hapus.Text = "Hapus";
            this.btn_klusr_hapus.UseVisualStyleBackColor = true;
            // 
            // btn_klusr_ubah
            // 
            this.btn_klusr_ubah.Location = new System.Drawing.Point(534, 52);
            this.btn_klusr_ubah.Name = "btn_klusr_ubah";
            this.btn_klusr_ubah.Size = new System.Drawing.Size(166, 22);
            this.btn_klusr_ubah.TabIndex = 26;
            this.btn_klusr_ubah.Text = "Ubah";
            this.btn_klusr_ubah.UseVisualStyleBackColor = true;
            // 
            // dgv_kelolauser
            // 
            this.dgv_kelolauser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_kelolauser.Location = new System.Drawing.Point(9, 185);
            this.dgv_kelolauser.Name = "dgv_kelolauser";
            this.dgv_kelolauser.RowHeadersWidth = 51;
            this.dgv_kelolauser.RowTemplate.Height = 24;
            this.dgv_kelolauser.Size = new System.Drawing.Size(717, 156);
            this.dgv_kelolauser.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Peran :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Nama :";
            // 
            // txt_klusr_nama
            // 
            this.txt_klusr_nama.Location = new System.Drawing.Point(152, 24);
            this.txt_klusr_nama.Name = "txt_klusr_nama";
            this.txt_klusr_nama.Size = new System.Drawing.Size(264, 22);
            this.txt_klusr_nama.TabIndex = 18;
            // 
            // btn_klusr_simpan
            // 
            this.btn_klusr_simpan.Location = new System.Drawing.Point(534, 24);
            this.btn_klusr_simpan.Name = "btn_klusr_simpan";
            this.btn_klusr_simpan.Size = new System.Drawing.Size(166, 22);
            this.btn_klusr_simpan.TabIndex = 17;
            this.btn_klusr_simpan.Text = "Simpan";
            this.btn_klusr_simpan.UseVisualStyleBackColor = true;
            // 
            // tab_log_admin
            // 
            this.tab_log_admin.Controls.Add(this.refresh_log_admin);
            this.tab_log_admin.Controls.Add(this.dgv_log_admin);
            this.tab_log_admin.Location = new System.Drawing.Point(4, 25);
            this.tab_log_admin.Name = "tab_log_admin";
            this.tab_log_admin.Padding = new System.Windows.Forms.Padding(3);
            this.tab_log_admin.Size = new System.Drawing.Size(732, 365);
            this.tab_log_admin.TabIndex = 2;
            this.tab_log_admin.Text = "Log Transaksi";
            this.tab_log_admin.UseVisualStyleBackColor = true;
            // 
            // refresh_log_admin
            // 
            this.refresh_log_admin.AutoSize = true;
            this.refresh_log_admin.Location = new System.Drawing.Point(653, 32);
            this.refresh_log_admin.Name = "refresh_log_admin";
            this.refresh_log_admin.Size = new System.Drawing.Size(54, 16);
            this.refresh_log_admin.TabIndex = 1;
            this.refresh_log_admin.TabStop = true;
            this.refresh_log_admin.Text = "Refresh";
            // 
            // dgv_log_admin
            // 
            this.dgv_log_admin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_log_admin.Location = new System.Drawing.Point(6, 51);
            this.dgv_log_admin.Name = "dgv_log_admin";
            this.dgv_log_admin.RowHeadersWidth = 51;
            this.dgv_log_admin.RowTemplate.Height = 24;
            this.dgv_log_admin.Size = new System.Drawing.Size(715, 301);
            this.dgv_log_admin.TabIndex = 0;
            // 
            // linkLabel_Admin_Logout
            // 
            this.linkLabel_Admin_Logout.AutoSize = true;
            this.linkLabel_Admin_Logout.Location = new System.Drawing.Point(27, 426);
            this.linkLabel_Admin_Logout.Name = "linkLabel_Admin_Logout";
            this.linkLabel_Admin_Logout.Size = new System.Drawing.Size(53, 16);
            this.linkLabel_Admin_Logout.TabIndex = 1;
            this.linkLabel_Admin_Logout.TabStop = true;
            this.linkLabel_Admin_Logout.Text = "Log Out";
            // 
            // cmb_klbr_kategori
            // 
            this.cmb_klbr_kategori.FormattingEnabled = true;
            this.cmb_klbr_kategori.Items.AddRange(new object[] {
            "Alat Ukur",
            "Alat Gelas",
            "Bahan Kimia",
            "Alat Praktikum Fisika",
            "Alat Praktikum Biologi",
            "Media Pembelajaran",
            "Alat Keselamatan"});
            this.cmb_klbr_kategori.Location = new System.Drawing.Point(152, 68);
            this.cmb_klbr_kategori.Name = "cmb_klbr_kategori";
            this.cmb_klbr_kategori.Size = new System.Drawing.Size(264, 24);
            this.cmb_klbr_kategori.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Kondisi";
            // 
            // cmb_admin_kondisi
            // 
            this.cmb_admin_kondisi.FormattingEnabled = true;
            this.cmb_admin_kondisi.Items.AddRange(new object[] {
            "Baik",
            "Rusak",
            "Perbaikan"});
            this.cmb_admin_kondisi.Location = new System.Drawing.Point(152, 124);
            this.cmb_admin_kondisi.Name = "cmb_admin_kondisi";
            this.cmb_admin_kondisi.Size = new System.Drawing.Size(264, 24);
            this.cmb_admin_kondisi.TabIndex = 19;
            // 
            // Formadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel_Admin_Logout);
            this.Controls.Add(this.tabControl1);
            this.Name = "Formadmin";
            this.Text = "Formadmin";
            this.Load += new System.EventHandler(this.Formadmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_kelolabarang.ResumeLayout(false);
            this.tab_kelolabarang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kelolabarang)).EndInit();
            this.tab_kelolauser.ResumeLayout(false);
            this.tab_kelolauser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kelolauser)).EndInit();
            this.tab_log_admin.ResumeLayout(false);
            this.tab_log_admin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_admin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_kelolabarang;
        private System.Windows.Forms.TabPage tab_kelolauser;
        private System.Windows.Forms.TabPage tab_log_admin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_klbr_stok;
        private System.Windows.Forms.TextBox txt_klbr_nama;
        private System.Windows.Forms.Button btn_klbr_simpan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_klbr_refresh;
        private System.Windows.Forms.Button btn_klbr_hapus;
        private System.Windows.Forms.Button btn_klbr_ubah;
        private System.Windows.Forms.DataGridView dgv_kelolabarang;
        private System.Windows.Forms.Button btn_klusr_refresh;
        private System.Windows.Forms.Button btn_klusr_hapus;
        private System.Windows.Forms.Button btn_klusr_ubah;
        private System.Windows.Forms.DataGridView dgv_kelolauser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_klusr_nama;
        private System.Windows.Forms.Button btn_klusr_simpan;
        private System.Windows.Forms.ComboBox cmb_klusr_peran;
        private System.Windows.Forms.LinkLabel refresh_log_admin;
        private System.Windows.Forms.DataGridView dgv_log_admin;
        private System.Windows.Forms.LinkLabel linkLabel_Admin_Logout;
        private System.Windows.Forms.ComboBox cmb_klbr_kategori;
        private System.Windows.Forms.ComboBox cmb_admin_kondisi;
        private System.Windows.Forms.Label label6;
    }
}