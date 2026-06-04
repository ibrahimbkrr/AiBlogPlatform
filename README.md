# AiBlogPlatform

AiBlogPlatform, ASP.NET Core 8 ile geliştirilen, haber/blog içeriklerini yönetmeye ve yayınlamaya yönelik bir web uygulamasıdır. Proje; bir Web API katmanı, MVC tabanlı kullanıcı arayüzü, admin paneli, kategori yönetimi, makale yönetimi ve video içerik alanları üzerine kuruludur.

Bu proje geliştirme aşamasındadır. Yeni özellikler eklenmeye, mevcut yapı iyileştirilmeye ve admin tarafı genişletilmeye devam etmektedir.

## Proje Amacı

AiBlogPlatform'un amacı; farklı kategorilerde makalelerin listelenebildiği, öne çıkan içeriklerin ana sayfada gösterilebildiği ve yönetim paneli üzerinden içerik işlemlerinin yapılabildiği bir blog/haber platformu oluşturmaktır.

Proje şu anda özellikle aşağıdaki konulara odaklanmaktadır:

- Makale listeleme, ekleme, silme ve güncelleme işlemleri
- Kategori yönetimi
- Ana sayfa için slider, trend içerikler ve son eklenen makaleler
- Trading/video içeriklerinin API ve UI tarafında yönetimi
- Admin panel yapısının oluşturulması
- Entity Framework Core ile veritabanı modelinin geliştirilmesi

## Kullanılan Teknolojiler

### Backend

- ASP.NET Core Web API
- .NET 8
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- AutoMapper
- Swagger / Swashbuckle

### Frontend

- ASP.NET Core MVC
- Razor Views
- ViewComponent yapısı
- Bootstrap tabanlı tema dosyaları
- Admin panel tema varlıkları

## Proje Yapısı

```text
BtkAkademiAi
|
|-- BtkAkademiAi.WebApi
|   |-- Context
|   |-- Controllers
|   |-- Dtos
|   |-- Entities
|   |-- Mapping
|   |-- Migrations
|   `-- Program.cs
|
|-- BtkAkademiAi.WebUI
|   |-- Controllers
|   |-- Dtos
|   |-- ViewComponents
|   |-- Views
|   |-- wwwroot
|   `-- Program.cs
|
|-- BtkAkademiAi.sln
`-- README.md
```

## Öne Çıkan Modüller

### Web API

API tarafında makale, kategori, kullanıcı kayıt ve trading video işlemleri için controller yapıları bulunmaktadır.

Başlıca controller'lar:

- `ArticlesController`
- `CategoriesController`
- `RegistersController`
- `TradingVideosController`

Makale tarafında öne çıkan slider içerikleri, trend yazılar, son eklenen makaleler ve kategori bazlı son içerikler için endpoint'ler geliştirilmektedir.

### Web UI

WebUI tarafı ASP.NET Core MVC ile hazırlanmıştır. Ana sayfa, component tabanlı bir yapıyla parçalanmıştır. Böylece slider, trend içerikler, son makaleler, video alanları ve layout bölümleri ayrı ViewComponent'ler üzerinden yönetilmektedir.

Başlıca alanlar:

- Ana sayfa içerik bileşenleri
- Makale listeleme sayfaları
- Kategori yönetim sayfaları
- Admin layout
- Admin makale yönetimi
- Trading video bileşenleri

### Admin Panel

Admin panel tarafında şu an temel yapı oluşturulmuştur:

- Admin layout
- Admin navbar, sidebar, head, scripts ve switcher component'leri
- Makale listeleme
- Makale ekleme
- Makale güncelleme
- Kategori listeleme
- Kategori ekleme
- Kategori güncelleme

Bu bölüm geliştirme aşamasındadır ve ilerleyen süreçte daha kapsamlı yönetim ekranları eklenmesi planlanmaktadır.

## Veritabanı

Proje Entity Framework Core Code First yaklaşımı ile ilerlemektedir. Veritabanı bağlantısı şu an `BlogAIContext` içinde tanımlıdır.

Varsayılan geliştirme veritabanı:

```text
BlogAIDb
```

Kullanılan temel entity'ler:

- `Article`
- `Category`
- `TradingVideo`
- `AppUser`
- `About`
- `Contact`
- `Employee`

Not: Projeyi farklı bir bilgisayarda çalıştırmak için SQL Server bağlantı bilgisinin yerel ortama göre güncellenmesi gerekir.

## Kurulum

### Gereksinimler

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 veya Rider / VS Code
- Git

### Repoyu Klonlama

```bash
git clone https://github.com/ibrahimbkrr/AiBlogPlatform.git
cd AiBlogPlatform
```

### Bağımlılıkları Yükleme

```bash
dotnet restore
```

### Veritabanını Hazırlama

API projesinde migration dosyaları bulunmaktadır. SQL Server bağlantısı yerel ortama göre ayarlandıktan sonra veritabanı güncellenebilir:

```bash
dotnet ef database update --project BtkAkademiAi.WebApi
```

### Projeyi Çalıştırma

API için:

```bash
dotnet run --project BtkAkademiAi.WebApi
```

Web arayüzü için:

```bash
dotnet run --project BtkAkademiAi.WebUI
```

Geliştirme ortamında kullanılan varsayılan adresler:

```text
Web API: https://localhost:7090
Web UI : https://localhost:7188
Swagger: https://localhost:7090/swagger
```

## API Üzerinden Örnek Alanlar

Bazı geliştirilmiş endpoint alanları:

```text
GET    /api/Articles
GET    /api/Articles/feature-slider
GET    /api/Articles/GetTrendingArticles
GET    /api/Articles/GetLastAddedArticles
GET    /api/Articles/GetLastFourArticlesByCategory
GET    /api/Categories
GET    /api/TradingVideos
GET    /api/TradingVideos/featured
POST   /api/Registers
```

Endpoint yapıları geliştirme sürecinde güncellenebilir.

## Geliştirme Durumu

Proje aktif olarak geliştirilmektedir. Şu an temel mimari ve ekranlar oluşmuş durumdadır; ancak bazı alanlar hâlâ geliştirme ve iyileştirme aşamasındadır.

Planlanan veya iyileştirilecek başlıca konular:

- API route yapılarının daha tutarlı hale getirilmesi
- WebUI tarafında API base URL bilgisinin merkezi konfigürasyona alınması
- Admin panelde doğrulama ve hata mesajlarının güçlendirilmesi
- Identity tabanlı giriş/rol yönetiminin genişletilmesi
- Servis katmanı ile controller'lardaki sorumlulukların azaltılması
- Form validasyonlarının iyileştirilmesi
- Görsel ve içerik yönetiminin daha esnek hale getirilmesi

## Notlar

Bu proje öğrenme, geliştirme ve portföy amaçlı olarak ilerletilmektedir. Kod yapısı zaman içinde daha temiz, sürdürülebilir ve genişletilebilir hale getirilecektir.

## Geliştirici

İbrahim Bakar
