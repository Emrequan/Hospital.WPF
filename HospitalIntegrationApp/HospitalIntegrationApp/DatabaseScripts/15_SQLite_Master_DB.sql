-- SQLite Master Veritabanı (master.db)
-- Bu scripti master.db dosyasında çalıştırın

CREATE TABLE IF NOT EXISTS master_hastalar (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    ad TEXT NOT NULL,
    soyad TEXT NOT NULL,
    dogum_tarihi TEXT NOT NULL,
    hastane_no INTEGER NOT NULL,
    kayit_tarihi TEXT DEFAULT CURRENT_TIMESTAMP,
    kaynak_hastane TEXT
);

-- Veri kontrolü
SELECT 'MASTER HASTALAR' AS tablo, COUNT(*) AS kayit_sayisi FROM master_hastalar;










