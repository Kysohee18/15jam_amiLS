namespace Ucp_pabd_lab
{
    partial class FormImportExcel
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
            this.lbl_Judul = new System.Windows.Forms.Label();
            this.lbl_Petunjuk = new System.Windows.Forms.Label();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_Proses = new System.Windows.Forms.Button();
            this.btn_Batal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Judul
            // 
            this.lbl_Judul.AutoSize = true;
            this.lbl_Judul.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Judul.Location = new System.Drawing.Point(45, 45);
            this.lbl_Judul.Name = "lbl_Judul";
            this.lbl_Judul.Size = new System.Drawing.Size(298, 31);
            this.lbl_Judul.TabIndex = 0;
            this.lbl_Judul.Text = "IMPORT DATA VIA EXCEL";
            // 
            // lbl_Petunjuk
            // 
            this.lbl_Petunjuk.AutoSize = true;
            this.lbl_Petunjuk.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Petunjuk.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Petunjuk.Location = new System.Drawing.Point(47, 85);
            this.lbl_Petunjuk.Name = "lbl_Petunjuk";
            this.lbl_Petunjuk.Size = new System.Drawing.Size(159, 21);
            this.lbl_Petunjuk.TabIndex = 1;
            this.lbl_Petunjuk.Text = "Struktur kolom excel...";
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FilePath.Location = new System.Drawing.Point(50, 145);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.Size = new System.Drawing.Size(380, 30);
            this.txt_FilePath.TabIndex = 2;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.Location = new System.Drawing.Point(445, 143);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(100, 32);
            this.btn_Browse.TabIndex = 3;
            this.btn_Browse.Text = "Browse...";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_Proses
            // 
            this.btn_Proses.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Proses.Location = new System.Drawing.Point(325, 230);
            this.btn_Proses.Name = "btn_Proses";
            this.btn_Proses.Size = new System.Drawing.Size(105, 35);
            this.btn_Proses.TabIndex = 4;
            this.btn_Proses.Text = "Proses";
            this.btn_Proses.UseVisualStyleBackColor = true;
            this.btn_Proses.Click += new System.EventHandler(this.btn_Proses_Click);
            // 
            // btn_Batal
            // 
            this.btn_Batal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Batal.Location = new System.Drawing.Point(440, 230);
            this.btn_Batal.Name = "btn_Batal";
            this.btn_Batal.Size = new System.Drawing.Size(105, 35);
            this.btn_Batal.TabIndex = 5;
            this.btn_Batal.Text = "Batal";
            this.btn_Batal.UseVisualStyleBackColor = true;
            this.btn_Batal.Click += new System.EventHandler(this.btn_Batal_Click);
            // 
            // FormImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 313);
            this.Controls.Add(this.btn_Batal);
            this.Controls.Add(this.btn_Proses);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.txt_FilePath);
            this.Controls.Add(this.lbl_Petunjuk);
            this.Controls.Add(this.lbl_Judul);
            this.Name = "FormImportExcel";
            this.Text = "Import Data Excel";
            this.Load += new System.EventHandler(this.FormImportExcel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Judul;
        private System.Windows.Forms.Label lbl_Petunjuk;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_Proses;
        private System.Windows.Forms.Button btn_Batal;
    }
}