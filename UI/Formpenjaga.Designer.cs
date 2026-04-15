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
            this.tabPeminjaman = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_peminjam_tampil = new System.Windows.Forms.Button();
            this.btn_pinjamkan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_pinjaman_barang = new System.Windows.Forms.TextBox();
            this.txt_pinjaman_nama = new System.Windows.Forms.TextBox();
            this.tabPengembalian = new System.Windows.Forms.TabPage();
            this.btn_pengembalian_tampil = new System.Windows.Forms.Button();
            this.dgv_pengembalian = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_pengembalian_nama = new System.Windows.Forms.TextBox();
            this.btn_kembalikan = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linklable_log_refresh = new System.Windows.Forms.LinkLabel();
            this.dgv_log_trs = new System.Windows.Forms.DataGridView();
            this.dgv_Peminjaman = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_pengembalian_peran = new System.Windows.Forms.TextBox();
            this.tabPeminjaman.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPengembalian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pengembalian)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_trs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Peminjaman)).BeginInit();
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
            // tabPeminjaman
            // 
            this.tabPeminjaman.Controls.Add(this.tabPage1);
            this.tabPeminjaman.Controls.Add(this.tabPengembalian);
            this.tabPeminjaman.Controls.Add(this.tabPage3);
            this.tabPeminjaman.Location = new System.Drawing.Point(30, 28);
            this.tabPeminjaman.Name = "tabPeminjaman";
            this.tabPeminjaman.SelectedIndex = 0;
            this.tabPeminjaman.Size = new System.Drawing.Size(740, 394);
            this.tabPeminjaman.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_Peminjaman);
            this.tabPage1.Controls.Add(this.btn_peminjam_tampil);
            this.tabPage1.Controls.Add(this.btn_pinjamkan);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_pinjaman_barang);
            this.tabPage1.Controls.Add(this.txt_pinjaman_nama);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Peminjaman";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // tabPengembalian
            // 
            this.tabPengembalian.Controls.Add(this.txt_pengembalian_peran);
            this.tabPengembalian.Controls.Add(this.label3);
            this.tabPengembalian.Controls.Add(this.btn_pengembalian_tampil);
            this.tabPengembalian.Controls.Add(this.dgv_pengembalian);
            this.tabPengembalian.Controls.Add(this.label6);
            this.tabPengembalian.Controls.Add(this.label7);
            this.tabPengembalian.Controls.Add(this.label8);
            this.tabPengembalian.Controls.Add(this.txt_pengembalian_nama);
            this.tabPengembalian.Controls.Add(this.btn_kembalikan);
            this.tabPengembalian.Location = new System.Drawing.Point(4, 25);
            this.tabPengembalian.Name = "tabPengembalian";
            this.tabPengembalian.Padding = new System.Windows.Forms.Padding(3);
            this.tabPengembalian.Size = new System.Drawing.Size(732, 365);
            this.tabPengembalian.TabIndex = 1;
            this.tabPengembalian.Text = "Pengembalian";
            this.tabPengembalian.UseVisualStyleBackColor = true;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linklable_log_refresh);
            this.tabPage3.Controls.Add(this.dgv_log_trs);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(732, 365);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log Transaksi";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // txt_pengembalian_peran
            // 
            this.txt_pengembalian_peran.Location = new System.Drawing.Point(152, 60);
            this.txt_pengembalian_peran.Name = "txt_pengembalian_peran";
            this.txt_pengembalian_peran.Size = new System.Drawing.Size(264, 22);
            this.txt_pengembalian_peran.TabIndex = 31;
            // 
            // Formpenjaga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabPeminjaman);
            this.Controls.Add(this.label1);
            this.Name = "Formpenjaga";
            this.Text = "Formpenjaga";
            this.tabPeminjaman.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPengembalian.ResumeLayout(false);
            this.tabPengembalian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pengembalian)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_trs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Peminjaman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabPeminjaman;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_peminjam_tampil;
        private System.Windows.Forms.Button btn_pinjamkan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_pinjaman_barang;
        private System.Windows.Forms.TextBox txt_pinjaman_nama;
        private System.Windows.Forms.TabPage tabPengembalian;
        private System.Windows.Forms.Button btn_pengembalian_tampil;
        private System.Windows.Forms.DataGridView dgv_pengembalian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_pengembalian_nama;
        private System.Windows.Forms.Button btn_kembalikan;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.LinkLabel linklable_log_refresh;
        private System.Windows.Forms.DataGridView dgv_log_trs;
        private System.Windows.Forms.DataGridView dgv_Peminjaman;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_pengembalian_peran;
    }
}