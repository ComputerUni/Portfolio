# Portfolio Yönetim Sistemi

Modern ve tam özellikli bir kişisel portföy web uygulaması. ASP.NET Core Razor Pages teknolojisi kullanılarak geliştirilmiştir. Yöneticilerin portföy içeriklerini kolaylıkla yönetmelerine ve ziyaretçilerin profesyonel profillerini görmelerine olanak tanır.

## 📋 İçindekiler

- [Proje Hakkında](#proje-hakkında)
- [Özellikler](#özellikler)
- [Teknoloji Stack](#teknoloji-stack)
- [Sistem Gereksinimleri](#sistem-gereksinimleri)
- [Kurulum](#kurulum)
- [Veritabanı Ayarı](#veritabanı-ayarı)
- [Proje Yapısı](#proje-yapısı)
- [Ana Modüller](#ana-modüller)
- [Veritabanı Şeması](#veritabanı-şeması)
- [Kimlik Doğrulama](#kimlik-doğrulama)
- [API Endpoints](#api-endpoints)
- [Kullanıcı Arayüzü](#kullanıcı-arayüzü)

## 🎯 Proje Hakkında

Portfolio Yönetim Sistemi, profesyonellerin kendi portföy web sitelerini kolaylıkla oluşturabilmeleri ve yönetebilmeleri için tasarlanmış bir web uygulamasıdır. Sistem iki ana arayüz sunar:

1. **Genel Portföy Sayfası** - Ziyaretçilerin portföyü görüntülemesi için
2. **Yönetim Paneli** - Yöneticilerin içeriği yönetmesi için

## ✨ Özellikler

### 📊 İçerik Yönetimi
- **Hakkında Bölümü (About)** - Kişisel tanıtım metni ve resmi yönetimi
- **Banner Yönetimi** - Başlık görselleri ve açıklamaları
- **İş Deneyimi (Experience)** - Çalışma geçmişi ve pozisyonları
- **Eğitim (Education)** - Eğitim geçmişi ve sertifikaları
- **Projeler (Projects)** - Tamamlanan projeleri ve detaylarını gösterme
- **Teknoloji Yığını (Tech Stack)** - Kullanılan teknolojileri etiketi
- **Hizmetler (Services)** - Sunulan hizmetleri listeleme
- **Yetenekler (Skills)** - Teknik ve işbirliği yetenekleri
- **Referanslar (Testimonials)** - Müşteri veya meslektaş yorumları
- **İletişim Bilgileri** - E-posta, telefon, sosyal medya bağlantıları

### 👥 Kullanıcı İşlevleri
- **Mesaj Gönderme** - Ziyaretçilerin form üzerinden mesaj göndermesi
- **Mesaj Yönetimi** - Yöneticilerin gelen mesajları görüntülemesi
- **Yönetim Ayarları** - Admin profili ve temel ayarlar

### 🔐 Güvenlik Özellikleri
- **Cookie Tabanlı Kimlik Doğrulama** - Admin girişi ve oturum yönetimi
- **Yetkilendirme (Authorization)** - Yönetim paneline erişim kontrolü
- **Oturum (Session)** - 30 dakikalık oturum zaman aşımı
- **HTTPS Desteği** - Güvenli veri iletişimi

### 📱 Diğer Özellikler
- **Responsive Tasarım** - Bootstrap 5 ile mobil uyumlu
- **Sayfalandırma (Pagination)** - X.PagedList ile veri listeleme
- **Dosya Yükleme** - Görsel ve belge yönetimi
- **Dinamik İçerik Yükleme** - ViewComponents ile modüler yapı

## 🛠️ Teknoloji Stack

### Backend
- **.NET 8.0** - Hedef framework
- **ASP.NET Core** - Web framework
- **Entity Framework Core 8.0.28** - ORM ve veritabanı yönetimi
- **C# 12** - Programlama dili

### Veritabanı
- **SQL Server** - İlişkisel veri tabanı yönetim sistemi
- **Entity Framework Migrations** - Veritabanı versiyonlama

### Frontend
- **Razor Pages & Views** - Sunucu tarafı rendering
- **HTML5** - İçerik yapısı
- **CSS3** - Stil ve düzen
- **Bootstrap 5** - CSS framework
- **jQuery 3.x** - JavaScript kütüphanesi
- **jQuery Validation** - Form doğrulaması

### Ek Paketler
- **X.PagedList.Mvc.Core 10.5.9** - Sayfalandırma özelliği
- **Microsoft.AspNetCore.Mvc.Authorization** - Yetkilendirme filtreleri
- **Microsoft.AspNetCore.Authentication.Cookies** - Cookie kimlik doğrulaması

## 💻 Sistem Gereksinimleri


## 📦 Kurulum

### Adım 1: Depoyu Klonlayın

```bash
git clone https://github.com/ComputerUni/Portfolio.git
cd Portfolio
```

### Adım 2: Bağımlılıkları Yükleyin

```bash
dotnet restore
```

### Adım 3: Veritabanı Ayarını Yapın

`Portfolio/Data/Context/AppDbContext.cs` dosyasını açın ve SQL Server bağlantı dizesini kendi ortamınıza göre güncelleyin:

```csharp
optionsBuilder.UseSqlServer("Server=YOUR_SERVER_NAME\\SQLEXPRESS;Database=PortfolioDb;Integrated Security=True;TrustServerCertificate=True;");
```

### Adım 4: Veritabanını Oluşturun

Package Manager Console'da çalıştırın:

```powershell
Update-Database
```

Veya .NET CLI'de:

```bash
dotnet ef database update
```

### Adım 5: Uygulamayı Çalıştırın

```bash
dotnet run
```

Uygulama varsayılan olarak `https://localhost:5001` adresinde açılacaktır.

## 🗄️ Veritabanı Ayarı

### Geçişler (Migrations)

Proje aşağıdaki geçişlerle birlikte gelir:

1. **20260618184505_initial_mig** - İlk veritabanı şeması
2. **20260716172115_mig_usermessage_added** - UserMessage tablosu eklendi
3. **20260716185433_mig_admin_added** - Admin tablosu eklendi

### Yeni Geçiş Oluşturma

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Veritabanı Sıfırlama (Geliştirme Ortamında)

```bash
dotnet ef database drop
dotnet ef database update
```

## 📁 Proje Yapısı

```
Portfolio/
├── Controllers/           # Denetleyiciler (Controllers)
│   ├── HomeController.cs
│   ├── AuthController.cs
│   ├── ProjectController.cs
│   ├── ProjectTechStacksController.cs
│   └── ...diğer denetleyiciler
│
├── Data/                  # Veri katmanı
│   ├── Context/
│   │   └── AppDbContext.cs
│   └── Entities/          # Veritabanı varlıkları
│       ├── About.cs
│       ├── Project.cs
│       ├── Admin.cs
│       └── ...
│
├── Models/                # View modelleri
│   ├── LoginViewModel.cs
│   └── ErrorViewModel.cs
│
├── Views/                 # Razor görünümleri
│   ├── Home/
│   ├── Admin/
│   ├── Shared/
│   └── Components/
│
├── ViewComponents/        # Tekrar kullanılabilir görünüm bileşenleri
│   ├── AdminLayout/
│   └── Default-Index/
│
├── wwwroot/              # Statik dosyalar
│   ├── css/
│   ├── js/
│   ├── lib/              # Client-side kütüphaneleri
│   ├── uploads/          # Yüklenen dosyalar
│   └── stitch_modern_portfolio_showcase/
│
├── Migrations/           # Entity Framework migrations
│   └── AppDbContextModelSnapshot.cs
│
├── Properties/           # Proje özellikleri
│   └── launchSettings.json
│
├── Program.cs            # Uygulama başlatma noktası
├── appsettings.json      # Yapılandırma ayarları
└── Portfolio.csproj      # Proje dosyası
```

## 🔧 Ana Modüller

### 1. Kimlik Doğrulama ve Yetkilendirme

**Dosya:** `Controllers/AuthController.cs`

- Login işlevi
- Cookie tabanlı kimlik doğrulama
- Logout işlevi

### 2. İçerik Yönetimi

**Denetleyiciler:**
- `AboutController.cs` - Hakkında bölümü yönetimi
- `ProjectController.cs` - Proje yönetimi
- `ProjectTechStacksController.cs` - Proje teknolojileri
- `EducationController.cs` - Eğitim bilgileri
- `ExperienceController.cs` - İş deneyimi
- `ServiceController.cs` - Hizmetler
- `SkillController.cs` - Yetenekler
- `BannerController.cs` - Banner görselleri
- `TestimonialController.cs` - Müşteri referansları

### 3. Mesaj Yönetimi

**Dosya:** `Controllers/UserMessageController.cs`

- Ziyaretçi mesajlarını alma
- Mesajları görüntüleme
- Mesaj silme

### 4. Admin Ayarları

**Dosya:** `Controllers/SettingController.cs`

- Admin profili güncelleme
- Sistem ayarları

## 🗄️ Veritabanı Şeması

### Ana Tablolar

| Tablo | Açıklama | Alanlar |
|-------|----------|--------|
| **Abouts** | Portföy hakkında bölümü | Id, Title, Content, ImageUrl |
| **Banners** | Başlık görselleri | Id, Title, Subtitle, ImageUrl |
| **Projects** | İş projeleri | Id, Title, Description, ImageUrl, Link |
| **ProjectTechStacks** | Proje-teknoloji bağlantısı | Id, ProjectId, TechStackId |
| **TechStacks** | Teknoloji etiketleri | Id, Name, Icon |
| **Experiences** | İş deneyimi | Id, Title, Company, Description, StartDate, EndDate |
| **Educations** | Eğitim bilgileri | Id, School, Department, StartDate, EndDate |
| **Services** | Sunulan hizmetler | Id, Title, Description, Icon |
| **Skills** | Yetenekler | Id, Name, Percentage |
| **Testimonials** | Müşteri referansları | Id, Name, Title, Content, Image |
| **ContactInfos** | İletişim bilgileri | Id, Type, Value |
| **UserMessages** | Gelen mesajlar | Id, Name, Email, Subject, Message, CreatedDate |
| **Admins** | Admin hesapları | Id, Username, Email, Password, ImageUrl |

## 🔐 Kimlik Doğrulama

### Giriş Akışı

1. Kullanıcı `/Auth/Login` sayfasına gider
2. Kimlik bilgileri gir (Username/Email + Password)
3. System `Admins` tablosunda doğrula
4. Başarılı olursa cookie oluştur ve `/` yönlendir
5. Başarısız olursa hata mesajı göster

### Oturum Ayarları

- **Zaman Aşımı:** 30 dakika (Program.cs'de yapılandırılabilir)
- **Cookie Adı:** `PortfolioCookie`
- **Güvenlik:** HttpOnly, SameSite ayarları

### Çıkış

```csharp
await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
```

## 📡 API Endpoints

### Genel Sayfalar

| Endpoint | Metot | Açıklama |
|----------|-------|----------|
| `/` | GET | Ana portföy sayfası |
| `/Home/Privacy` | GET | Gizlilik sayfası |

### Kimlik Doğrulama

| Endpoint | Metot | Açıklama |
|----------|-------|----------|
| `/Auth/Login` | GET/POST | Admin girişi |
| `/Auth/Logout` | POST | Çıkış |

### Yönetim Paneli (Erişim: Kimlik Doğrulanmış)

| Endpoint | Metot | Açıklama |
|----------|-------|----------|
| `/About/Index` | GET | Hakkında listesi |
| `/About/CreateAbout` | GET/POST | Hakkında ekle |
| `/About/UpdateAbout/{id}` | GET/POST | Hakkında düzenle |
| `/Project/Index` | GET | Proje listesi |
| `/Project/CreateProject` | GET/POST | Proje ekle |
| `/Project/UpdateProject/{id}` | GET/POST | Proje düzenle |
| `/ProjectTechStacks/Index` | GET | Teknoloji listesi |
| `/ProjectTechStacks/Create` | GET/POST | Teknoloji ekle |
| `/ProjectTechStacks/Update/{id}` | GET/POST | Teknoloji düzenle |
| `/Experience/Index` | GET | Deneyim listesi |
| `/Experience/CreateExperience` | GET/POST | Deneyim ekle |
| `/Education/Index` | GET | Eğitim listesi |
| `/Education/CreateEducation` | GET/POST | Eğitim ekle |
| `/Skill/Index` | GET | Yetenek listesi |
| `/Skill/CreateSkill` | GET/POST | Yetenek ekle |
| `/Service/Index` | GET | Hizmet listesi |
| `/Service/CreateService` | GET/POST | Hizmet ekle |
| `/Testimonial/Index` | GET | Referans listesi |
| `/Testimonial/CreateTestimonial` | GET/POST | Referans ekle |
| `/UserMessage/Index` | GET | Mesaj listesi |
| `/UserMessage/DetailMessage/{id}` | GET | Mesaj detayı |
| `/Setting/Index` | GET | Ayarlar |
| `/Setting/UpdateAdmin` | GET/POST | Admin güncelle |

## 🎨 Kullanıcı Arayüzü

### Genel Portföy (Public)

Ziyaretçiler tarafından görülebilen bölümler:

- **Hero Banner** - Başlık görseli ve tanıtım
- **Hakkında** - Profesyonel özgeçmiş
- **Deneyim** - İş geçmişi
- **Eğitim** - Eğitim geçmişi
- **Hizmetler** - Sunulan hizmetler
- **Projeler** - Tamamlanan projeler ve teknolojisi
- **Yetenekler** - Teknik yetenekler ve yüzdeler
- **Referanslar** - Müşteri yorumları
- **İletişim** - İletişim formu ve bilgileri

### Admin Paneli (Private)

Yöneticilerin erişebildiği yönetim arayüzleri:

- **Sidebar Menü** - Hızlı navigasyon
- **İçerik Yönetimi** - Tüm içerik türlerini yönetme
- **Dosya Yükleme** - Resim ve dosya yönetimi
- **Mesaj Yönetimi** - Gelen mesajları görüntüleme

### Responsive Tasarım

- Bootstrap 5 grid sistemi
- Mobile-first tasarım yaklaşımı
- Tüm ekran boyutlarında uyumlu

## 🚀 Geliştirme

### Debug Mode'da Çalıştırma

```bash
dotnet run --configuration Debug
```

### ViewComponents Oluşturma

Yeni bir ViewComponent eklemek:

```bash
dotnet new viewcomponent -n MyComponent -o ViewComponents
```

### Yeni Denetleyici Ekleme

```bash
dotnet new controller -name MyController -o Controllers
```

### Yeni Model Oluşturma

1. `Data/Entities/` klasöründe yeni Entity sınıfı oluştur
2. `AppDbContext.cs`'e DbSet ekle
3. Migration oluştur ve uygula

```bash
dotnet ef migrations add AddNewEntity
dotnet ef database update
```

## ⚙️ Yapılandırma

### appsettings.json

```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Information"
	}
  },
  "AllowedHosts": "*"
}
```


## 📝 Migrasyon Yönetimi

### Mevcut Geçişleri Listeleme

```bash
dotnet ef migrations list
```

### İleri Geçiş Yapma

```bash
dotnet ef migrations script --idempotent > migration.sql
```

### Geri Alma (Geliştirme Ortamı)

```bash
dotnet ef migrations remove
```

