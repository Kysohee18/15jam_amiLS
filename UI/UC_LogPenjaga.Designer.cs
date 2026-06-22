namespace Ucp_pabd_lab.UI
{
    partial class UC_LogPenjaga
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
            this.linklable_log_refresh = new System.Windows.Forms.LinkLabel();
            this.dgv_log_trs = new System.Windows.Forms.DataGridView();
            this.btn_kembali = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_trs)).BeginInit();
            this.SuspendLayout();
            // 
            // linklable_log_refresh
            // 
            this.linklable_log_refresh.AutoSize = true;
            this.linklable_log_refresh.Location = new System.Drawing.Point(691, 65);
            this.linklable_log_refresh.Name = "linklable_log_refresh";
            this.linklable_log_refresh.Size = new System.Drawing.Size(54, 16);
            this.linklable_log_refresh.TabIndex = 3;
            this.linklable_log_refresh.TabStop = true;
            this.linklable_log_refresh.Text = "Refresh";
            this.linklable_log_refresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklable_log_refresh_LinkClicked);
            // 
            // dgv_log_trs
            // 
            this.dgv_log_trs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_log_trs.Location = new System.Drawing.Point(43, 83);
            this.dgv_log_trs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_log_trs.Name = "dgv_log_trs";
            this.dgv_log_trs.RowHeadersWidth = 51;
            this.dgv_log_trs.RowTemplate.Height = 24;
            this.dgv_log_trs.Size = new System.Drawing.Size(715, 302);
            this.dgv_log_trs.TabIndex = 2;
            // 
            // btn_kembali
            // 
            this.btn_kembali.Location = new System.Drawing.Point(42, 35);
            this.btn_kembali.Name = "btn_kembali";
            this.btn_kembali.Size = new System.Drawing.Size(140, 30);
            this.btn_kembali.TabIndex = 4;
            this.btn_kembali.Text = "Menu Utama";
            this.btn_kembali.UseVisualStyleBackColor = true;
            this.btn_kembali.Click += new System.EventHandler(this.btn_kembali_Click);
            // 
            // UC_LogPenjaga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_kembali);
            this.Controls.Add(this.linklable_log_refresh);
            this.Controls.Add(this.dgv_log_trs);
            this.Name = "UC_LogPenjaga";
            this.Text = "UC_LogPenjaga";
            this.Load += new System.EventHandler(this.UC_LogPenjaga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log_trs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linklable_log_refresh;
        private System.Windows.Forms.DataGridView dgv_log_trs;
        private System.Windows.Forms.Button btn_kembali;
    }
}