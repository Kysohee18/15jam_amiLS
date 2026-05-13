CREATE DATABASE DBLabSekolah;
GO
USE DBLabSekolah;
GO

-- 1. Tabel Kategori 
CREATE TABLE Kategori (*/
    IDKategori INT PRIMAR+Y KEY IDENTITY(1,1),
    NamaKategori VARCHAR(50) NOT NULL
);

-- 2. Tabel Barang 
CREATE TABLE Barang (
    IDBarang CHAR(5) PRIMARY KEY, -- contoh id: BRG01
    NamaBarang VARCHAR(100) NOT NULL UNIQUE,
    IDKategori INT,
    Stok INT CHECK (Stok >= 0), 
    Kondisi VARCHAR(20) CHECK (Kondisi IN ('Baik', 'Rusak', 'Perbaikan')),
    CONSTRAINT FK_Barang_Kategori FOREIGN KEY (IDKategori) REFERENCES Kategori(IDKategori)
);

-- 3. Tabel UserLab 
CREATE TABLE UserLab (
    IDUser CHAR(11) PRIMARY KEY, 
    NamaUser VARCHAR(100) NOT NULL,
    RoleUser VARCHAR(20) CHECK (RoleUser IN ('Siswa','Guru','Admin','PenjagaLab')), 
    Password VARCHAR(255) NOT NULL,
    TanggunganPinjam INT DEFAULT 0
);

-- 4. Tabel Transaksi
CREATE TABLE Transaksi (
    IDTransaksi INT PRIMARY KEY IDENTITY(1,1),
    IDBarang CHAR(5) NOT NULL,
    IDUser CHAR(11) NOT NULL,
    TanggalPinjam DATETIME DEFAULT GETDATE( ),
    TanggalKembali DATETIME NULL,
    StatusTrans VARCHAR(20) DEFAULT 'Dipinjam',
    CONSTRAINT FK_Transaksi_Barang FOREIGN KEY (IDBarang) REFERENCES Barang(IDBarang),
    CONSTRAINT FK_Transaksi_User FOREIGN KEY (IDUser) REFERENCES UserLab(IDUser)
);

CREATE TABLE LogTransaksi (
    IDLog          INT PRIMARY KEY IDENTITY(1,1), --nomor log
    IDTransaksi    INT NOT NULL, 
    Aksi           VARCHAR(20) NOT NULL CHECK (Aksi IN ('PINJAM', 'KEMBALI')),
    IDBarang       CHAR(5) NOT NULL,
    IDUser         CHAR(11) NOT NULL,
    WaktuKejadian  DATETIME NOT NULL DEFAULT GETDATE(),
    Keterangan     VARCHAR(255) NULL
);
GO

-- STORED PROCEDURE UCP 2 JAYA JAYA JAYA

/* sotred procedure untuk manajemen barang formAdmin */  
-- untuk menampilkan data barang
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

--insert barang baru
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

-- update data barang
CREATE PROCEDURE sp_UpdateBarang
    @IDBarang INT,
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

-- delete barang
CREATE PROCEDURE sp_DeleteBarang
    @IDBarang INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Barang WHERE IDBarang = @IDBarang;
END
GO
 
-- dgv kelola user
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

-- add user
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

-- delete user
CREATE PROCEDURE sp_DeleteUser
    @IDUser INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM UserLab WHERE IDUser = @IDUser;
END
GO

-- udpate user
CREATE PROCEDURE sp_UpdateUser
    @IDUser INT,
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

/* sotred procedure untuk formPenjaga */ 

-- data grid view peminjaman
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

--data grid view pengembalian

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

--peminjaman
CREATE PROCEDURE sp_InsertPeminjaman
    @IDBarang INT,
    @IDUser INT
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

--pengembalian 

CREATE PROCEDURE sp_UpdatePengembalian
    @IDTransaksi INT,
    @IDBarang INT,
    @IDUser INT
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

--log transaksi
CREATE PROCEDURE sp_InsertLogTransaksi
    @IDTransaksi INT,
    @Aksi VARCHAR(20),
    @IDBarang INT,
    @IDUser INT,
    @Keterangan VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO LogTransaksi (IDTransaksi, Aksi, IDBarang, IDUser, WaktuKejadian, Keterangan)
    VALUES (@IDTransaksi, @Aksi, @IDBarang, @IDUser, GETDATE(), @Keterangan);
END
GO
