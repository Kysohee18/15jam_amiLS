# Dokumentasi Stored Procedure - Sistem Inventaris Lab amils  13/05/2026 | 1:41

--- 
#merupakan dokementasi untuk query store procedure yang tersedia pada setiap laptop kami
(berjalan di program kami)

## 1. Modul Admin (Manajemen Barang & User)

### -- sp_GetDataGridViewBarang
-- Menampilkan seluruh data barang beserta nama kategorinya untuk DataGridView.
CREATE PROCEDURE sp_GetDataGridViewBarang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        B.IDBarang, 
        B.NamaBarang, 
        K.NamaKategori, 
        B.Stok, 
        B.Kondisi
    FROM Barang B
    JOIN Kategori K ON B.IDKategori = K.IDKategori;
END
GO

### -- sp_InsertBarang
-- Menambahkan data barang baru ke dalam tabel Barang.
CREATE PROCEDURE sp_InsertBarang
    @NamaBarang VARCHAR(100),
    @IDKategori INT,
    @Stok INT,
    @Kondisi VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Barang (NamaBarang, IDKategori, Stok, Kondisi)
    VALUES (@NamaBarang, @IDKategori, @Stok, @Kondisi);
END
GO

### -- sp_UpdateBarang
-- Memperbarui informasi data barang berdasarkan IDBarang.
CREATE PROCEDURE sp_UpdateBarang
    @IDBarang CHAR(5),
    @NamaBarang VARCHAR(100),
    @IDKategori INT,
    @Stok INT,
    @Kondisi VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Barang 
    SET NamaBarang = @NamaBarang, 
        IDKategori = @IDKategori, 
        Stok = @Stok, 
        Kondisi = @Kondisi
    WHERE IDBarang = @IDBarang;
END
GO

### -- sp_DeleteBarang
-- Menghapus data barang dari database berdasarkan IDBarang.
CREATE PROCEDURE sp_DeleteBarang
    @IDBarang CHAR(5)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Barang WHERE IDBarang = @IDBarang;
END
GO

### -- sp_GetDataGridViewUser
-- Menampilkan daftar user yang terdaftar dalam sistem.
CREATE PROCEDURE sp_GetDataGridViewUser
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        IDUser, 
        NamaUser, 
        RoleUser, 
        TanggunganPinjam 
    FROM UserLab;
END
GO

### -- sp_InsertUser
-- Menambahkan user baru ke dalam sistem dengan password default dan tanggungan pinjam 0.
CREATE PROCEDURE sp_InsertUser
    @NamaUser VARCHAR(100),
    @RoleUser VARCHAR(20),
    @Password VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO UserLab (NamaUser, RoleUser, Password, TanggunganPinjam)
    VALUES (@NamaUser, @RoleUser, @Password, 0);
END
GO

### -- sp_UpdateUser
-- Memperbarui informasi nama, peran, atau password user.
CREATE PROCEDURE sp_UpdateUser
    @IDUser CHAR(11),
    @NamaUser VARCHAR(100),
    @RoleUser VARCHAR(20),
    @Password VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE UserLab 
    SET NamaUser = @NamaUser, 
        RoleUser = @RoleUser, 
        Password = @Password
    WHERE IDUser = @IDUser;
END
GO

### -- sp_DeleteUser
-- Menghapus akun user dari sistem.
CREATE PROCEDURE sp_DeleteUser
    @IDUser CHAR(11)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM UserLab WHERE IDUser = @IDUser;
END
GO

---

## 2. Modul Penjaga (Transaksi Peminjaman & Pengembalian)

### -- sp_GetDataGridViewPinjam
-- Menampilkan daftar transaksi yang sedang aktif (dipinjam).
CREATE PROCEDURE sp_GetDataGridViewPinjam
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        T.IDTransaksi, 
        B.NamaBarang, 
        U.NamaUser, 
        T.TanggalPinjam, 
        T.TanggalKembali, 
        T.StatusTrans
    FROM Transaksi T
    JOIN Barang B ON T.IDBarang = B.IDBarang
    JOIN UserLab U ON T.IDUser = U.IDUser;
END
GO

### -- sp_GetDataGridViewKembali
-- Menampilkan daftar transaksi yang sudah diselesaikan (kembali).
CREATE PROCEDURE sp_GetDataGridViewKembali
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        T.IDTransaksi, 
        B.NamaBarang, 
        U.NamaUser, 
        T.TanggalPinjam, 
        T.TanggalKembali, 
        T.StatusTrans
    FROM Transaksi T
    JOIN Barang B ON T.IDBarang = B.IDBarang
    JOIN UserLab U ON T.IDUser = U.IDUser
    WHERE T.StatusTrans = 'Kembali';
END
GO

