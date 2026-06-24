namespace Ucp_pabd_lab.UI
{
    partial class UC_KelolaBarang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_KelolaBarang));
            this.label9 = new System.Windows.Forms.Label();
            this.btnTestInjection = new System.Windows.Forms.Button();
            this.cmb_admin_kondisi = new System.Windows.Forms.ComboBox();
            this.barangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBLabSekolahDataSet = new Ucp_pabd_lab.DBLabSekolahDataSet();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_klbr_kategori = new System.Windows.Forms.ComboBox();
            this.btn_klbr_refresh = new System.Windows.Forms.Button();
            this.btn_klbr_hapus = new System.Windows.Forms.Button();
            this.btn_klbr_ubah = new System.Windows.Forms.Button();
            this.dgv_kelolabarang = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_klbr_stok = new System.Windows.Forms.TextBox();
            this.txt_klbr_nama = new System.Windows.Forms.TextBox();
            this.btn_klbr_simpan = new System.Windows.Forms.Button();
            this.btn_kembali = new System.Windows.Forms.Button();
            this.btn_cari = new System.Windows.Forms.Button();
            this.txt_cari_barang = new System.Windows.Forms.TextBox();
            this.barangTableAdapter = new Ucp_pabd_lab.DBLabSekolahDataSetTableAdapters.BarangTableAdapter();
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
            ((System.ComponentModel.ISupportInitialize)(this.barangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLabSekolahDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kelolabarang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "Cari Barang:";
            // 
            // btnTestInjection
            // 
            this.btnTestInjection.BackColor = System.Drawing.Color.White;
            this.btnTestInjection.Location = new System.Drawing.Point(500, 183);
            this.btnTestInjection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTestInjection.Name = "btnTestInjection";
            this.btnTestInjection.Size = new System.Drawing.Size(75, 23);
            this.btnTestInjection.TabIndex = 38;
            this.btnTestInjection.Text = "test inject";
            this.btnTestInjection.UseVisualStyleBackColor = false;
            // 
            // cmb_admin_kondisi
            // 
            this.cmb_admin_kondisi.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.barangBindingSource, "Kondisi", true));
            this.cmb_admin_kondisi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.barangBindingSource, "Kondisi", true));
            this.cmb_admin_kondisi.FormattingEnabled = true;
            this.cmb_admin_kondisi.Items.AddRange(new object[] {
            "Baik",
            "Rusak",
            "Perbaikan"});
            this.cmb_admin_kondisi.Location = new System.Drawing.Point(151, 162);
            this.cmb_admin_kondisi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_admin_kondisi.Name = "cmb_admin_kondisi";
            this.cmb_admin_kondisi.Size = new System.Drawing.Size(264, 24);
            this.cmb_admin_kondisi.TabIndex = 37;
            this.cmb_admin_kondisi.SelectedIndexChanged += new System.EventHandler(this.cmb_admin_kondisi_SelectedIndexChanged);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Kondisi";
            // 
            // cmb_klbr_kategori
            // 
            this.cmb_klbr_kategori.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.barangBindingSource, "IDKategori", true));
            this.cmb_klbr_kategori.FormattingEnabled = true;
            this.cmb_klbr_kategori.Items.AddRange(new object[] {
            "Alat Ukur",
            "Alat Gelas",
            "Bahan Kimia",
            "Alat Praktikum Fisika",
            "Alat Praktikum Biologi",
            "Media Pembelajaran",
            "Alat Keselamatan"});
            this.cmb_klbr_kategori.Location = new System.Drawing.Point(151, 105);
            this.cmb_klbr_kategori.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_klbr_kategori.Name = "cmb_klbr_kategori";
            this.cmb_klbr_kategori.Size = new System.Drawing.Size(264, 24);
            this.cmb_klbr_kategori.TabIndex = 35;
            // 
            // btn_klbr_refresh
            // 
            this.btn_klbr_refresh.Location = new System.Drawing.Point(606, 179);
            this.btn_klbr_refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_klbr_refresh.Name = "btn_klbr_refresh";
            this.btn_klbr_refresh.Size = new System.Drawing.Size(165, 30);
            this.btn_klbr_refresh.TabIndex = 34;
            this.btn_klbr_refresh.Text = "Refresh";
            this.btn_klbr_refresh.UseVisualStyleBackColor = true;
            this.btn_klbr_refresh.Click += new System.EventHandler(this.btn_klbr_refresh_Click);
            // 
            // btn_klbr_hapus
            // 
            this.btn_klbr_hapus.Location = new System.Drawing.Point(606, 143);
            this.btn_klbr_hapus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_klbr_hapus.Name = "btn_klbr_hapus";
            this.btn_klbr_hapus.Size = new System.Drawing.Size(165, 30);
            this.btn_klbr_hapus.TabIndex = 33;
            this.btn_klbr_hapus.Text = "Hapus";
            this.btn_klbr_hapus.UseVisualStyleBackColor = true;
            this.btn_klbr_hapus.Click += new System.EventHandler(this.btn_klbr_hapus_Click);
            // 
            // btn_klbr_ubah
            // 
            this.btn_klbr_ubah.Location = new System.Drawing.Point(606, 107);
            this.btn_klbr_ubah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_klbr_ubah.Name = "btn_klbr_ubah";
            this.btn_klbr_ubah.Size = new System.Drawing.Size(165, 30);
            this.btn_klbr_ubah.TabIndex = 32;
            this.btn_klbr_ubah.Text = "Ubah";
            this.btn_klbr_ubah.UseVisualStyleBackColor = true;
            this.btn_klbr_ubah.Click += new System.EventHandler(this.btn_klbr_ubah_Click);
            // 
            // dgv_kelolabarang
            // 
            this.dgv_kelolabarang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_kelolabarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_kelolabarang.Location = new System.Drawing.Point(39, 237);
            this.dgv_kelolabarang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_kelolabarang.Name = "dgv_kelolabarang";
            this.dgv_kelolabarang.RowHeadersWidth = 51;
            this.dgv_kelolabarang.RowTemplate.Height = 24;
            this.dgv_kelolabarang.Size = new System.Drawing.Size(717, 156);
            this.dgv_kelolabarang.TabIndex = 31;
            this.dgv_kelolabarang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_kelolabarang_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Kategori";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Stok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nama Barang:";
            // 
            // txt_klbr_stok
            // 
            this.txt_klbr_stok.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.barangBindingSource, "Stok", true));
            this.txt_klbr_stok.Location = new System.Drawing.Point(151, 136);
            this.txt_klbr_stok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_klbr_stok.Name = "txt_klbr_stok";
            this.txt_klbr_stok.Size = new System.Drawing.Size(264, 22);
            this.txt_klbr_stok.TabIndex = 26;
            // 
            // txt_klbr_nama
            // 
            this.txt_klbr_nama.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.barangBindingSource, "NamaBarang", true));
            this.txt_klbr_nama.Location = new System.Drawing.Point(151, 80);
            this.txt_klbr_nama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_klbr_nama.Name = "txt_klbr_nama";
            this.txt_klbr_nama.Size = new System.Drawing.Size(264, 22);
            this.txt_klbr_nama.TabIndex = 25;
            // 
            // btn_klbr_simpan
            // 
            this.btn_klbr_simpan.Location = new System.Drawing.Point(606, 72);
            this.btn_klbr_simpan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_klbr_simpan.Name = "btn_klbr_simpan";
            this.btn_klbr_simpan.Size = new System.Drawing.Size(165, 32);
            this.btn_klbr_simpan.TabIndex = 24;
            this.btn_klbr_simpan.Text = "Simpan";
            this.btn_klbr_simpan.UseVisualStyleBackColor = true;
            this.btn_klbr_simpan.Click += new System.EventHandler(this.btn_klbr_simpan_Click);
            // 
            // btn_kembali
            // 
            this.btn_kembali.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kembali.Location = new System.Drawing.Point(606, 35);
            this.btn_kembali.Name = "btn_kembali";
            this.btn_kembali.Size = new System.Drawing.Size(164, 32);
            this.btn_kembali.TabIndex = 42;
            this.btn_kembali.Text = "Menu utama";
            this.btn_kembali.UseVisualStyleBackColor = true;
            this.btn_kembali.Click += new System.EventHandler(this.btn_kembali_Click);
            // 
            // btn_cari
            // 
            this.btn_cari.Location = new System.Drawing.Point(367, 203);
            this.btn_cari.Name = "btn_cari";
            this.btn_cari.Size = new System.Drawing.Size(75, 23);
            this.btn_cari.TabIndex = 43;
            this.btn_cari.Text = "Cari";
            this.btn_cari.UseVisualStyleBackColor = true;
            this.btn_cari.Click += new System.EventHandler(this.btn_cari_Click);
            // 
            // txt_cari_barang
            // 
            this.txt_cari_barang.Location = new System.Drawing.Point(151, 204);
            this.txt_cari_barang.Name = "txt_cari_barang";
            this.txt_cari_barang.Size = new System.Drawing.Size(210, 22);
            this.txt_cari_barang.TabIndex = 44;
            this.txt_cari_barang.TextChanged += new System.EventHandler(this.txt_cari_barang_TextChanged);
            // 
            // barangTableAdapter
            // 
            this.barangTableAdapter.ClearBeforeFill = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.barangBindingSource;
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
            this.bindingNavigator1.Size = new System.Drawing.Size(782, 27);
            this.bindingNavigator1.TabIndex = 47;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
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
            // UC_KelolaBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.txt_cari_barang);
            this.Controls.Add(this.btn_cari);
            this.Controls.Add(this.btn_kembali);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnTestInjection);
            this.Controls.Add(this.cmb_admin_kondisi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_klbr_kategori);
            this.Controls.Add(this.btn_klbr_refresh);
            this.Controls.Add(this.btn_klbr_hapus);
            this.Controls.Add(this.btn_klbr_ubah);
            this.Controls.Add(this.dgv_kelolabarang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_klbr_stok);
            this.Controls.Add(this.txt_klbr_nama);
            this.Controls.Add(this.btn_klbr_simpan);
            this.Name = "UC_KelolaBarang";
            this.Load += new System.EventHandler(this.UC_KelolaBarang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLabSekolahDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kelolabarang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTestInjection;
        private System.Windows.Forms.ComboBox cmb_admin_kondisi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_klbr_kategori;
        private System.Windows.Forms.Button btn_klbr_refresh;
        private System.Windows.Forms.Button btn_klbr_hapus;
        private System.Windows.Forms.Button btn_klbr_ubah;
        private System.Windows.Forms.DataGridView dgv_kelolabarang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_klbr_stok;
        private System.Windows.Forms.TextBox txt_klbr_nama;
        private System.Windows.Forms.Button btn_klbr_simpan;
        private System.Windows.Forms.Button btn_kembali;
        private System.Windows.Forms.Button btn_cari;
        private System.Windows.Forms.TextBox txt_cari_barang;
        private DBLabSekolahDataSet dBLabSekolahDataSet;
        private System.Windows.Forms.BindingSource barangBindingSource;
        private DBLabSekolahDataSetTableAdapters.BarangTableAdapter barangTableAdapter;
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
    }
}