namespace Ucp_pabd_lab.UI
{
    partial class UC_LogAdmin
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
            this.refresh_log_admin = new System.Windows.Forms.LinkLabel();
            this.dgv_log_admin = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_admin)).BeginInit();
            this.SuspendLayout();
            // 
            // refresh_log_admin
            // 
            this.refresh_log_admin.AutoSize = true;
            this.refresh_log_admin.Location = new System.Drawing.Point(688, 50);
            this.refresh_log_admin.Name = "refresh_log_admin";
            this.refresh_log_admin.Size = new System.Drawing.Size(54, 16);
            this.refresh_log_admin.TabIndex = 3;
            this.refresh_log_admin.TabStop = true;
            this.refresh_log_admin.Text = "Refresh";
            this.refresh_log_admin.Click += new System.EventHandler(this.UC_LogAdmin_Load);
            // 
            // dgv_log_admin
            // 
            this.dgv_log_admin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_log_admin.Location = new System.Drawing.Point(43, 83);
            this.dgv_log_admin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_log_admin.Name = "dgv_log_admin";
            this.dgv_log_admin.RowHeadersWidth = 51;
            this.dgv_log_admin.RowTemplate.Height = 24;
            this.dgv_log_admin.Size = new System.Drawing.Size(715, 302);
            this.dgv_log_admin.TabIndex = 2;
            // 
            // UC_LogAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.refresh_log_admin);
            this.Controls.Add(this.dgv_log_admin);
            this.Name = "UC_LogAdmin";
            this.Text = "UC_LogAdmin";
            this.Load += new System.EventHandler(this.UC_LogAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_admin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel refresh_log_admin;
        private System.Windows.Forms.DataGridView dgv_log_admin;
    }
}