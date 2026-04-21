# net10-saas-starter

> .NET 10 + Clean Architecture + Wolverine + Aspire — minimum sürtünmeyle başlayabileceğin opinionated bir SaaS iskeleti.

[![CI](https://github.com/cemkulunkoglu/net10-saas-starter/actions/workflows/ci.yml/badge.svg)](https://github.com/cemkulunkoglu/net10-saas-starter/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)](https://dotnet.microsoft.com/)

> **Status:** erken aşama (v0.x). Üretime hazır değil — iskelet ve örüntüler hazır, business katmanı senin.

## Şu an ne var

- **.NET 10** Minimal API
- **Clean Architecture** — `Domain` / `Application` / `Infrastructure` / `Api` katmanları
- **[Wolverine 5](https://wolverinefx.net/)** — handler tabanlı endpoint'ler, MediatR'a ihtiyaç yok
- **[.NET Aspire](https://learn.microsoft.com/dotnet/aspire/)** — yerel orkestrasyon, dashboard, OpenTelemetry
- **EF Core 10 + PostgreSQL** (Aspire üzerinden container)
- **[Scalar](https://scalar.com/)** OpenAPI UI
- Örnek `Product` slice'ı: `GET/POST /products`
- xUnit unit test + Aspire-tabanlı end-to-end integration test
- GitHub Actions CI (build + test + commitlint)
- Conventional Commits zorunlu

## Şu an ne yok

Bunlar README'de varmış gibi durmasın diye açık yazıyorum:

- ❌ Authentication / authorization
- ❌ Multi-tenancy
- ❌ KVKK audit log
- ❌ iyzico ödeme entegrasyonu
- ❌ e-Fatura / e-Arşiv scaffolding
- ❌ EF Core migrations (şimdilik dev'de `EnsureCreatedAsync`)
- ❌ Production deployment örneği

Bunların bir kısmı yol haritasında. Türkiye pazarına özgü modüller (iyzico, KVKK, e-fatura) gelecek fazlarda eklenecek.

## Proje yapısı

```
src/
├── SaasStarter.Domain          # Entity'ler ve domain kuralları
├── SaasStarter.Application     # Use case handler'lar, port'lar, DTO'lar
├── SaasStarter.Infrastructure  # EF Core, persistence
├── SaasStarter.Api             # Wolverine HTTP endpoint'leri
├── SaasStarter.AppHost         # Aspire orkestrasyonu
└── SaasStarter.ServiceDefaults # OpenTelemetry, health check, resilience

tests/
├── SaasStarter.UnitTests
└── SaasStarter.IntegrationTests
```

## Başlangıç

```bash
# Gereksinim: .NET 10 SDK, Docker (veya colima/orbstack/podman)
git clone https://github.com/cemkulunkoglu/net10-saas-starter.git
cd net10-saas-starter
dotnet run --project src/SaasStarter.AppHost
```

Aspire dashboard URL'i konsola yazılır (token'lı login linkiyle birlikte). Dashboard'dan `api` kaynağına tıklayıp Scalar UI'a (`/scalar/v1`) ulaşabilirsin.

## Test

```bash
dotnet test
```

Integration test'ler Docker üzerinde gerçek bir Postgres ayağa kaldırır.

## Yol haritası

- [x] **Faz 1** — Solution iskeleti, CI, Conventional Commits
- [x] **Faz 2** — Wolverine + EF Core + PostgreSQL + Scalar + Aspire orkestrasyonu
- [ ] **Faz 3** — Multi-tenancy + auth + KVKK audit log
- [ ] **Faz 4** — iyzico ödeme entegrasyonu
- [ ] **Faz 5** — e-Fatura scaffold
- [ ] **Faz 6** — EF migrations, rate limiting, caching, deployment örnekleri

## Lisans

MIT — bkz. [LICENSE](LICENSE).
