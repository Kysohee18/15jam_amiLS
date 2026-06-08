namespace Ucp_pabd_lab.UI
{
    partial class Formadmin
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
            this.components = new System.ComponentModel.Container();
            this.barangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBLabSekolahDataSet = new Ucp_pabd_lab.DBLabSekolahDataSet();
            this.spGetKategoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBLabSekolahDataSet2 = new Ucp_pabd_lab.DBLabSekolahDataSet2();
            this.userLabBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBLabSekolahDataSet1 = new Ucp_pabd_lab.DBLabSekolahDataSet1();
            this.barangBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.linkLabel_Admin_Logout = new System.Windows.Forms.LinkLabel();
            this.barangTableAdapter = new Ucp_pabd_lab.DBLabSekolahDataSetTableAdapters.BarangTableAdapter();
            this.userLabTableAdapter = new Ucp_pabd_lab.DBLabSekolahDataSet1TableAdapters.UserLabTableAdapter();
            this.sp_GetKategoriTableAdapter = new Ucp_pabd_lab.DBLabSekolahDataSet2TableAdapters.sp_GetKategoriTableAdapter();
            this.btnMenuBarang = new System.Windows.Forms.Button();
            this.btnMenuUser = new System.Windows.Forms.Button();
            this.btnMenuLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.barangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLabSekolahDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGetKategoriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLabSekolahDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userLabBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLabSekolahDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barangBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // barangBindingSource
            // 
            this.barangBindingSource.DataMember = "Barang";
            this.barangBindingSource.DataSource = this.dBLabSekolahDataSet;
            // 
            // dBLabSekolahDataSet
            // 
            this.dBLabSekolahDataSet.DataSetName = "DBLabSekolahDataSet";
            this.dBLabSekolahDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spGetKategoriBindingSource
            // 
            this.spGetKategoriBindingSource.DataMember = "sp_GetKategori";
            this.spGetKategoriBindingSource.DataSource = this.dBLabSekolahDataSet2;
            // 
            // dBLabSekolahDataSet2
            // 
            this.dBLabSekolahDataSet2.DataSetName = "DBLabSekolahDataSet2";
            this.dBLabSekolahDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userLabBindingSource
            // 
            this.userLabBindingSource.DataMember = "UserLab";
            this.userLabBindingSource.DataSource = this.dBLabSekolahDataSet1;
            // 
            // dBLabSekolahDataSet1
            // 
            this.dBLabSekolahDataSet1.DataSetName = "DBLabSekolahDataSet1";
            this.dBLabSekolahDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // barangBindingSource1
            // 
            this.barangBindingSource1.DataMember = "Barang";
            this.barangBindingSource1.DataSource = this.dBLabSekolahDataSet;
            // 
            // linkLabel_Admin_Logout
            // 
            this.linkLabel_Admin_Logout.AutoSize = true;
            this.linkLabel_Admin_Logout.Location = new System.Drawing.Point(27, 426);
            this.linkLabel_Admin_Logout.Name = "linkLabel_Admin_Logout";
            this.linkLabel_Admin_Logout.Size = new System.Drawing.Size(53, 16);
            this.linkLabel_Admin_Logout.TabIndex = 1;
            this.linkLabel_Admin_Logout.TabStop = true;
            this.linkLabel_Admin_Logout.Text = "Log Out";
            // 
            // barangTableAdapter
            // 
            this.barangTableAdapter.ClearBeforeFill = true;
            // 
            // userLabTableAdapter
            // 
            this.userLabTableAdapter.ClearBeforeFill = true;
            // 
            // sp_GetKategoriTableAdapter
            // 
            this.sp_GetKategoriTableAdapter.ClearBeforeFill = true;
            // 
            // btnMenuBarang
            // 
            this.btnMenuBarang.Location = new System.Drawing.Point(125, 155);
            this.btnMenuBarang.Name = "btnMenuBarang";
            this.btnMenuBarang.Size = new System.Drawing.Size(126, 86);
            this.btnMenuBarang.TabIndex = 2;
            this.btnMenuBarang.Text = " Kelola Barang";
            this.btnMenuBarang.UseVisualStyleBackColor = true;
            // 
            // btnMenuUser
            // 
            this.btnMenuUser.Location = new System.Drawing.Point(323, 155);
            this.btnMenuUser.Name = "btnMenuUser";
            this.btnMenuUser.Size = new System.Drawing.Size(126, 86);
            this.btnMenuUser.TabIndex = 3;
            this.btnMenuUser.Text = "button2";
            this.btnMenuUser.UseVisualStyleBackColor = true;
            // 
            // btnMenuLog
            // 
            this.btnMenuLog.Location = new System.Drawing.Point(507, 155);
            this.btnMenuLog.Name = "btnMenuLog";
            this.btnMenuLog.Size = new System.Drawing.Size(126, 86);
            this.btnMenuLog.TabIndex = 4;
            this.btnMenuLog.Text = "Log Transaksi";
            this.btnMenuLog.UseVisualStyleBackColor = true;
            // 
            // Formadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMenuLog);
            this.Controls.Add(this.btnMenuUser);
            this.Controls.Add(this.btnMenuBarang);
            this.Controls.Add(this.linkLabel_Admin_Logout);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Formadmin";
            this.Text = "Formadmin";
            this.Load += new System.EventHandler(this.Formadmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLabSekolahDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGetKategoriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLabSekolahDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userLabBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLabSekolahDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barangBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel_Admin_Logout;
        private DBLabSekolahDataSet dBLabSekolahDataSet;
        private System.Windows.Forms.BindingSource barangBindingSource;
        private DBLabSekolahDataSetTableAdapters.BarangTableAdapter barangTableAdapter;
        private System.Windows.Forms.BindingSource barangBindingSource1;
        private DBLabSekolahDataSet1 dBLabSekolahDataSet1;
        private System.Windows.Forms.BindingSource userLabBindingSource;
        private DBLabSekolahDataSet1TableAdapters.UserLabTableAdapter userLabTableAdapter;
        private DBLabSekolahDataSet2 dBLabSekolahDataSet2;
        private System.Windows.Forms.BindingSource spGetKategoriBindingSource;
        private DBLabSekolahDataSet2TableAdapters.sp_GetKategoriTableAdapter sp_GetKategoriTableAdapter;
        private System.Windows.Forms.Button btnMenuBarang;
        private System.Windows.Forms.Button btnMenuUser;
        private System.Windows.Forms.Button btnMenuLog;
    }
}