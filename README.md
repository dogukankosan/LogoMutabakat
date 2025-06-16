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
---

## 📂 Klasör Yapısı

LogoMutabakat/
├── NotificationService/ # Windows servisi (WhatsApp & Mail gönderimi)
├── WinFormsUI/ # Masaüstü arayüz (Grid, Onay/Reddet vs)
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

- SQL’den veriyi çeker
- Excel/PDF oluşturur
- WhatsApp API (Twilio) veya Mail ile gönderir
- Durumu loglar

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

## 🤝 Katkı

---

Katkı sağlamak için projeyi forklayabilir ve pull request gönderebilirsiniz.
## 📄 Lisans

MIT License

---

## 📬 İletişim

- 👨‍💻 Geliştirici: [@dogukankosan](https://github.com/dogukankosan)  
- 🐞 Suggestions or issues: [Issues sekmesi](https://github.com/dogukankosan/LogoWhatsappEntegrasyon/issues)

---

