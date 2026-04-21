# net10-saas-starter

> Production-ready **.NET 10 Clean Architecture** template with Turkish market essentials — iyzico, KVKK audit logging, e-fatura ready, multi-tenant SaaS foundation.

[![CI](https://github.com/cemkulunkoglu/net10-saas-starter/actions/workflows/ci.yml/badge.svg)](https://github.com/cemkulunkoglu/net10-saas-starter/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)](https://dotnet.microsoft.com/)

A modern, opinionated SaaS starter designed for the **Turkish market**. Skip 4–6 weeks of plumbing and start building product features.

## ✨ Highlights

- **.NET 10** with Minimal APIs and the latest C# features
- **Clean Architecture** — Domain / Application / Infrastructure / Api
- **[Wolverine](https://wolverine.netlify.app/)** — MediatR-free CQRS, messaging and outbox
- **[.NET Aspire](https://learn.microsoft.com/dotnet/aspire/)** — local orchestration, observability and dashboards
- **[Scalar](https://scalar.com/)** — modern OpenAPI UI
- **EF Core 10** + PostgreSQL with migrations
- **Multi-tenancy** — row-level isolation built in
- **Testcontainers** for real-DB integration tests

### 🇹🇷 Turkish market essentials

- **iyzico** payment integration scaffold
- **KVKK** audit logging (PII access tracking)
- **e-Fatura / e-Arşiv** invoice scaffolding
- Turkish localization defaults (tr-TR, TRY, Europe/Istanbul)

## 📦 Project structure

```
src/
├── SaasStarter.Domain          # Entities, value objects, domain events
├── SaasStarter.Application     # Use cases, ports, DTOs
├── SaasStarter.Infrastructure  # EF Core, persistence, external services
├── SaasStarter.Api             # Minimal API endpoints
├── SaasStarter.AppHost         # Aspire orchestration
└── SaasStarter.ServiceDefaults # OpenTelemetry, health checks, resilience

tests/
├── SaasStarter.UnitTests
└── SaasStarter.IntegrationTests
```

## 🚀 Getting started

```bash
# Requirements: .NET 10 SDK, Docker
git clone https://github.com/cemkulunkoglu/net10-saas-starter.git
cd net10-saas-starter
dotnet restore
dotnet run --project src/SaasStarter.AppHost
```

The Aspire dashboard opens at <https://localhost:17000>.

## 🧪 Tests

```bash
dotnet test
```

## 🗺️ Roadmap

- [x] **Faz 1** — Solution skeleton, CI, conventional commits
- [ ] **Faz 2** — Wolverine + EF Core + PostgreSQL + Scalar wiring
- [ ] **Faz 3** — Multi-tenancy, auth, KVKK audit log
- [ ] **Faz 4** — iyzico integration
- [ ] **Faz 5** — e-Fatura scaffold
- [ ] **Faz 6** — Production hardening (rate limiting, caching, deployment)

## 📝 License

MIT — see [LICENSE](LICENSE).
