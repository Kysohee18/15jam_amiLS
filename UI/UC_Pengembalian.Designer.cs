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
            this.txt_pengembalian_peran = new System.Windows.Forms.TextBox();
            this.btn_pengembalian_tampil = new System.Windows.Forms.Button();
            this.dgv_pengembalian = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_pengembalian_nama = new System.Windows.Forms.TextBox();
            this.btn_kembalikan = new System.Windows.Forms.Button();
            this.btn_kembali = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pengembalian)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_pengembalian_peran
            // 
            this.txt_pengembalian_peran.Location = new System.Drawing.Point(193, 115);
            this.txt_pengembalian_peran.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_pengembalian_peran.Name = "txt_pengembalian_peran";
            this.txt_pengembalian_peran.Size = new System.Drawing.Size(264, 22);
            this.txt_pengembalian_peran.TabIndex = 38;
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
            // txt_pengembalian_nama
            // 
            this.txt_pengembalian_nama.Location = new System.Drawing.Point(193, 79);
            this.txt_pengembalian_nama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_pengembalian_nama.Name = "txt_pengembalian_nama";
            this.txt_pengembalian_nama.Size = new System.Drawing.Size(264, 22);
            this.txt_pengembalian_nama.TabIndex = 33;
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
            this.btn_kembali.Text = "button1";
            this.btn_kembali.UseVisualStyleBackColor = true;
            this.btn_kembali.Click += new System.EventHandler(this.btn_kembali_Click);
            // 
            // UC_Pengembalian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_kembali);
            this.Controls.Add(this.txt_pengembalian_peran);
            this.Controls.Add(this.btn_pengembalian_tampil);
            this.Controls.Add(this.dgv_pengembalian);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_pengembalian_nama);
            this.Controls.Add(this.btn_kembalikan);
            this.Name = "UC_Pengembalian";
            this.Text = "UC_Pengembalian";
            this.Load += new System.EventHandler(this.UC_Pengembalian_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pengembalian)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_pengembalian_peran;
        private System.Windows.Forms.Button btn_pengembalian_tampil;
        private System.Windows.Forms.DataGridView dgv_pengembalian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_pengembalian_nama;
        private System.Windows.Forms.Button btn_kembalikan;
        private System.Windows.Forms.Button btn_kembali;
    }
}