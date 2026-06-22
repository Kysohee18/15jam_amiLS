namespace Ucp_pabd_lab.UI
{
    partial class UC_Pengembalian
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
            this.btn_pengembalian_tampil = new System.Windows.Forms.Button();
            this.dgv_pengembalian = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_kembalikan = new System.Windows.Forms.Button();
            this.btn_kembali = new System.Windows.Forms.Button();
            this.cmb_pinjam_user = new System.Windows.Forms.ComboBox();
            this.cmb_pinjam_barang = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pengembalian)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_pengembalian_tampil
            // 
            this.btn_pengembalian_tampil.Location = new System.Drawing.Point(42, 188);
            this.btn_pengembalian_tampil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_pengembalian_tampil.Name = "btn_pengembalian_tampil";
            this.btn_pengembalian_tampil.Size = new System.Drawing.Size(165, 22);
            this.btn_pengembalian_tampil.TabIndex = 37;
            this.btn_pengembalian_tampil.Text = "Tampilkan Barang";
            this.btn_pengembalian_tampil.UseVisualStyleBackColor = true;
            // 
            // dgv_pengembalian
            // 
            this.dgv_pengembalian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pengembalian.Location = new System.Drawing.Point(42, 215);
            this.dgv_pengembalian.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_pengembalian.Name = "dgv_pengembalian";
            this.dgv_pengembalian.RowHeadersWidth = 51;
            this.dgv_pengembalian.RowTemplate.Height = 24;
            this.dgv_pengembalian.Size = new System.Drawing.Size(717, 156);
            this.dgv_pengembalian.TabIndex = 36;
            this.dgv_pengembalian.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_pengembalian_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "Peran :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Nama :";
            // 
            // btn_kembalikan
            // 
            this.btn_kembalikan.Location = new System.Drawing.Point(574, 79);
            this.btn_kembalikan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_kembalikan.Name = "btn_kembalikan";
            this.btn_kembalikan.Size = new System.Drawing.Size(165, 58);
            this.btn_kembalikan.TabIndex = 32;
            this.btn_kembalikan.Text = "Kembalikan";
            this.btn_kembalikan.UseVisualStyleBackColor = true;
            this.btn_kembalikan.Click += new System.EventHandler(this.btn_kembalikan_Click);
            // 
            // btn_kembali
            // 
            this.btn_kembali.Location = new System.Drawing.Point(574, 143);
            this.btn_kembali.Name = "btn_kembali";
            this.btn_kembali.Size = new System.Drawing.Size(165, 55);
            this.btn_kembali.TabIndex = 39;
            this.btn_kembali.Text = "Menu Utama";
            this.btn_kembali.UseVisualStyleBackColor = true;
            this.btn_kembali.Click += new System.EventHandler(this.btn_kembali_Click);
            // 
            // cmb_pinjam_user
            // 
            this.cmb_pinjam_user.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_pinjam_user.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_pinjam_user.FormattingEnabled = true;
            this.cmb_pinjam_user.Location = new System.Drawing.Point(185, 82);
            this.cmb_pinjam_user.Name = "cmb_pinjam_user";
            this.cmb_pinjam_user.Size = new System.Drawing.Size(225, 24);
            this.cmb_pinjam_user.TabIndex = 40;
            // 
            // cmb_pinjam_barang
            // 
            this.cmb_pinjam_barang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_pinjam_barang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_pinjam_barang.FormattingEnabled = true;
            this.cmb_pinjam_barang.Location = new System.Drawing.Point(185, 121);
            this.cmb_pinjam_barang.Name = "cmb_pinjam_barang";
            this.cmb_pinjam_barang.Size = new System.Drawing.Size(225, 24);
            this.cmb_pinjam_barang.TabIndex = 41;
            // 
            // UC_Pengembalian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmb_pinjam_barang);
            this.Controls.Add(this.cmb_pinjam_user);
            this.Controls.Add(this.btn_kembali);
            this.Controls.Add(this.btn_pengembalian_tampil);
            this.Controls.Add(this.dgv_pengembalian);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_kembalikan);
            this.Name = "UC_Pengembalian";
            this.Text = "UC_Pengembalian";
            this.Load += new System.EventHandler(this.UC_Pengembalian_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pengembalian)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_pengembalian_tampil;
        private System.Windows.Forms.DataGridView dgv_pengembalian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_kembalikan;
        private System.Windows.Forms.Button btn_kembali;
        private System.Windows.Forms.ComboBox cmb_pinjam_user;
        private System.Windows.Forms.ComboBox cmb_pinjam_barang;
    }
}