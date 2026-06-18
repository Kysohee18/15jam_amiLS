namespace Ucp_pabd_lab.UI
{
    partial class UC_KelolaUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_KelolaUser));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmb_klusr_peran = new System.Windows.Forms.ComboBox();
            this.btn_klusr_refresh = new System.Windows.Forms.Button();
            this.btn_klusr_hapus = new System.Windows.Forms.Button();
            this.btn_klusr_ubah = new System.Windows.Forms.Button();
            this.dgv_kelolauser = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_klusr_nama = new System.Windows.Forms.TextBox();
            this.btn_klusr_simpan = new System.Windows.Forms.Button();
            this.btn_kembali = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kelolauser)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(800, 31);
            this.bindingNavigator1.TabIndex = 40;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(65, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // cmb_klusr_peran
            // 
            this.cmb_klusr_peran.FormattingEnabled = true;
            this.cmb_klusr_peran.Items.AddRange(new object[] {
            "Siswa",
            "Guru"});
            this.cmb_klusr_peran.Location = new System.Drawing.Point(197, 91);
            this.cmb_klusr_peran.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_klusr_peran.Name = "cmb_klusr_peran";
            this.cmb_klusr_peran.Size = new System.Drawing.Size(264, 24);
            this.cmb_klusr_peran.TabIndex = 39;
            // 
            // btn_klusr_refresh
            // 
            this.btn_klusr_refresh.Location = new System.Drawing.Point(588, 182);
            this.btn_klusr_refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_klusr_refresh.Name = "btn_klusr_refresh";
            this.btn_klusr_refresh.Size = new System.Drawing.Size(165, 32);
            this.btn_klusr_refresh.TabIndex = 38;
            this.btn_klusr_refresh.Text = "Refresh";
            this.btn_klusr_refresh.UseVisualStyleBackColor = true;
            this.btn_klusr_refresh.Click += new System.EventHandler(this.btn_klusr_refresh_Click);
            // 
            // btn_klusr_hapus
            // 
            this.btn_klusr_hapus.Location = new System.Drawing.Point(588, 146);
            this.btn_klusr_hapus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_klusr_hapus.Name = "btn_klusr_hapus";
            this.btn_klusr_hapus.Size = new System.Drawing.Size(165, 32);
            this.btn_klusr_hapus.TabIndex = 37;
            this.btn_klusr_hapus.Text = "Hapus";
            this.btn_klusr_hapus.UseVisualStyleBackColor = true;
            this.btn_klusr_hapus.Click += new System.EventHandler(this.btn_klusr_hapus_Click);
            // 
            // btn_klusr_ubah
            // 
            this.btn_klusr_ubah.Location = new System.Drawing.Point(588, 110);
            this.btn_klusr_ubah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_klusr_ubah.Name = "btn_klusr_ubah";
            this.btn_klusr_ubah.Size = new System.Drawing.Size(165, 32);
            this.btn_klusr_ubah.TabIndex = 36;
            this.btn_klusr_ubah.Text = "Ubah";
            this.btn_klusr_ubah.UseVisualStyleBackColor = true;
            this.btn_klusr_ubah.Click += new System.EventHandler(this.btn_klusr_ubah_Click);
            // 
            // dgv_kelolauser
            // 
            this.dgv_kelolauser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_kelolauser.Location = new System.Drawing.Point(53, 233);
            this.dgv_kelolauser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_kelolauser.Name = "dgv_kelolauser";
            this.dgv_kelolauser.RowHeadersWidth = 51;
            this.dgv_kelolauser.RowTemplate.Height = 24;
            this.dgv_kelolauser.Size = new System.Drawing.Size(717, 156);
            this.dgv_kelolauser.TabIndex = 35;
            this.dgv_kelolauser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_kelolauser_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Peran :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "Nama :";
            // 
            // txt_klusr_nama
            // 
            this.txt_klusr_nama.Location = new System.Drawing.Point(197, 58);
            this.txt_klusr_nama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_klusr_nama.Name = "txt_klusr_nama";
            this.txt_klusr_nama.Size = new System.Drawing.Size(264, 22);
            this.txt_klusr_nama.TabIndex = 32;
            // 
            // btn_klusr_simpan
            // 
            this.btn_klusr_simpan.Location = new System.Drawing.Point(588, 74);
            this.btn_klusr_simpan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_klusr_simpan.Name = "btn_klusr_simpan";
            this.btn_klusr_simpan.Size = new System.Drawing.Size(165, 32);
            this.btn_klusr_simpan.TabIndex = 31;
            this.btn_klusr_simpan.Text = "Simpan";
            this.btn_klusr_simpan.UseVisualStyleBackColor = true;
            this.btn_klusr_simpan.Click += new System.EventHandler(this.btn_klusr_simpan_Click);
            // 
            // btn_kembali
            // 
            this.btn_kembali.Location = new System.Drawing.Point(588, 37);
            this.btn_kembali.Name = "btn_kembali";
            this.btn_kembali.Size = new System.Drawing.Size(164, 32);
            this.btn_kembali.TabIndex = 43;
            this.btn_kembali.Text = "Menu utama";
            this.btn_kembali.UseVisualStyleBackColor = true;
            this.btn_kembali.Click += new System.EventHandler(this.btn_kembali_Click);
            // 
            // UC_KelolaUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_kembali);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.cmb_klusr_peran);
            this.Controls.Add(this.btn_klusr_refresh);
            this.Controls.Add(this.btn_klusr_hapus);
            this.Controls.Add(this.btn_klusr_ubah);
            this.Controls.Add(this.dgv_kelolauser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_klusr_nama);
            this.Controls.Add(this.btn_klusr_simpan);
            this.Name = "UC_KelolaUser";
            this.Text = "UC_KelolaUser";
            this.Load += new System.EventHandler(this.UC_KelolaUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kelolauser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ComboBox cmb_klusr_peran;
        private System.Windows.Forms.Button btn_klusr_refresh;
        private System.Windows.Forms.Button btn_klusr_hapus;
        private System.Windows.Forms.Button btn_klusr_ubah;
        private System.Windows.Forms.DataGridView dgv_kelolauser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_klusr_nama;
        private System.Windows.Forms.Button btn_klusr_simpan;
        private System.Windows.Forms.Button btn_kembali;
    }
}