• Form koneksi
<img width="749" height="493" alt="image" src="https://github.com/user-attachments/assets/306c5c5c-6950-4c7f-a717-acf50bda3c05" />


• Form input data
<img width="745" height="490" alt="image" src="https://github.com/user-attachments/assets/b2289ddb-6b84-4284-a5d6-e55ea06097bb" />

• Form tampilan data
<img width="738" height="483" alt="image" src="https://github.com/user-attachments/assets/3b9427fc-22fb-4991-a74c-4a02c92bc715" />

• Bukti insert, update, delete, dan search
insert
<img width="741" height="485" alt="image" src="https://github.com/user-attachments/assets/0deffd83-73c2-4044-9a20-8ee49710d8f4" />
update
<img width="980" height="691" alt="image" src="https://github.com/user-attachments/assets/38b60249-1553-49f7-a653-f6e40c7b4b38" />
delete
<img width="989" height="657" alt="image" src="https://github.com/user-attachments/assets/89cd48d9-0089-4e48-b962-37dbfbc1b69b" />

<img width="747" height="488" alt="image" src="https://github.com/user-attachments/assets/54c7fa20-eb00-43eb-8c3f-998fd684abd2" />



#### :Simulasi Sabotase AMILS

Skenario ini bermula dari situasi nyata di lingkungan sekolah. Bayangkan seorang Admin Lab yang sedang terburu-buru keluar ruangan dan lupa melakukan *logout* dari aplikasinya. Komputer tersebut ditinggalkan dalam keadaan terbuka, menampilkan dashboard **Kelola Barang**.

#### 1. Kesempatan Muncul

Seorang siswa yang memiliki niat iseng melihat kesempatan ini. Ia duduk di depan komputer tersebut dan mulai menjelajahi fitur yang ada. Pandangannya tertuju pada sebuah tombol bertanda **"test inject"** yang terletak di tab Kelola Barang. Tombol ini sebenarnya sengaja diletakkan di sana untuk tujuan pengujian keamanan, namun bagi orang asing, ini adalah pintu masuk untuk melakukan kekacauan.

#### 2. Serangan Dimulai

Siswa tersebut memasukkan kode aneh pada kolom **Nama Barang**:

`' OR 1=1 --` 

Ia kemudian menekan tombol **test inject**. Di balik layar, aplikasi secara teledor langsung menggabungkan kode aneh tersebut ke dalam perintah SQL mentah:

`UPDATE Barang SET Stok = 0, Kondisi = 'Rusak' WHERE NamaBarang = '' OR 1=1 --'`.

#### 3.Logikan yang terlewatkan

Database SQL Server menerima perintah tersebut dan mulai memprosesnya. Penggunaan tanda kutip (`'`) secara paksa menghentikan pencarian nama barang yang asli. Perintah **`OR 1=1`** menciptakan sebuah kondisi logika yang selalu bernilai **BENAR** untuk setiap baris data. Terakhir, tanda strip ganda (**`--`**) membuat sisa perintah di belakangnya dianggap sebagai komentar tak berguna agar sistem tidak mengeluarkan pesan kesalahan (*error*).

#### 4. Dampak Kerusakan

Karena kondisi pengecekan dipaksa menjadi selalu benar, database tidak lagi menyaring barang tertentu. Secara otomatis, **seluruh baris data** di tabel Barang diubah dalam sekejap. Notifikasi muncul di layar menunjukkan bahwa banyak baris data berhasil diperbarui. Kini, seluruh stok inventaris laboratorium berubah menjadi **0** dan semua status kondisi menjadi **'Rusak'**. Hasilnya, operasional laboratorium lumpuh total karena tidak ada barang yang tersedia untuk dipinjam.

