-- SQLite Veritabanları Oluşturma Scripti
-- SQLite Browser veya DB Browser for SQLite'da çalıştırın

-- 1. VAKIF Hastanesi veritabanı (vakif.db)
-- Bu scripti vakif.db dosyasında çalıştırın

CREATE TABLE IF NOT EXISTS vakif_hastalar (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    ad TEXT NOT NULL,
    soyad TEXT NOT NULL,
    dogum_tarihi TEXT NOT NULL,
    kayit_tarihi TEXT DEFAULT CURRENT_TIMESTAMP
);

-- Test verileri
INSERT INTO vakif_hastalar (ad, soyad, dogum_tarihi) VALUES 
('Ahmet', 'Yılmaz', '1985-03-15'),
('Fatma', 'Demir', '1990-07-22'),
('Mehmet', 'Kaya', '1978-11-08'),
('Ayşe', 'Özkan', '1992-05-14'),
('Ali', 'Çelik', '1987-09-30');

-- Veri kontrolü
SELECT 'VAKIF HASTALAR' AS tablo, COUNT(*) AS kayit_sayisi FROM vakif_hastalar;










