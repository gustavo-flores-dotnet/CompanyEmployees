# CompanyEmployees API

RESTful Web API built with **ASP.NET Core**, following **Onion Architecture** principles, implementing Repository and Service patterns, global exception handling, logging, and Swagger/OpenAPI documentation.

This project simulates a Company & Employee management system and is designed to demonstrate production-level backend architecture and best practices in .NET.

---
# What This Project Is

CompanyEmployees API is a layered backend system that allows managing companies and their employees.

The main goal of this project is to demonstrate solid knowledge of:

- RESTful API design
- Onion Architecture
- SOLID principles
- Dependency Injection
- Clean separation of concerns
- Entity Framework Core (Code First)
- Production-ready backend practices

---

# Tech Stack

- **ASP.NET Core Web API**
- **Entity Framework Core (Code First)**
- **SQL Server**
- **Swagger / OpenAPI**
- **Repository Pattern**
- **Service Layer Pattern**
- **Dependency Injection**
- **Global Exception Handling Middleware**
- **Logging**
- **DTOs + Mapping**
- **Attribute-Based Routing**
- **EF Core Migrations**
- **Onion Architecture**

---

# Architecture

The project follows **Onion Architecture**, separating responsibilities into distinct layers:

```text
CompanyEmployees (Web API - Host)
│
├── CompanyEmployees.Presentation
│   └── Controllers
│
├── CompanyEmployees.Service
│   └── Business Logic
│
├── CompanyEmployees.Repository
│   └── Data Access Layer
│
├── CompanyEmployees.Entities
│   └── Domain Models
│
└── CompanyEmployees.Contracts
    └── Interfaces
```

---
## Request Flow

```
Controller
↓
Service Layer
↓
Repository Layer
↓
DbContext (EF Core)
↓
SQL Server
```

Each layer depends only on inner layers, respecting the Dependency Inversion Principle.

---

# API Documentation

Interactive API documentation is available via Swagger:
https://localhost:5001/swagger
Swagger provides:

- Available endpoints
- Request parameters
- Response models (DTOs)
- HTTP status codes
- Interactive testing

---

# 🔗 Main Endpoints

## Companies

| Method | Endpoint | Description |
|--------|----------|------------|
| GET | `/api/companies` | Retrieves all companies |
| GET | `/api/companies/{id}` | Retrieves a company by ID |

## Employees

| Method | Endpoint | Description |
|--------|----------|------------|
| GET | `/api/companies/{companyId}/employees` | Retrieves all employees of a company |
| GET | `/api/companies/{companyId}/employees/{id}` | Retrieves a specific employee within a company |

---

# ⚙️ How to Run the Project
### Prerequisites:
- .NET SDK (version: ___)
- SQL Server / SQL Server Express
- (Optional) Visual Studio 2022/2026
  
1. Clone the repository
2. Configure the connection string inside `appsettings.json`
```json
"ConnectionStrings": {
  "sqlConnection": "YOUR_CONNECTION_STRING_HERE"
}
```
### Apply existing migrations (recommended)

This repository already includes EF Core migrations. To create/update the database schema, run:
Visual Studio (Package Manager Console):
```
Update-Database
```
Run the API:
```
dotnet run
```
CLI:
```
dotnet ef database update --startup-project CompanyEmployees
```
If EF Core can’t locate the DbContext in your setup, specify the DbContext project as well:
```
dotnet ef database update --project <ProjectThatContainsRepositoryContext> --startup-project CompanyEmployees
```
Run the API:
```
dotnet run --project CompanyEmployees
```

---

### Creating a new migration (only if you change the model)
A) Visual Studio Package Manager Console
1. Set Startup Project to: CompanyEmployees
2. Open Tools → NuGet Package Manager → Package Manager Console
3. Run
```bash
Add-Migration InitialCreate
dotnet ef database update
```
Run the application:
```bash
dotnet run
```

B) CLI
From the solution root run:
```
dotnet ef migrations add InitialCreate --startup-project CompanyEmployees
dotnet ef database update --startup-project CompanyEmployees
```
If EF Core can’t locate the DbContext in your setup, use --project as well (the project that contains RepositoryContext):
```
dotnet ef migrations add InitialCreate --project Repository --startup-project CompanyEmployees
dotnet ef database update --project Repository --startup-project CompanyEmployees
```
Run the application:
```
dotnet run --project CompanyEmployees
```

Open Swagger:
https://localhost:5001/swagger
or
http://localhost:5000/swagger


---
# Error Handling

The API includes:

- Global exception handling middleware
- Consistent HTTP responses
- Clean separation of error logic in the service layer
  
---
# Implemented Best Practices
- DTO usage to avoid exposing domain entities
- Separation of business logic via Service Layer
- Repository abstraction over data access
- trackChanges optimization in EF Core queries
- Centralized IServiceManager for service coordination
- Centralized IRepositoryManager for repositories coordination
- Repository pattern logic for CRUD methods
- Code First migrations
- Attribute-based routing with route constraints

---
# Technical Decisions
- Onion Architecture was chosen to enforce separation of concerns and low coupling.
- Repository Pattern abstracts persistence logic.
- Service Layer encapsulates business logic.
- Swagger enables automatic API documentation.
- Global middleware ensures consistent exception handling.
- Dependency Injection ensures loose coupling between components.
  
---
# Future Improvements
- Pagination support
- Filtering & sorting
- JWT Authentication & Authorization
- Unit and integration testing
- Caching strategies
- API versioning
- Deployment to IIS

---
# Author

Gustavo Abraham Flores Galindo

Backend Developer focused on ASP.NET Core, clean architecture, and scalable backend design.
---
## 📖 Learning Context

This project was built as part of my structured learning process while studying advanced ASP.NET Core architecture.

Although inspired by educational material, I implemented, configured, and structured the solution myself to fully understand:

- Onion Architecture
- Repository & Service patterns
- EF Core Code First
- Dependency Injection
- Production-level layering
