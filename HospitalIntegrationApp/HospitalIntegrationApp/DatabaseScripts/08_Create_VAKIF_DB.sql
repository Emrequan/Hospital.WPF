-- VAKIF_DB veritabanı için script
-- SQL Server Object Explorer'da VAKIF_DB seçili iken çalıştırın

USE VAKIF_DB;
GO

-- Tablo oluşturma
CREATE TABLE VAKIF_HASTALAR (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    AD NVARCHAR(50) NOT NULL,
    SOYAD NVARCHAR(50) NOT NULL,
    DOGUM_TARIHI DATE NOT NULL,
    KAYIT_TARIHI DATETIME DEFAULT GETDATE()
);

-- Test verileri ekleme
INSERT INTO VAKIF_HASTALAR (AD, SOYAD, DOGUM_TARIHI) VALUES 
('Ahmet', 'Yılmaz', '1985-03-15'),
('Fatma', 'Demir', '1990-07-22'),
('Mehmet', 'Kaya', '1978-11-08'),
('Ayşe', 'Özkan', '1992-05-14'),
('Ali', 'Çelik', '1987-09-30');

-- Veri kontrolü
SELECT * FROM VAKIF_HASTALAR;










