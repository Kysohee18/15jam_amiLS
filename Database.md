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
    NamaBarang VARCHAR(100) NOT NULL,
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