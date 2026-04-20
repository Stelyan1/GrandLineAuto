🚗 GrandLineAuto

ASP.NET Core E-Commerce Platform for Auto Parts (Work in Progress 🏗️)

-----------------------------------------------------------------------

📌 Overview

GrandLineAuto is a full-stack e-commerce web application built with ASP.NET Core MVC, designed for selling auto parts through a scalable and well-structured architecture.

The project focuses on clean architecture, maintainability, and real-world business logic, simulating a production-ready online store.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

🧱 Architecture

The application follows a layered architecture:

> Web Layer – Controllers, Views (MVC)
> Service Layer – Business logic abstraction
> Data Layer – Entity Framework Core, DbContext, Configurations
> Infrastructure Layer – Seeding, external integrations
 
Key Patterns:

> Repository Pattern
> Service Layer Pattern
> DTO Mapping
> Separation of Concerns

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

🗂️ Core Features (Implemented So Far)
✅ Catalog System
> Brands
> Brand Model Series
> Brand Models
> Categories & Subcategories
> Products

✔ Structured for easy filtering and scalability
✔ Relationships configured via Fluent API

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

✅ Admin Panel
> Role-based access (Admin only)
> Full CRUD for:
   > Brands
   > Models
   > Categories
   > Products

✔ Protected using ASP.NET Core Identity
✔ Clean separation via Area ("Admin")

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

✅ Authentication & Authorization
ASP.NET Core Identity with:
> Custom ApplicationUser
> GUID-based keys
> Role system (Admin)
> Cookie configuration & access handling

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

✅ Database & Data Handling
> Entity Framework Core
> Fluent API configurations
> Relationships (One-to-Many, Many-to-Many)
> JSON-based data seeding
> Optimized queries with AsNoTracking()

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

✅ API Layer
> REST API for catalog (read-only)
> DTO-based responses
> Swagger integration

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

✅ Error Handling & Security
> Custom Exception Middleware
> Global Anti-Forgery protection (CSRF)
> Secure authentication flow
> Status code handling (401, 403, 500)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

> 🛒 In Progress
> 🧺 Shopping Cart system
> 📦 Orders & Checkout flow
> 💳 Stripe payment integration
> 📬 Order status tracking
> 📱 API expansion for external clients

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

🛠️ Tech Stack
Backend:
> C#
> ASP.NET Core MVC
> Entity Framework Core
Database:
> MS SQL Server
Frontend:
> HTML
> CSS
> JavaScript

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

🚀 Getting Started
git clone https://github.com/your-username/GrandLineAuto.git
cd GrandLineAuto

> Configure connection string in appsettings.json
> Run migrations:
> dotnet ef database update
> Start the project:
> dotnet run
