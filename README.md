# 🚀 CompanyEmployees API

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
CompanyEmployees (Web API - Host)
│
├── CompanyEmployees.Presentation
│ └── Controllers
│
├── CompanyEmployees.Service
│ └── Business Logic
│
├── CompanyEmployees.Repository
│ └── Data Access Layer
│
├── CompanyEmployees.Entities
│ └── Domain Models
│
└── CompanyEmployees.Contracts
└── Interfaces
---
## Request Flow
Controller
↓
Service Layer
↓
Repository Layer
↓
DbContext (EF Core)
↓
SQL Server

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

1. Clone the repository
2. Configure the connection string inside `appsettings.json`
3. Apply migrations:

bash
dotnet ef database update
Run the application:
dotnet run
Open Swagger:
https://localhost:5001/swagger
---
# Error Handling

The API includes:

Global exception handling middleware

Consistent HTTP responses

Clean separation of error logic in the service layer

(Custom exception strategy can be described here if applicable.)
---
# Implemented Best Practices

DTO usage to avoid exposing domain entities

Separation of business logic via Service Layer

Repository abstraction over data access

trackChanges optimization in EF Core queries

Centralized IServiceManager for service coordination

Code First migrations

Attribute-based routing with route constraints
---
# Technical Decisions

Onion Architecture was chosen to enforce separation of concerns and low coupling.

Repository Pattern abstracts persistence logic.

Service Layer encapsulates business logic.

Swagger enables automatic API documentation.

Global middleware ensures consistent exception handling.

Dependency Injection ensures loose coupling between components.
---
# Future Improvements

Pagination support

Filtering & sorting

JWT Authentication & Authorization

Unit and integration testing

Caching strategies

API versioning
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
