![indir](https://github.com/user-attachments/assets/380a0145-c5d5-4f51-8ba0-96375f580208)

---

# Logo Mutabakat

**Logo ERP verisi ile entegre çalışan mutabakat gönderim ve yanıt takip sistemi**  
Bu proje, SQL üzerinden Logo ERP'deki carilere ait mutabakat bilgilerini çekip, WhatsApp ve e‑posta ile PDF formatında gönderim yapmayı ve gelen dönüşleri takip etmeyi amaçlayan bir Windows servis/masaüstü uygulamasıdır.

---

## 🚀 Öne Çıkan Özellikler

- **Logo ERP verisi ile entegre çalışır** (doğrudan SQL bağlantısıyla)
- **WhatsApp ve E‑posta üzerinden PDF mutabakat gönderimi**
- **PDF oluşturma, döviz kuru ve para formatı desteği**
- **SQLite + SQL Server destekli yapı**
- **Gönderim sonrası renkli durum takibi ve loglama sistemi**
- **Quartz.NET ile zamanlanmış görev desteği (servis versiyonunda)**

---

## 📂 Klasör Yapısı

LogoMutabakat/
├── NotificationService/ # Windows servisi (WhatsApp & Mail gönderimi)
├── WinFormsUI/ # Masaüstü arayüz (Grid, Onay/Reddet vs)
├── SQLScripts/ # Logo tabloları için örnek sorgular
├── Resources/ # PDF şablonları, resimler
├── SQLite/ # Yerel konfigürasyon ve görev veritabanı
└── README.md # Bu dosya

---

## 🔧 Başlangıç (Manual)

1. **Bağlantı Ayarlarını Yap**  
   `WinForms` uygulamasından SQL bağlantı bilgilerini gir, test et ve kaydet (şifrelenmiş şekilde SQLite’e yazılır).

2. **Mutabakatları Listele ve Gönder**  
   GridView üzerinden carileri seç, ister e‑posta ister WhatsApp ile gönder. Gönderim sonrası satırlar yeşil/kırmızı olarak işaretlenir.

3. **PDF ve Loglar**  
   Tüm gönderimler PDF olarak oluşturulur ve loglanır. Gönderim detayları `PDFSNotification` tablosuna yazılır.

---

## 🕒 Zamanlanmış Görevler (Servis Versiyonu)

`NoktaBilgiNotificationService` içinde yer alan Quartz.NET zamanlayıcı şu işlemleri periyodik olarak yapar:

- SQL’den veriyi çeker
- Excel/PDF oluşturur
- WhatsApp API (Twilio) veya Mail ile gönderir
- Durumu loglar

Servis arka planda çalışır ve SQLite üzerinden görevlerini okur.

---

## 💡 Teknik Detaylar

- .NET Framework 4.8 (hem UI hem servis için)
- DevExpress GridView UI bileşenleri
- Twilio WhatsApp API entegrasyonu
- FluentValidation ile form doğrulama
- SHA256 şifreleme, bağlantı bilgisi koruma
- PDF: iTextSharp veya benzeri kütüphane

---

## 🧪 Geliştirici Notları

- Tüm SQL işlemleri parametrik sorgularla ve `SQLCrud` sınıfı ile yapılır.
- Log işlemleri merkezi `Logging` sınıfında tutulur (`LogAdd`).
- Her türlü hata try‑catch ile yakalanır ve hem kullanıcıya gösterilir hem de loglanır.

---

## 📄 Lisans

MIT License

---

## 📬 İletişim

🧠 Proje geliştiricisi: [@dogukankosan](https://github.com/dogukankosan)  
🐞 Hata bildirmek veya katkıda bulunmak için [Issues](https://github.com/dogukankosan/LogoMutabakat/issues) sekmesini kullanabilirsin.

