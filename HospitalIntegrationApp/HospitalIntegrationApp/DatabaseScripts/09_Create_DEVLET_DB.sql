-- DEVLET_DB veritabanı için script
-- SQL Server Object Explorer'da DEVLET_DB seçili iken çalıştırın

USE DEVLET_DB;
GO

-- Tablo oluşturma
CREATE TABLE DEVLET_HASTALAR (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ISIM NVARCHAR(50) NOT NULL,
    SOYISIM NVARCHAR(50) NOT NULL,
    DOGUMYILI NVARCHAR(10) NOT NULL,
    KAYIT_TARIHI DATETIME DEFAULT GETDATE()
);

-- Test verileri ekleme
INSERT INTO DEVLET_HASTALAR (ISIM, SOYISIM, DOGUMYILI) VALUES 
('Zeynep', 'Arslan', '1983'),
('Mustafa', 'Şahin', '1991'),
('Elif', 'Türk', '1989'),
('Hasan', 'Güneş', '1975'),
('Selin', 'Koç', '1994');

-- Veri kontrolü
SELECT * FROM DEVLET_HASTALAR;










