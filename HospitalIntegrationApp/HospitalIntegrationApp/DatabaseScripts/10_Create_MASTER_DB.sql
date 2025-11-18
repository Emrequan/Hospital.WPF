-- MASTER_DB veritabanı için script
-- SQL Server Object Explorer'da MASTER_DB seçili iken çalıştırın

USE MASTER_DB;
GO

-- Tablo oluşturma
CREATE TABLE MASTER_HASTALAR (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    AD NVARCHAR(50) NOT NULL,
    SOYAD NVARCHAR(50) NOT NULL,
    DOGUM_TARIHI DATE NOT NULL,
    HASTANE_NO INT NOT NULL,
    KAYIT_TARIHI DATETIME DEFAULT GETDATE(),
    KAYNAK_HASTANE NVARCHAR(50)
);

-- Veri kontrolü
SELECT 'MASTER_DB tablosu oluşturuldu' AS DURUM;











