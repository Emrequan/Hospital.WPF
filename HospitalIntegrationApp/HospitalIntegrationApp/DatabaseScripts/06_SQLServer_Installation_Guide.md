# SQL Server Express Kurulum Rehberi

## Hata: "SQL Server için bağlantı açılamadı"

Bu hata SQL Server'ın kurulu olmadığı veya çalışmadığı için oluşuyor.

## Çözüm 1: SQL Server Express Kurulumu

### 1. SQL Server Express İndirin
- Microsoft resmi sitesinden "SQL Server Express" indirin
- Sürüm: 2019 veya 2022 (en son sürüm)
- Platform: Windows x64

### 2. Kurulum Adımları
1. İndirilen dosyayı çalıştırın
2. "Basic" kurulum seçin
3. "Accept" butonuna tıklayın
4. Kurulum tamamlanana kadar bekleyin

### 3. SQL Server Management Studio (SSMS) Kurulumu
- SSMS'i ayrıca indirin ve kurun
- Bu veritabanlarını yönetmek için gerekli

### 4. SQL Server Servisini Başlatın
1. Windows Services'ı açın (services.msc)
2. "SQL Server (SQLEXPRESS)" servisini bulun
3. Sağ tık → Start (Eğer durmuşsa)

### 5. Bağlantı Testi
SSMS'de bağlantı testi yapın:
- Server name: `localhost\SQLEXPRESS` veya `.\SQLEXPRESS`
- Authentication: Windows Authentication

## Çözüm 2: LocalDB Kullanımı (Daha Kolay)

SQL Server Express kurulumu karmaşık geliyorsa, LocalDB kullanabilirsiniz:

### Avantajları:
- SQL Server Express'in hafif versiyonu
- Otomatik kurulum
- Ek yapılandırma gerektirmez
- Geliştirme için ideal

### LocalDB için Connection String:
```xml
<add name="Vakif" connectionString="Server=(localdb)\MSSQLLocalDB;Database=VAKIF_DB;Integrated Security=True;" />
<add name="Devlet" connectionString="Server=(localdb)\MSSQLLocalDB;Database=DEVLET_DB;Integrated Security=True;" />
<add name="Master" connectionString="Server=(localdb)\MSSQLLocalDB;Database=MASTER_DB;Integrated Security=True;" />
```

## Çözüm 3: SQLite Kullanımı (En Kolay)

Tamamen dosya tabanlı veritabanı:

### Avantajları:
- Kurulum gerektirmez
- Tek dosya veritabanı
- Taşınabilir
- Hızlı kurulum

### SQLite için gerekli değişiklikler:
1. System.Data.SQLite NuGet paketi ekleyin
2. Connection string'leri SQLite formatına çevirin
3. Factory sınıflarını SQLite için güncelleyin

## Test Bağlantısı

SQL Server kurulumundan sonra bağlantıyı test etmek için:

```sql
-- SSMS'de test
SELECT @@VERSION;
```

## Sorun Giderme

### Hala hata alıyorsanız:
1. SQL Server servisinin çalıştığını kontrol edin
2. Windows Firewall ayarlarını kontrol edin
3. SQL Server Browser servisini başlatın
4. Uygulamayı Administrator olarak çalıştırın

### Port Kontrolü:
- SQL Server varsayılan port: 1433
- Named Pipes: \\.\pipe\sql\query