### -- sp_InsertPeminjaman
-- Menangani proses peminjaman: mencatat transaksi, mengurangi stok barang, dan menambah tanggungan user.
CREATE PROCEDURE sp_InsertPeminjaman
    @IDBarang CHAR(5),
    @IDUser CHAR(11)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Transaksi (IDBarang, IDUser, TanggalPinjam, StatusTrans)
    VALUES (@IDBarang, @IDUser, GETDATE(), 'Dipinjam');

    UPDATE Barang 
    SET Stok = Stok - 1 
    WHERE IDBarang = @IDBarang;

    UPDATE UserLab 
    SET TanggunganPinjam = TanggunganPinjam + 1 
    WHERE IDUser = @IDUser;
END
GO

### -- sp_UpdatePengembalian
-- Menangani proses pengembalian: mencatat tanggal kembali, menambah stok barang, dan mengurangi tanggungan user.
CREATE PROCEDURE sp_UpdatePengembalian
    @IDTransaksi INT,
    @IDBarang CHAR(5),
    @IDUser CHAR(11)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Transaksi
    SET TanggalKembali = GETDATE(),
        StatusTrans = 'Kembali'
    WHERE IDTransaksi = @IDTransaksi;

    UPDATE Barang
    SET Stok = Stok + 1
    WHERE IDBarang = @IDBarang;

    UPDATE UserLab
    SET TanggunganPinjam = TanggunganPinjam - 1
    WHERE IDUser = @IDUser;
END
GO

---

## 3. Sistem, Validasi, & Log Transaksi

### -- sp_GetKategori
-- Mengambil daftar kategori untuk keperluan ComboBox.
CREATE PROCEDURE sp_GetKategori
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IDKategori, NamaKategori FROM Kategori;
END
GO

### -- sp_GetDataGridViewLog
-- Menampilkan riwayat transaksi secara mendetail untuk kebutuhan audit.
CREATE PROCEDURE sp_GetDataGridViewLog
AS
BEGIN
    SET NOCOUNT ON;
    SELECT l.IDLog, l.Aksi, b.NamaBarang, u.NamaUser AS 'Peminjam', l.WaktuKejadian, l.Keterangan 
    FROM LogTransaksi l
    JOIN Barang b ON l.IDBarang = b.IDBarang
    JOIN UserLab u ON l.IDUser = u.IDUser
    ORDER BY l.WaktuKejadian DESC;
END
GO

### -- sp_CheckPeminjamBarang
-- Memeriksa apakah suatu barang masih memiliki tanggungan peminjaman aktif (output berupa jumlah).
CREATE PROCEDURE sp_CheckPeminjamBarang
    @IDBarang CHAR(5),
    @Jumlah INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Jumlah = COUNT(*) 
    FROM Transaksi 
    WHERE IDBarang = @IDBarang AND StatusTrans = 'Dipinjam';
END
GO

### -- sp_GetBarangTersedia
-- Menampilkan daftar barang yang stoknya masih tersedia untuk dipinjam.
CREATE PROCEDURE sp_GetBarangTersedia
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IDBarang, NamaBarang, Stok, Kondisi 
    FROM Barang 
    WHERE Stok > 0;
END
GO

### -- sp_GetLogTransaksi
-- Alternatif tampilan log transaksi dengan alias aktor yang berbeda.
CREATE PROCEDURE sp_GetLogTransaksi
AS
BEGIN
    SET NOCOUNT ON;
    SELECT l.IDLog, l.Aksi, b.NamaBarang, u.NamaUser AS 'Aktor', l.WaktuKejadian, l.Keterangan 
    FROM LogTransaksi l
    JOIN Barang b ON l.IDBarang = b.IDBarang
    JOIN UserLab u ON l.IDUser = u.IDUser
    ORDER BY l.WaktuKejadian DESC;
END
GO

### -- sp_GetUserIDByName
-- Mengambil ID User berdasarkan nama (mendukung pencarian aman).
CREATE PROCEDURE sp_GetUserIDByName
    @NamaUser VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 IDUser FROM UserLab WHERE NamaUser = @NamaUser;
END
GO

### -- sp_InsertLogTransaksi
-- Mencatat aktivitas transaksi (PINJAM/KEMBALI) ke dalam tabel log.
CREATE PROCEDURE sp_InsertLogTransaksi
    @IDTransaksi INT,
    @Aksi VARCHAR(20),
    @IDBarang CHAR(5),
    @IDUser CHAR(11),
    @Keterangan VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO LogTransaksi (IDTransaksi, Aksi, IDBarang, IDUser, WaktuKejadian, Keterangan)
    VALUES (@IDTransaksi, @Aksi, @IDBarang, @IDUser, GETDATE(), @Keterangan);
END
GO
