# 📋 UniversityApp

## 🧭 Overview

**UniversityApp** is a modular university management system designed to handle hierarchical relationships between universities, faculties, and students. The system is built with a strong emphasis on clean architecture principles, separation of concerns, and domain-driven design concepts.

The application is structured as a layered monolith with clearly defined boundaries between presentation, business logic, data access, and domain layers.

---

## 🏗️ Architecture

The project follows a **Layered Architecture (N-Tier)** approach:

* Presentation Layer (Console UI)
* Business Logic Layer (Services + DTOs)
* Data Access Layer (Repository + Unit of Work)
* Domain Layer (Entities + Enums + Core rules)
* Bootstrap Layer (Dependency Composition Root)

### 🎯 Architectural Principles

* Separation of Concerns (SoC)
* Domain-Driven Design (DDD-inspired)
* Repository Pattern
* Unit of Work Pattern
* Dependency Inversion Principle (DIP)
* Transactional Consistency (ACID-based operations)

---

## 🧩 Solution Structure

```
UniversityApp
│
├── UniversityApp (Console Entry Point)
│   └── Program.cs
│
├── UniversityApp.CORE
│   ├── Entities
│   │   ├── BaseEntity.cs
│   │   ├── University.cs
│   │   ├── Faculty.cs
│   │   └── Student.cs
│   ├── Enums
│   │   ├── UniversityType.cs
│   │   └── FacultyType.cs
│   ├── Repository
│   │   └── IRepository<T>
│   └── UnitOfWork
│       └── IUnitOfWork
│
├── UniversityApp.BLL
│   ├── Services
│   │   ├── UniversityService.cs
│   │   ├── FacultyService.cs
│   │   └── StudentService.cs
│   ├── DTOs
│   │   ├── UniversityDtos.cs
│   │   ├── FacultyDtos.cs
│   │   └── StudentDtos.cs
│   └── Mappers
│       ├── UniversityMapper.cs
│       ├── FacultyMapper.cs
│       └── StudentMapper.cs
│
├── UniversityApp.DAL
│   ├── Context
│   │   └── UniversityDbContext.cs
│   ├── Repository
│   │   └── Repository<T>
│   └── UnitOfWork
│       └── UnitOfWork.cs
│
├── BootStrapper
│   └── AppBuilder.cs
│
└── UniversityOrchestrationUI
    ├── AppUI
    │   └── App.cs
    └── Pages
        ├── UniversityUI.cs
        ├── FacultyUI.cs
        └── StudentUI.cs
```

---

## 🧠 Domain Model

### Core Entities

#### University

* Holds faculties (1 → many)
* Validates faculty-type compatibility
* Encapsulates domain business rules

#### Faculty

* Belongs to a university
* Contains students
* Enforces structural constraints

#### Student

* Belongs to a faculty
* Age and score validation rules
* Encapsulated update behaviors

---

## 🔁 Business Rules

* University type determines allowed faculty types
* Student age must be within valid range (18–100)
* Student score is bounded (0–100)
* Faculty cannot exist without valid university reference
* Entities enforce validation internally

---

## ⚙️ Data Access Layer

### Patterns Used

* Generic Repository Pattern
* Unit of Work Pattern
* Entity Framework Core abstraction

### Responsibilities

* Database communication
* Transaction control
* Entity persistence

---

## 💼 Business Logic Layer

### Responsibilities

* Application orchestration
* DTO transformation
* Validation enforcement
* Transaction coordination

### Structure

* Services handle use-cases
* DTOs define contracts
* Mappers handle transformations

---

## 🖥️ Presentation Layer

* Console-based UI
* Menu-driven navigation
* Separate UI modules per domain

Responsibilities:

* Input handling
* Output rendering
* Service orchestration

---

## 🔗 Dependency Flow

```
UI → BLL → DAL → CORE
```

---

## 🔧 Design Patterns

* Layered Architecture
* Repository Pattern
* Unit of Work Pattern
* DTO Pattern
* Mapper Pattern
* Composition Root (Manual DI)

---

## 🧪 Data Flow (Create Student)

1. UI collects input
2. DTO sent to service
3. Validation executed
4. Domain entity created
5. Repository persists data
6. UnitOfWork commits transaction
7. DTO returned to UI

---

## 🧱 Technology Stack

* .NET 9
* C# 13
* Entity Framework Core 9
* SQL Server (LocalDB)
* Console Application

---

## ⚡ Strengths

* Clean layered architecture
* Strong domain modeling
* Transaction-safe design
* Reusable generic repository
* Clear separation of concerns

---

## 📌 Future Improvements

* Dependency Injection container integration
* FluentValidation
* AutoMapper
* Serilog logging
* Unit testing (xUnit)
* CQRS + MediatR
* Web API migration

---

## 🚀 Setup

```
git clone <repo-url>
dotnet restore
dotnet build
dotnet run
```

---

## 👤 Author

Vusal Memmedov
[mvusal316@gmail.com](mailto:mvusal316@gmail.com)
GitHub: vusal016
