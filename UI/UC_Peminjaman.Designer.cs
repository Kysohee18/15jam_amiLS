namespace Ucp_pabd_lab.UI
{
    partial class UC_Peminjaman
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
            this.dgv_Peminjaman = new System.Windows.Forms.DataGridView();
            this.btn_peminjam_tampil = new System.Windows.Forms.Button();
            this.btn_proses_pinjam = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_kembali = new System.Windows.Forms.Button();
            this.cmb_pinjam_user = new System.Windows.Forms.ComboBox();
            this.cmb_pinjam_barang = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Peminjaman)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Peminjaman
            // 
            this.dgv_Peminjaman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Peminjaman.Location = new System.Drawing.Point(40, 231);
            this.dgv_Peminjaman.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_Peminjaman.Name = "dgv_Peminjaman";
            this.dgv_Peminjaman.RowHeadersWidth = 51;
            this.dgv_Peminjaman.RowTemplate.Height = 24;
            this.dgv_Peminjaman.Size = new System.Drawing.Size(721, 153);
            this.dgv_Peminjaman.TabIndex = 24;
            // 
            // btn_peminjam_tampil
            // 
            this.btn_peminjam_tampil.Location = new System.Drawing.Point(44, 203);
            this.btn_peminjam_tampil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_peminjam_tampil.Name = "btn_peminjam_tampil";
            this.btn_peminjam_tampil.Size = new System.Drawing.Size(165, 22);
            this.btn_peminjam_tampil.TabIndex = 23;
            this.btn_peminjam_tampil.Text = "Tampilkan Barang";
            this.btn_peminjam_tampil.UseVisualStyleBackColor = true;
            this.btn_peminjam_tampil.Click += new System.EventHandler(this.UC_Peminjaman_Load);
            // 
            // btn_proses_pinjam
            // 
            this.btn_proses_pinjam.Location = new System.Drawing.Point(558, 30);
            this.btn_proses_pinjam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_proses_pinjam.Name = "btn_proses_pinjam";
            this.btn_proses_pinjam.Size = new System.Drawing.Size(165, 79);
            this.btn_proses_pinjam.TabIndex = 22;
            this.btn_proses_pinjam.Text = "Pinjamkan";
            this.btn_proses_pinjam.UseVisualStyleBackColor = true;
            this.btn_proses_pinjam.Click += new System.EventHandler(this.btn_proses_pinjam_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nama Barang:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nama Peminjam:";
            // 
            // btn_kembali
            // 
            this.btn_kembali.Location = new System.Drawing.Point(558, 145);
            this.btn_kembali.Name = "btn_kembali";
            this.btn_kembali.Size = new System.Drawing.Size(165, 69);
            this.btn_kembali.TabIndex = 25;
            this.btn_kembali.Text = "menu utama";
            this.btn_kembali.UseVisualStyleBackColor = true;
            this.btn_kembali.Click += new System.EventHandler(this.btn_kembali_Click);
            // 
            // cmb_pinjam_user
            // 
            this.cmb_pinjam_user.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_pinjam_user.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_pinjam_user.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pinjam_user.FormattingEnabled = true;
            this.cmb_pinjam_user.Location = new System.Drawing.Point(163, 76);
            this.cmb_pinjam_user.Name = "cmb_pinjam_user";
            this.cmb_pinjam_user.Size = new System.Drawing.Size(227, 24);
            this.cmb_pinjam_user.TabIndex = 26;
            this.cmb_pinjam_user.SelectedIndexChanged += new System.EventHandler(this.cmb_pinjam_user_SelectedIndexChanged);
            // 
            // cmb_pinjam_barang
            // 
            this.cmb_pinjam_barang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_pinjam_barang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_pinjam_barang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pinjam_barang.FormattingEnabled = true;
            this.cmb_pinjam_barang.Location = new System.Drawing.Point(163, 106);
            this.cmb_pinjam_barang.Name = "cmb_pinjam_barang";
            this.cmb_pinjam_barang.Size = new System.Drawing.Size(227, 24);
            this.cmb_pinjam_barang.TabIndex = 28;
            // 
            // UC_Peminjaman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmb_pinjam_barang);
            this.Controls.Add(this.cmb_pinjam_user);
            this.Controls.Add(this.btn_kembali);
            this.Controls.Add(this.dgv_Peminjaman);
            this.Controls.Add(this.btn_peminjam_tampil);
            this.Controls.Add(this.btn_proses_pinjam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Name = "UC_Peminjaman";
            this.Text = "UC_Peminjaman";
            this.Load += new System.EventHandler(this.UC_Peminjaman_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Peminjaman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Peminjaman;
        private System.Windows.Forms.Button btn_peminjam_tampil;
        private System.Windows.Forms.Button btn_proses_pinjam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_kembali;
        private System.Windows.Forms.ComboBox cmb_pinjam_user;
        private System.Windows.Forms.ComboBox cmb_pinjam_barang;
    }
}