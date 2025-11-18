# SQLite Kurulum ve Kullanım Rehberi

## SQLite Avantajları

- ✅ **Kurulum gerektirmez**
- ✅ **Dosya tabanlı veritabanı**
- ✅ **Taşınabilir**
- ✅ **Hızlı ve güvenilir**
- ✅ **Ek sunucu gerektirmez**

## 1. SQLite Veritabanlarını Oluşturma

### Adım 1: Database Klasörü Oluşturun
Proje klasöründe `Database` klasörü oluşturun:
```
HospitalIntegrationApp/
├── Database/
│   ├── vakif.db
│   ├── devlet.db
│   └── master.db
```

### Adım 2: SQLite Browser Kurulumu
1. **DB Browser for SQLite** indirin (ücretsiz)
2. Kurulumu tamamlayın

### Adım 3: Veritabanlarını Oluşturun

#### Vakıf Hastanesi (vakif.db):
1. **DB Browser for SQLite**'ı açın
2. **New Database** → `vakif.db` olarak kaydedin
3. **13_SQLite_Create_Databases.sql** scriptini çalıştırın

#### Devlet Hastanesi (devlet.db):
1. **New Database** → `devlet.db` olarak kaydedin
2. **14_SQLite_Devlet_DB.sql** scriptini çalıştırın

#### Master Veritabanı (master.db):
1. **New Database** → `master.db` olarak kaydedin
2. **15_SQLite_Master_DB.sql** scriptini çalıştırın

## 2. Uygulamayı Test Edin

1. **Hastane Entegrasyon Uygulaması**'nı çalıştırın
2. **Hastaları Getir** butonuna tıklayın
3. **10 hasta** (5 Vakıf + 5 Devlet) görünmeli

## 3. Veri Kontrolü

DB Browser for SQLite'da:
```sql
-- Vakıf hastalarını kontrol edin
SELECT * FROM vakif_hastalar;

-- Devlet hastalarını kontrol edin
SELECT * FROM devlet_hastalar;
```

## 4. Sorun Giderme

### SQLite Dosyaları Bulunamıyor:
1. `Database` klasörünün oluşturulduğunu kontrol edin
2. `.db` dosyalarının doğru konumda olduğunu kontrol edin
3. Uygulamayı **Administrator** olarak çalıştırın

### System.Data.SQLite Hatası:
1. **NuGet Package Manager**'ı açın
2. **System.Data.SQLite** paketini arayın ve yükleyin
3. Projeyi yeniden derleyin

## 5. Test Verileri

Script çalıştırıldıktan sonra:
- **vakif.db**: 5 hasta kaydı
- **devlet.db**: 5 hasta kaydı
- **master.db**: Boş (entegrasyon için hazır)

## 6. Başarı Kontrolü

Uygulama çalıştığında:
- ✅ **Hastaları Getir** butonu çalışmalı
- ✅ **10 hasta** görünmeli
- ✅ **Hata mesajı** olmamalı
- ✅ **Veri grid** dolu olmalı

## 7. Dosya Yapısı

```
HospitalIntegrationApp/
├── Database/
│   ├── vakif.db (Vakıf hastanesi verileri)
│   ├── devlet.db (Devlet hastanesi verileri)
│   └── master.db (Master veritabanı)
├── DatabaseScripts/
│   ├── 13_SQLite_Create_Databases.sql
│   ├── 14_SQLite_Devlet_DB.sql
│   ├── 15_SQLite_Master_DB.sql
│   └── 16_SQLite_Setup_Guide.md
└── HospitalIntegrationApp.exe
```

## 8. Avantajlar

- **Kurulum gerektirmez**: SQLite dosya tabanlı
- **Taşınabilir**: Tüm dosyalar proje klasöründe
- **Hızlı**: Yerel dosya erişimi
- **Güvenilir**: SQLite çok stabil
- **Ücretsiz**: Ek lisans gerektirmez











