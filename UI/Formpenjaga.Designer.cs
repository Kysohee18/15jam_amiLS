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
            this.btnMenuPeminjaman = new System.Windows.Forms.Button();
            this.btnMenuPengembalian = new System.Windows.Forms.Button();
            this.btnMenuLog = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
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
            // btnMenuPeminjaman
            // 
            this.btnMenuPeminjaman.Location = new System.Drawing.Point(142, 131);
            this.btnMenuPeminjaman.Name = "btnMenuPeminjaman";
            this.btnMenuPeminjaman.Size = new System.Drawing.Size(118, 92);
            this.btnMenuPeminjaman.TabIndex = 3;
            this.btnMenuPeminjaman.Text = "Peminjaman";
            this.btnMenuPeminjaman.UseVisualStyleBackColor = true;
            // 
            // btnMenuPengembalian
            // 
            this.btnMenuPengembalian.Location = new System.Drawing.Point(305, 131);
            this.btnMenuPengembalian.Name = "btnMenuPengembalian";
            this.btnMenuPengembalian.Size = new System.Drawing.Size(118, 92);
            this.btnMenuPengembalian.TabIndex = 4;
            this.btnMenuPengembalian.Text = "Pengembalian";
            this.btnMenuPengembalian.UseVisualStyleBackColor = true;
            // 
            // btnMenuLog
            // 
            this.btnMenuLog.Location = new System.Drawing.Point(464, 131);
            this.btnMenuLog.Name = "btnMenuLog";
            this.btnMenuLog.Size = new System.Drawing.Size(118, 92);
            this.btnMenuLog.TabIndex = 5;
            this.btnMenuLog.Text = "Log Peminjam";
            this.btnMenuLog.UseVisualStyleBackColor = true;
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(305, 245);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(118, 92);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Log out";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // Formpenjaga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btnMenuLog);
            this.Controls.Add(this.btnMenuPengembalian);
            this.Controls.Add(this.btnMenuPeminjaman);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Formpenjaga";
            this.Text = "Formpenjaga";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenuPeminjaman;
        private System.Windows.Forms.Button btnMenuPengembalian;
        private System.Windows.Forms.Button btnMenuLog;
        private System.Windows.Forms.Button btn_logout;
    }
}