# Oracle SQL Developer Kurulum ve Veritabanı Hazırlama Rehberi

## 1. Oracle SQL Developer'ı Açın

## 2. Yeni Bağlantı Oluşturun

### Vakıf Hastanesi Bağlantısı:
- **Connection Name**: Vakif_Hastanesi
- **Username**: vakif_user
- **Password**: vakif123
- **Hostname**: localhost
- **Port**: 1521
- **SID**: XE (veya kendi SID'niz)

### Devlet Hastanesi Bağlantısı:
- **Connection Name**: Devlet_Hastanesi
- **Username**: devlet_user
- **Password**: devlet123
- **Hostname**: localhost
- **Port**: 1521
- **SID**: XE (veya kendi SID'niz)

### Master Veritabanı Bağlantısı:
- **Connection Name**: Master_DB
- **Username**: master_user
- **Password**: master123
- **Hostname**: localhost
- **Port**: 1521
- **SID**: XE (veya kendi SID'niz)

## 3. Kullanıcıları Oluşturun

Her bağlantı için aşağıdaki SQL'leri çalıştırın:

```sql
-- Vakıf kullanıcısı
CREATE USER vakif_user IDENTIFIED BY vakif123;
GRANT CONNECT, RESOURCE TO vakif_user;
GRANT CREATE TABLE TO vakif_user;

-- Devlet kullanıcısı
CREATE USER devlet_user IDENTIFIED BY devlet123;
GRANT CONNECT, RESOURCE TO devlet_user;
GRANT CREATE TABLE TO devlet_user;

-- Master kullanıcısı
CREATE USER master_user IDENTIFIED BY master123;
GRANT CONNECT, RESOURCE TO master_user;
GRANT CREATE TABLE TO master_user;
```

## 4. Scriptleri Çalıştırın

1. **01_Create_Databases.sql** - Tabloları oluşturur
2. **02_Insert_Test_Data.sql** - Test verilerini ekler

## 5. Bağlantı Testi

Her bağlantıyı test edin ve tabloların oluştuğunu kontrol edin:

```sql
-- Vakıf tablosu kontrolü
SELECT * FROM VAKIF_HASTALAR;

-- Devlet tablosu kontrolü  
SELECT * FROM DEVLET_HASTALAR;
```

## 6. Uygulama Ayarları

`App.config` dosyasındaki connection string'leri kendi Oracle sunucu bilgilerinize göre güncelleyin:

```xml
<add name="Vakif" connectionString="Data Source=YOUR_HOST:1521/YOUR_SID;User Id=vakif_user;Password=vakif123;" />
<add name="Devlet" connectionString="Data Source=YOUR_HOST:1521/YOUR_SID;User Id=devlet_user;Password=devlet123;" />
<add name="Master" connectionString="Data Source=YOUR_HOST:1521/YOUR_SID;User Id=master_user;Password=master123;" />
```

## 7. Oracle Client Kurulumu

Uygulama System.Data.OracleClient kullanır, bu .NET Framework'ün bir parçasıdır. Ek kurulum gerekmez.

**Not**: .NET Framework 4.0+ sürümlerinde System.Data.OracleClient deprecated olmuştur. Eğer sorun yaşarsanız Oracle Data Access Client (ODAC) kurmanız gerekebilir.

## 8. Alternatif Çözüm (Oracle Data Access Client)

Eğer System.Data.OracleClient çalışmazsa:

1. Oracle Data Access Client (ODAC) indirin ve kurun
2. csproj dosyasında System.Data.OracleClient yerine Oracle.DataAccess.Client kullanın
3. Connection string formatını güncelleyin
