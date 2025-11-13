# Oracle Client Kurulum Rehberi

## Hata: "Oracle istemci version 8.1.7 veya daha sonraki sürümünü gerektirir"

Bu hata Oracle Client kurulu olmadığı için oluşuyor.

## Çözüm 1: Oracle Instant Client Kurulumu (Önerilen)

### 1. Oracle Instant Client İndirin
- Oracle resmi sitesinden "Oracle Instant Client" indirin
- Sürüm: 19c veya 21c (en son sürüm)
- Platform: Windows x64

### 2. Kurulum Adımları
1. İndirilen zip dosyasını `C:\oracle\instantclient_19_8` klasörüne çıkarın
2. Ortam değişkenlerine ekleyin:
   - `PATH` değişkenine: `C:\oracle\instantclient_19_8`
   - `TNS_ADMIN` değişkeni oluşturun: `C:\oracle\instantclient_19_8`

### 3. tnsnames.ora Dosyası Oluşturun
`C:\oracle\instantclient_19_8\tnsnames.ora` dosyası oluşturun:

```
XE =
  (DESCRIPTION =
    (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
    (CONNECT_DATA =
      (SERVER = DEDICATED)
      (SERVICE_NAME = XE)
    )
  )
```

### 4. Uygulamayı Yeniden Başlatın
Oracle Client kurulumundan sonra uygulamayı yeniden başlatın.

## Çözüm 2: SQL Server'a Geçiş (Daha Kolay)

Oracle Client kurulumu karmaşık geliyorsa, SQL Server kullanabilirsiniz:

### Avantajları:
- SQL Server Express ücretsiz
- .NET Framework ile tam uyumlu
- Ek client kurulumu gerektirmez
- Daha kolay kurulum

### Geçiş için:
1. SQL Server Express kurun
2. Connection string'leri SQL Server formatına çevirin
3. Factory sınıflarını SqlClient kullanacak şekilde güncelleyin

## Çözüm 3: Oracle XE Kurulumu

### Oracle Database Express Edition (XE) Kurulumu:
1. Oracle XE 21c indirin (ücretsiz)
2. Kurulum sırasında "Oracle Client" seçeneğini işaretleyin
3. Kurulum tamamlandıktan sonra uygulamayı test edin

## Test Bağlantısı

Oracle Client kurulumundan sonra bağlantıyı test etmek için:

```sql
-- SQL Developer'da test
SELECT * FROM VAKIF_HASTALAR;
SELECT * FROM DEVLET_HASTALAR;
```

## Sorun Giderme

### Hala hata alıyorsanız:
1. Bilgisayarı yeniden başlatın
2. PATH değişkenini kontrol edin
3. Oracle Client sürümünü kontrol edin
4. Uygulamayı Administrator olarak çalıştırın










