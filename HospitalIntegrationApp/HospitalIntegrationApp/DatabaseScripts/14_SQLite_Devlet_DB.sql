-- SQLite Devlet Hastanesi Veritabanı (devlet.db)
-- Bu scripti devlet.db dosyasında çalıştırın

CREATE TABLE IF NOT EXISTS devlet_hastalar (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    isim TEXT NOT NULL,
    soyisim TEXT NOT NULL,
    dogumyili TEXT NOT NULL,
    kayit_tarihi TEXT DEFAULT CURRENT_TIMESTAMP
);

-- Test verileri
INSERT INTO devlet_hastalar (isim, soyisim, dogumyili) VALUES 
('Zeynep', 'Arslan', '1983'),
('Mustafa', 'Şahin', '1991'),
('Elif', 'Türk', '1989'),
('Hasan', 'Güneş', '1975'),
('Selin', 'Koç', '1994');

-- Veri kontrolü
SELECT 'DEVLET HASTALAR' AS tablo, COUNT(*) AS kayit_sayisi FROM devlet_hastalar;











