-- MySQL Veritabanları Oluşturma Scripti
-- MySQL Workbench veya phpMyAdmin'de çalıştırın

-- 1. VAKIF Hastanesi veritabanı
CREATE DATABASE IF NOT EXISTS vakif_db;
USE vakif_db;

CREATE TABLE IF NOT EXISTS vakif_hastalar (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ad VARCHAR(50) NOT NULL,
    soyad VARCHAR(50) NOT NULL,
    dogum_tarihi DATE NOT NULL,
    kayit_tarihi TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Test verileri
INSERT INTO vakif_hastalar (ad, soyad, dogum_tarihi) VALUES 
('Ahmet', 'Yılmaz', '1985-03-15'),
('Fatma', 'Demir', '1990-07-22'),
('Mehmet', 'Kaya', '1978-11-08'),
('Ayşe', 'Özkan', '1992-05-14'),
('Ali', 'Çelik', '1987-09-30');

-- 2. DEVLET Hastanesi veritabanı
CREATE DATABASE IF NOT EXISTS devlet_db;
USE devlet_db;

CREATE TABLE IF NOT EXISTS devlet_hastalar (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ad VARCHAR(50) NOT NULL,
    soyad VARCHAR(50) NOT NULL,
    dogum_tarihi date NOT NULL,
    kayit_tarihi TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Test verileri
INSERT INTO devlet_hastalar (isim, soyisim, dogumyili) VALUES 
('Zeynep', 'Arslan', '1983'),
('Mustafa', 'Şahin', '1991'),
('Elif', 'Türk', '1989'),
('Hasan', 'Güneş', '1975'),
('Selin', 'Koç', '1994');

-- 3. MASTER veritabanı
CREATE DATABASE IF NOT EXISTS master_db;
USE master_db;

CREATE TABLE IF NOT EXISTS master_hastalar (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ad VARCHAR(50) NOT NULL,
    soyad VARCHAR(50) NOT NULL,
    dogum_tarihi DATE NOT NULL,
    hastane_no INT NOT NULL,
    kayit_tarihi TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    kaynak_hastane VARCHAR(50)
);

-- Veri kontrolü
SELECT 'VAKIF HASTALAR' AS tablo, COUNT(*) AS kayit_sayisi FROM vakif_db.vakif_hastalar
UNION ALL
SELECT 'DEVLET HASTALAR' AS tablo, COUNT(*) AS kayit_sayisi FROM devlet_db.devlet_hastalar;









