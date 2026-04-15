namespace Ucp_pabd_lab.UI
{
    partial class Formpenjaga
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
            this.label1 = new System.Windows.Forms.Label();
            this.tab_penjagaLab = new System.Windows.Forms.TabControl();
            this.tab_peminjaman = new System.Windows.Forms.TabPage();
            this.dgv_Peminjaman = new System.Windows.Forms.DataGridView();
            this.btn_peminjam_tampil = new System.Windows.Forms.Button();
            this.btn_pinjamkan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_pinjaman_barang = new System.Windows.Forms.TextBox();
            this.txt_pinjaman_nama = new System.Windows.Forms.TextBox();
            this.tab_pengembalian = new System.Windows.Forms.TabPage();
            this.txt_pengembalian_peran = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_pengembalian_tampil = new System.Windows.Forms.Button();
            this.dgv_pengembalian = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_pengembalian_nama = new System.Windows.Forms.TextBox();
            this.btn_kembalikan = new System.Windows.Forms.Button();
            this.tab_log_penjaga = new System.Windows.Forms.TabPage();
            this.linklable_log_refresh = new System.Windows.Forms.LinkLabel();
            this.dgv_log_trs = new System.Windows.Forms.DataGridView();
            this.tab_penjagaLab.SuspendLayout();
            this.tab_peminjaman.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Peminjaman)).BeginInit();
            this.tab_pengembalian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pengembalian)).BeginInit();
            this.tab_log_penjaga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_trs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // tab_penjagaLab
            // 
            this.tab_penjagaLab.Controls.Add(this.tab_peminjaman);
            this.tab_penjagaLab.Controls.Add(this.tab_pengembalian);
            this.tab_penjagaLab.Controls.Add(this.tab_log_penjaga);
            this.tab_penjagaLab.Location = new System.Drawing.Point(30, 28);
            this.tab_penjagaLab.Name = "tab_penjagaLab";
            this.tab_penjagaLab.SelectedIndex = 0;
            this.tab_penjagaLab.Size = new System.Drawing.Size(740, 394);
            this.tab_penjagaLab.TabIndex = 1;
            // 
            // tab_peminjaman
            // 
            this.tab_peminjaman.Controls.Add(this.dgv_Peminjaman);
            this.tab_peminjaman.Controls.Add(this.btn_peminjam_tampil);
            this.tab_peminjaman.Controls.Add(this.btn_pinjamkan);
            this.tab_peminjaman.Controls.Add(this.label4);
            this.tab_peminjaman.Controls.Add(this.label2);
            this.tab_peminjaman.Controls.Add(this.label5);
            this.tab_peminjaman.Controls.Add(this.txt_pinjaman_barang);
            this.tab_peminjaman.Controls.Add(this.txt_pinjaman_nama);
            this.tab_peminjaman.Location = new System.Drawing.Point(4, 25);
            this.tab_peminjaman.Name = "tab_peminjaman";
            this.tab_peminjaman.Padding = new System.Windows.Forms.Padding(3);
            this.tab_peminjaman.Size = new System.Drawing.Size(732, 365);
            this.tab_peminjaman.TabIndex = 0;
            this.tab_peminjaman.Text = "Peminjaman";
            this.tab_peminjaman.UseVisualStyleBackColor = true;
            this.tab_peminjaman.Click += new System.EventHandler(this.tab_peminjaman_Click);
            // 
            // dgv_Peminjaman
            // 
            this.dgv_Peminjaman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Peminjaman.Location = new System.Drawing.Point(5, 206);
            this.dgv_Peminjaman.Name = "dgv_Peminjaman";
            this.dgv_Peminjaman.RowHeadersWidth = 51;
            this.dgv_Peminjaman.RowTemplate.Height = 24;
            this.dgv_Peminjaman.Size = new System.Drawing.Size(721, 153);
            this.dgv_Peminjaman.TabIndex = 17;
            // 
            // btn_peminjam_tampil
            // 
            this.btn_peminjam_tampil.Location = new System.Drawing.Point(9, 178);
            this.btn_peminjam_tampil.Name = "btn_peminjam_tampil";
            this.btn_peminjam_tampil.Size = new System.Drawing.Size(166, 22);
            this.btn_peminjam_tampil.TabIndex = 16;
            this.btn_peminjam_tampil.Text = "Tampilkan Barang";
            this.btn_peminjam_tampil.UseVisualStyleBackColor = true;
            // 
            // btn_pinjamkan
            // 
            this.btn_pinjamkan.Location = new System.Drawing.Point(531, 42);
            this.btn_pinjamkan.Name = "btn_pinjamkan";
            this.btn_pinjamkan.Size = new System.Drawing.Size(166, 93);
            this.btn_pinjamkan.TabIndex = 15;
            this.btn_pinjamkan.Text = "Pinjamkan";
            this.btn_pinjamkan.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nama Barang:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nama Peminjam:";
            // 
            // txt_pinjaman_barang
            // 
            this.txt_pinjaman_barang.Location = new System.Drawing.Point(156, 98);
            this.txt_pinjaman_barang.Name = "txt_pinjaman_barang";
            this.txt_pinjaman_barang.Size = new System.Drawing.Size(264, 22);
            this.txt_pinjaman_barang.TabIndex = 7;
            // 
            // txt_pinjaman_nama
            // 
            this.txt_pinjaman_nama.Location = new System.Drawing.Point(156, 70);
            this.txt_pinjaman_nama.Name = "txt_pinjaman_nama";
            this.txt_pinjaman_nama.Size = new System.Drawing.Size(264, 22);
            this.txt_pinjaman_nama.TabIndex = 6;
            // 
            // tab_pengembalian
            // 
            this.tab_pengembalian.Controls.Add(this.txt_pengembalian_peran);
            this.tab_pengembalian.Controls.Add(this.label3);
            this.tab_pengembalian.Controls.Add(this.btn_pengembalian_tampil);
            this.tab_pengembalian.Controls.Add(this.dgv_pengembalian);
            this.tab_pengembalian.Controls.Add(this.label6);
            this.tab_pengembalian.Controls.Add(this.label7);
            this.tab_pengembalian.Controls.Add(this.label8);
            this.tab_pengembalian.Controls.Add(this.txt_pengembalian_nama);
            this.tab_pengembalian.Controls.Add(this.btn_kembalikan);
            this.tab_pengembalian.Location = new System.Drawing.Point(4, 25);
            this.tab_pengembalian.Name = "tab_pengembalian";
            this.tab_pengembalian.Padding = new System.Windows.Forms.Padding(3);
            this.tab_pengembalian.Size = new System.Drawing.Size(732, 365);
            this.tab_pengembalian.TabIndex = 1;
            this.tab_pengembalian.Text = "Pengembalian";
            this.tab_pengembalian.UseVisualStyleBackColor = true;
            // 
            // txt_pengembalian_peran
            // 
            this.txt_pengembalian_peran.Location = new System.Drawing.Point(152, 60);
            this.txt_pengembalian_peran.Name = "txt_pengembalian_peran";
            this.txt_pengembalian_peran.Size = new System.Drawing.Size(264, 22);
            this.txt_pengembalian_peran.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Status Pengembalian:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btn_pengembalian_tampil
            // 
            this.btn_pengembalian_tampil.Location = new System.Drawing.Point(9, 157);
            this.btn_pengembalian_tampil.Name = "btn_pengembalian_tampil";
            this.btn_pengembalian_tampil.Size = new System.Drawing.Size(166, 22);
            this.btn_pengembalian_tampil.TabIndex = 28;
            this.btn_pengembalian_tampil.Text = "Tampilkan Barang";
            this.btn_pengembalian_tampil.UseVisualStyleBackColor = true;
            // 
            // dgv_pengembalian
            // 
            this.dgv_pengembalian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pengembalian.Location = new System.Drawing.Point(9, 185);
            this.dgv_pengembalian.Name = "dgv_pengembalian";
            this.dgv_pengembalian.RowHeadersWidth = 51;
            this.dgv_pengembalian.RowTemplate.Height = 24;
            this.dgv_pengembalian.Size = new System.Drawing.Size(717, 156);
            this.dgv_pengembalian.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Peran :";
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
            // txt_pengembalian_nama
            // 
            this.txt_pengembalian_nama.Location = new System.Drawing.Point(152, 24);
            this.txt_pengembalian_nama.Name = "txt_pengembalian_nama";
            this.txt_pengembalian_nama.Size = new System.Drawing.Size(264, 22);
            this.txt_pengembalian_nama.TabIndex = 18;
            // 
            // btn_kembalikan
            // 
            this.btn_kembalikan.Location = new System.Drawing.Point(534, 24);
            this.btn_kembalikan.Name = "btn_kembalikan";
            this.btn_kembalikan.Size = new System.Drawing.Size(166, 58);
            this.btn_kembalikan.TabIndex = 17;
            this.btn_kembalikan.Text = "Kembalikan";
            this.btn_kembalikan.UseVisualStyleBackColor = true;
            // 
            // tab_log_penjaga
            // 
            this.tab_log_penjaga.Controls.Add(this.linklable_log_refresh);
            this.tab_log_penjaga.Controls.Add(this.dgv_log_trs);
            this.tab_log_penjaga.Location = new System.Drawing.Point(4, 25);
            this.tab_log_penjaga.Name = "tab_log_penjaga";
            this.tab_log_penjaga.Padding = new System.Windows.Forms.Padding(3);
            this.tab_log_penjaga.Size = new System.Drawing.Size(732, 365);
            this.tab_log_penjaga.TabIndex = 2;
            this.tab_log_penjaga.Text = "Log Transaksi";
            this.tab_log_penjaga.UseVisualStyleBackColor = true;
            // 
            // linklable_log_refresh
            // 
            this.linklable_log_refresh.AutoSize = true;
            this.linklable_log_refresh.Location = new System.Drawing.Point(653, 32);
            this.linklable_log_refresh.Name = "linklable_log_refresh";
            this.linklable_log_refresh.Size = new System.Drawing.Size(54, 16);
            this.linklable_log_refresh.TabIndex = 1;
            this.linklable_log_refresh.TabStop = true;
            this.linklable_log_refresh.Text = "Refresh";
            // 
            // dgv_log_trs
            // 
            this.dgv_log_trs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_log_trs.Location = new System.Drawing.Point(6, 51);
            this.dgv_log_trs.Name = "dgv_log_trs";
            this.dgv_log_trs.RowHeadersWidth = 51;
            this.dgv_log_trs.RowTemplate.Height = 24;
            this.dgv_log_trs.Size = new System.Drawing.Size(715, 301);
            this.dgv_log_trs.TabIndex = 0;
            // 
            // Formpenjaga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tab_penjagaLab);
            this.Controls.Add(this.label1);
            this.Name = "Formpenjaga";
            this.Text = "Formpenjaga";
            this.Load += new System.EventHandler(this.Formpenjaga_Load);
            this.tab_penjagaLab.ResumeLayout(false);
            this.tab_peminjaman.ResumeLayout(false);
            this.tab_peminjaman.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Peminjaman)).EndInit();
            this.tab_pengembalian.ResumeLayout(false);
            this.tab_pengembalian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pengembalian)).EndInit();
            this.tab_log_penjaga.ResumeLayout(false);
            this.tab_log_penjaga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_trs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tab_penjagaLab;
        private System.Windows.Forms.TabPage tab_peminjaman;
        private System.Windows.Forms.Button btn_peminjam_tampil;
        private System.Windows.Forms.Button btn_pinjamkan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_pinjaman_barang;
        private System.Windows.Forms.TextBox txt_pinjaman_nama;
        private System.Windows.Forms.TabPage tab_pengembalian;
        private System.Windows.Forms.Button btn_pengembalian_tampil;
        private System.Windows.Forms.DataGridView dgv_pengembalian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_pengembalian_nama;
        private System.Windows.Forms.Button btn_kembalikan;
        private System.Windows.Forms.TabPage tab_log_penjaga;
        private System.Windows.Forms.LinkLabel linklable_log_refresh;
        private System.Windows.Forms.DataGridView dgv_log_trs;
        private System.Windows.Forms.DataGridView dgv_Peminjaman;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_pengembalian_peran;
    }
}