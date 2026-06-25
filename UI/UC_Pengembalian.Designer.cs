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
            this.dgv_pengembalian = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_kembalikan = new System.Windows.Forms.Button();
            this.btn_kembali = new System.Windows.Forms.Button();
            this.txt_nama_ucp = new System.Windows.Forms.TextBox();
            this.txt_NamaBarang_ucp = new System.Windows.Forms.TextBox();
            this.txt_cari_ucp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search_ucp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pengembalian)).BeginInit();
            this.SuspendLayout();
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
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "Nama Barang :";
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
            // txt_nama_ucp
            // 
            this.txt_nama_ucp.Location = new System.Drawing.Point(185, 76);
            this.txt_nama_ucp.Name = "txt_nama_ucp";
            this.txt_nama_ucp.Size = new System.Drawing.Size(225, 22);
            this.txt_nama_ucp.TabIndex = 42;
            // 
            // txt_NamaBarang_ucp
            // 
            this.txt_NamaBarang_ucp.Location = new System.Drawing.Point(185, 115);
            this.txt_NamaBarang_ucp.Name = "txt_NamaBarang_ucp";
            this.txt_NamaBarang_ucp.Size = new System.Drawing.Size(225, 22);
            this.txt_NamaBarang_ucp.TabIndex = 43;
            // 
            // txt_cari_ucp
            // 
            this.txt_cari_ucp.Location = new System.Drawing.Point(103, 188);
            this.txt_cari_ucp.Name = "txt_cari_ucp";
            this.txt_cari_ucp.Size = new System.Drawing.Size(225, 22);
            this.txt_cari_ucp.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Cari :";
            // 
            // btn_search_ucp
            // 
            this.btn_search_ucp.Location = new System.Drawing.Point(335, 188);
            this.btn_search_ucp.Name = "btn_search_ucp";
            this.btn_search_ucp.Size = new System.Drawing.Size(75, 23);
            this.btn_search_ucp.TabIndex = 46;
            this.btn_search_ucp.Text = "Cari";
            this.btn_search_ucp.UseVisualStyleBackColor = true;
            // 
            // UC_Pengembalian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_search_ucp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cari_ucp);
            this.Controls.Add(this.txt_NamaBarang_ucp);
            this.Controls.Add(this.txt_nama_ucp);
            this.Controls.Add(this.btn_kembali);
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
        private System.Windows.Forms.DataGridView dgv_pengembalian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_kembalikan;
        private System.Windows.Forms.Button btn_kembali;
        private System.Windows.Forms.TextBox txt_nama_ucp;
        private System.Windows.Forms.TextBox txt_NamaBarang_ucp;
        private System.Windows.Forms.TextBox txt_cari_ucp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_search_ucp;
    }
}