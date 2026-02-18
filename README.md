# 📊 Ledger - Muhasebe Yönetim Sistemi

**Ledger**, şirketler için modern, profesyonel bir muhasebe ve mali yönetim platformudur. Clean Architecture prensiplerini takip ederek geliştirilmiştir.

## 🎯 Proje Hakkında

Ledger, aşağıdaki temel işlevleri sağlar:

- 👥 Kullanıcı ve Yetkilendirme Yönetimi
- 🏢 Şirket ve Cari Hesap Yönetimi
- 💰 Mali İşlem ve Hareket Takibi
- 📅 Muhasebe Dönem Yönetimi
- 🌍 Çok Dil Desteği (Türkçe, İngilizce)

---

## 🛠️ Teknoloji Stack

| Teknoloji                 | Versiyon | Kullanım          |
| ------------------------- | -------- | ----------------- |
| **.NET**                  | 10.0     | Ana platform      |
| **Entity Framework Core** | 10.0.1   | ORM               |
| **SQL Server**            | -        | Veritabanı        |
| **MediatR**               | 14.0.0   | CQRS Pattern      |
| **AutoMapper**            | 12.0.0   | DTO Mapping       |
| **FluentValidation**      | 12.1.1   | Validasyon        |
| **OpenAPI**               | 10.0.0   | API Dokumentasyonu |

---

## 📁 Proje Yapısı

```
Ledger/
├── src/
│   ├── core.Package/                 # Reusable Core Kütüphaneleri
│   │   ├── Core.Application/         # Base DTO'lar, Managers, Pipelines
│   │   ├── Core.CrossCuttingConcerns/# Exception handling, Extensions
│   │   ├── Core.Persistence/         # Entity, Repository base sınıfları
│   │   └── Core.Security/            # Şifreleme, Hashing
│   │
│   └── LedgerProject/                # Ana Proje
│       ├── Domain/                   # Entities (İş Varlıkları)
│       │   ├── Entities/Corp/        # Company, CompanyUser
│       │   ├── Entities/Finance/     # CurrentAccount, CurrentMovement vb.
│       │   ├── Entities/Identity/    # User, UserOperationClaim vb.
│       │   └── Enums/
│       │
│       ├── Application/              # Business Logic (CQRS)
│       │   ├── Features/
│       │   │   ├── Corp/             # Şirket Features
│       │   │   ├── Finance/          # Mali Features
│       │   │   └── Auth/             # Kimlik Features
│       │   ├── Repositories/         # Repository Interfaces
│       │   ├── Services/             # Business Services
│       │   └── ApplicationServiceRegistration.cs
│       │
│       ├── Persistence/              # Veri Erişim Katmanı
│       │   ├── Contexts/             # DbContext
│       │   ├── EntityConfigurations/ # EF Core Configurations
│       │   ├── Migrations/           # Database Migrations
│       │   ├── Repositories/         # Repository Implementations
│       │   └── PersistenceServiceRegistration.cs
│       │
│       ├── Infrastructure/           # Harici Hizmetler
│       │   ├── Localization/         # Çok Dil Desteği
│       │   └── InfrastructureServicesRegistration.cs
│       │
│       └── WebApi/                   # REST API
│           ├── Controllers/          # API Endpoints
│           ├── Program.cs            # Startup Configuration
│           ├── appsettings.json      # Configuration
│           └── Properties/
│
└── Ledger.slnx                       # Solution File
```

---

## 📊 Domain Model

### Corp (Kurumsal)

- **Company** - Şirket ana bilgileri
- **CompanyUser** - Şirket kullanıcıları

### Finance (Mali)

- **CurrentAccount** - Cari hesaplar (alıcı/satıcı)
- **CurrentMovement** - Cari hesap hareketleri
- **CurrentMovementDetail** - Hareket detayları
- **AccountingPeriod** - Muhasebe dönemleri
- **MovementType** - Hareket türleri

### Identity (Kimlik)

- **User** - Sistem kullanıcıları
- **UserOperationClaim** - Kullanıcı yetkileri
- **UserSession** - Oturum bilgileri
- **OperationClaim** - İşlem yetkileri

---

## 🚀 Başlangıç

### Sistem Gereksinimleri

- .NET 10.0 SDK
- SQL Server (2019 veya üzeri)
- Visual Studio 2022 / VS Code

### Kurulum Adımları

1. **Projeyi Klonlayın**

```bash
git clone <repository-url>
cd Ledger
```

2. **Gerekli Paketleri Kurun**

```bash
dotnet restore
```

3. **Connection String'i Ayarlayın**
   - `src/LedgerProject/WebApi/appsettings.json` açın
   - `LedgerDB` connection string'i SQL Server bağlantınıza göre güncelleyin

```json
{
  "ConnectionStrings": {
    "LedgerDB": "Server=YOUR_SERVER;Database=LedgerDB;Trusted_Connection=true;"
  }
}
```

4. **Database Migrations Çalıştırın**

```bash
cd src/LedgerProject/Persistence
dotnet ef database update
```

5. **Uygulamayı Çalıştırın**

```bash
cd src/LedgerProject/WebApi
dotnet run
```

Uygulama şu adreste çalışacaktır: `https://localhost:7000` (port değişebilir)

---

## 📝 Özellikleri

### ✅ Implementedler

- [X] Clean Architecture yapısı
- [X] CQRS Pattern (MediatR)
- [X] Validation Pipeline
- [X] Exception Middleware
- [X] Multi-language Support
- [X] Entity Framework Core
- [X] Dependency Injection
- [X] Repository Pattern
- [X] AutoMapper Integration

### 🔄 Geliştirilecek

- [ ] Unit Test Projesi
- [ ] Integration Test Projesi
- [ ] Logging Framework (Serilog)
- [ ] Caching (Redis)
- [ ] Authentication (JWT)
- [ ] Authorization (Role-based)
