# AiBlogPlatform

AiBlogPlatform, ASP.NET Core 8 ile geliştirilen, haber/blog içeriklerini yayınlamak ve yönetmek için hazırlanan çok katmanlı bir web uygulamasıdır. Proje; Web API, MVC tabanlı kullanıcı arayüzü, admin paneli, içerik yönetimi, yorum sistemi, video içerikleri ve AI destekli makale üretimi gibi modüller üzerine kuruludur.

Bu proje aktif geliştirme aşamasındadır. Temel mimari ve birçok ana ekran oluşturulmuş durumdadır; yeni yönetim ekranları, validasyonlar, servis ayrımları ve kullanıcı deneyimi iyileştirmeleri geliştirilmeye devam etmektedir.

## Proje Amacı

AiBlogPlatform'un amacı; farklı kategorilerde makalelerin yayınlanabildiği, öne çıkan içeriklerin ana sayfada gösterilebildiği, kullanıcıların içerikleri takip edebildiği ve yöneticilerin içerik süreçlerini admin panel üzerinden yönetebildiği modern bir blog/haber platformu oluşturmaktır.

Proje şu anda özellikle şu alanlara odaklanmaktadır:

- Makale listeleme, ekleme, güncelleme ve silme işlemleri
- Kategori yönetimi
- Ana sayfa slider, trend içerik ve son makale alanları
- Blog detay sayfası ve yorum bileşenleri
- Admin panel üzerinden içerik yönetimi
- Trading/video içeriklerinin API ve UI tarafında gösterimi
- AI destekli makale başlığı ve makale içeriği üretimi
- Yorumların admin panelde listelenmesi, yazar/makale bilgileriyle gösterilmesi ve puanlama alanı
- Entity Framework Core Code First yaklaşımıyla veritabanı modelinin geliştirilmesi

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
- Bootstrap tabanlı tema yapısı
- Admin panel tema bileşenleri

### Entegrasyonlar

- OpenAI API tabanlı makale üretim servisleri
- HttpClientFactory ile API tüketimi

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
|   |-- Areas
|   |   `-- Admin
|   |-- Controllers
|   |-- Dtos
|   |-- Services
|   |-- Settings
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

API tarafında makale, kategori, kullanıcı, yorum, kayıt ve trading video işlemleri için controller yapıları bulunmaktadır.

Başlıca controller'lar:

- `ArticlesController`
- `CategoriesController`
- `CommentsController`
- `RegistersController`
- `TradingVideosController`
- `UsersController`

Makale tarafında slider içerikleri, trend yazılar, son eklenen makaleler, kategori bazlı içerikler ve AI destekli içerik üretimi için endpoint'ler geliştirilmektedir.

### Web UI

WebUI tarafı ASP.NET Core MVC ile hazırlanmıştır. Ana sayfa ve blog detay alanları ViewComponent yapısıyla parçalara ayrılmıştır. Bu yapı sayesinde slider, öne çıkan içerikler, son makaleler, video alanları, blog detay blokları ve layout parçaları daha yönetilebilir hale getirilmiştir.

Başlıca alanlar:

- Ana sayfa içerik bileşenleri
- Makale listeleme sayfaları
- Blog detay sayfası
- Yorum listeleme ve yorum formu bileşenleri
- Kategori sayfaları
- Trading video sayfaları
- Admin layout ve yönetim ekranları

### Admin Panel

Admin panel tarafında içerik yönetimi için temel ekranlar oluşturulmuş ve genişletilmeye başlanmıştır.

Mevcut veya geliştirme aşamasındaki alanlar:

- Admin layout
- Admin navbar, sidebar, head, scripts ve switcher component'leri
- Makale listeleme
- Makale ekleme
- Makale güncelleme
- Kategori listeleme
- Kategori ekleme
- Kategori güncelleme
- Yorum listeleme
- Yorum detay modalı
- Yorumlarda durum, puan, yazar ve makale bilgisi gösterimi

Yorum yönetimi tarafı geliştirme aşamasındadır. Listeleme ekranı güçlendirilmiş, puanlama alanı eklenmiş ve yorumların makale/yazar bilgileriyle birlikte gösterilmesi için API tarafında ek DTO ve endpoint çalışmaları yapılmıştır.

### AI Destekli Makale Üretimi

WebUI tarafında AI destekli makale üretimi için servis yapısı bulunmaktadır.

İlgili yapılar:

- `IOpenAiArticleService`
- `OpenAiArticleService`
- `OpenAIArticleTitleService`
- `OpenAiOptions`

Bu yapı ile admin tarafında makale başlığı veya içerik üretimini destekleyecek servis altyapısı oluşturulmuştur. İlerleyen aşamalarda bu alanın form validasyonları, hata yönetimi ve kullanıcı deneyimi daha da iyileştirilecektir.

## Veritabanı

Proje Entity Framework Core Code First yaklaşımıyla ilerlemektedir. Veritabanı bağlantısı `BlogAIContext` üzerinden yönetilmektedir.

Varsayılan geliştirme veritabanı:

```text
BlogAIDb
```

Kullanılan temel entity'ler:

- `Article`
- `Category`
- `Comment`
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
- Visual Studio 2022, Rider veya VS Code
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
GET    /api/Comments
GET    /api/Comments/WithArticleAndAuthor
GET    /api/TradingVideos
GET    /api/TradingVideos/featured
POST   /api/Registers
```

Endpoint yapıları geliştirme sürecinde güncellenebilir.

## Geliştirme Durumu

Proje aktif geliştirme aşamasındadır. Temel API yapısı, MVC arayüzü, admin paneli, makale/kategori yönetimi, video içerikleri, yorum listeleme ekranı ve AI destekli makale üretim altyapısı oluşturulmuştur.

Devam eden veya iyileştirilecek başlıca konular:

- API route yapılarının daha tutarlı hale getirilmesi
- WebUI tarafında API base URL bilgisinin merkezi konfigürasyona alınması
- Admin panelde form validasyonlarının ve hata mesajlarının güçlendirilmesi
- Yorum oluşturma ve yönetme akışının tamamlanması
- `Comment` entity'sindeki yeni alanlar için migration sürecinin takip edilmesi
- Identity tabanlı giriş ve rol yönetiminin genişletilmesi
- Servis katmanı ile controller'lardaki sorumlulukların azaltılması
- Nullability uyarılarının kademeli olarak temizlenmesi
- Görsel ve içerik yönetiminin daha esnek hale getirilmesi

## Notlar

Bu proje öğrenme, geliştirme ve portföy amaçlı olarak ilerletilmektedir. Kod yapısı zaman içinde daha temiz, sürdürülebilir ve genişletilebilir hale getirilecektir.

## Geliştirici

İbrahim Bakar
