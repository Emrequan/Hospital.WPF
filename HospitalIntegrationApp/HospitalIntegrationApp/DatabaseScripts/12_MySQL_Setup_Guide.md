# MySQL Kurulum ve Kullanım Rehberi

## MySQL Veritabanları Oluşturma

### 1. MySQL Servisini Başlatın
- **Windows Services**'da "MySQL" servisini başlatın
- Veya **XAMPP/WAMP** kullanıyorsanız Apache ve MySQL'i başlatın

### 2. MySQL'e Bağlanın

#### Seçenek A: MySQL Workbench
1. **MySQL Workbench**'i açın
2. **Local instance** bağlantısına tıklayın
3. **Password** girin (varsayılan: boş)

#### Seçenek B: phpMyAdmin
1. **XAMPP/WAMP** kullanıyorsanız
2. **http://localhost/phpmyadmin** adresine gidin
3. **root** kullanıcısı ile giriş yapın

#### Seçenek C: Komut Satırı
```bash
mysql -u root -p
```

### 3. Veritabanlarını Oluşturun

**11_MySQL_Create_Databases.sql** scriptini çalıştırın:

1. **MySQL Workbench**'de:
   - File → Open SQL Script
   - Script'i seçin ve çalıştırın

2. **phpMyAdmin**'de:
   - SQL sekmesine gidin
   - Script'i yapıştırın ve çalıştırın

### 4. Bağlantı Testi

```sql
-- Veritabanlarını kontrol edin
SHOW DATABASES;

-- Vakıf hastalarını kontrol edin
USE vakif_db;
SELECT * FROM vakif_hastalar;

-- Devlet hastalarını kontrol edin
USE devlet_db;
SELECT * FROM devlet_hastalar;
```

### 5. Uygulamayı Test Edin

1. **Hastane Entegrasyon Uygulaması**'nı çalıştırın
2. **Hastaları Getir** butonuna tıklayın
3. Veriler görünmeli

## Sorun Giderme

### MySQL Bağlantı Hatası Alıyorsanız:

1. **MySQL servisinin çalıştığını kontrol edin**
2. **Port 3306**'nın açık olduğunu kontrol edin
3. **Firewall** ayarlarını kontrol edin
4. **Connection string**'deki şifreyi kontrol edin

### App.config Güncellemesi:

Eğer MySQL şifreniz varsa:
```xml
<add name="Vakif" connectionString="Server=localhost;Database=vakif_db;Uid=root;Pwd=YOUR_PASSWORD;" />
```

### MySQL Connector Kurulumu:

Eğer MySql.Data referansı bulunamazsa:
1. **NuGet Package Manager**'ı açın
2. **MySql.Data** paketini arayın ve yükleyin
3. Projeyi yeniden derleyin

## Test Verileri

Script çalıştırıldıktan sonra:
- **VAKIF_DB**: 5 hasta kaydı
- **DEVLET_DB**: 5 hasta kaydı
- **MASTER_DB**: Boş (entegrasyon için hazır)

## Başarı Kontrolü

Uygulama çalıştığında:
- **Hastaları Getir** butonu çalışmalı
- **10 hasta** (5 Vakıf + 5 Devlet) görünmeli
- **Hata mesajı** olmamalı











