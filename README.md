# MVCProject

A 3-tier ASP.NET Core MVC application built with the Repository Pattern + Service Layer architecture, featuring Entity Framework Core and ASP.NET Core Identity.

## Architecture

```
PL (Presentation Layer) - ASP.NET Core MVC Web App
    |
BLL (Business Logic Layer) - Services, DTOs, AutoMapper
    |
DAL (Data Access Layer) - EF Core DbContext, Repositories, Entities
    |
SQL Server Database
```

### Layers

- **DAL** - Data Access Layer: Entity models, `ApplicationDbContext`, Fluent API configurations, Generic & specific repositories, EF Core Migrations
- **BLL** - Business Logic Layer: Service interfaces/implementations, DTOs, AutoMapper mapping profiles, Department factory
- **PL** - Presentation Layer: ASP.NET Core MVC controllers, Razor views, ViewModels, DI composition root (`Program.cs`)

## Features

### Department Management
- CRUD operations (Create, Read, Update, Delete)
- Department details with General/Administration tabs
- ViewModel pattern for data transfer

### Employee Management
- Full CRUD operations
- Gender and Employee Type enums
- Soft delete support (`IsDeleted` flag)
- Employee details view

### Identity & Authentication
- ASP.NET Core Identity with custom `ApplicationUser` (adds FirstName, LastName)
- User registration and login
- Logout functionality
- Role-based authorization

### Roles Management
- Role CRUD (Create, Edit, Details, Delete) via `RoleManager<IdentityRole>`
- Search/filter roles by name
- Admin-only access (`[Authorize(Roles = "Admin")]`)

### User Management
- List all registered users with their assigned roles
- View user details (name, email, roles)
- Assign/remove roles to/from users
- Delete users
- Admin-only access (`[Authorize(Roles = "Admin")]`)

### Database Seeding
- On first run, seeds "Admin" and "User" roles
- Creates a default admin account:
  - Email: `admin@admin.com`
  - Password: `Admin@123`
- Default admin is assigned the "Admin" role

## Tech Stack

| Technology | Version |
|---|---|
| .NET | 9.0 |
| ASP.NET Core MVC | 9.0 |
| Entity Framework Core | 9.0.9 |
| ASP.NET Core Identity | 9.0.9 |
| AutoMapper | 15.0.1 |
| SQL Server | - |

## Getting Started

1. **Update the connection string** in `PL/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=MVCProject;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

2. **Apply migrations** to create the database:
   ```bash
   dotnet ef database update
   ```

3. **Run the application**:
   ```bash
   dotnet run --project PL
   ```

4. **Login** with the default admin account:
   - Email: `admin@admin.com`
   - Password: `Admin@123`

## Project Structure

```
MVCProject/
├── DAL/
│   ├── Data/
│   │   ├── Contexts/
│   │   │   └── ApplicationDbContext.cs
│   │   ├── Configurations/
│   │   │   ├── BaseEntityConfigurations.cs
│   │   │   ├── DepartmentConfigurations.cs
│   │   │   └── EmployeeConfigurations.cs
│   │   └── Migrations/
│   ├── Models/
│   │   ├── Shared/
│   │   │   ├── BaseEntity.cs
│   │   │   ├── ApplicationUser.cs
│   │   │   └── Enums/
│   │   ├── DepartmentModule/
│   │   │   └── Department.cs
│   │   └── EmployeeModule/
│   │       └── Employee.cs
│   └── Repositories/
│       ├── Interfaces/
│       └── Classes/
├── BLL/
│   ├── DTO/
│   │   ├── Department/
│   │   └── Employee/
│   ├── Services/
│   │   ├── Interfaces/
│   │   └── Classes/
│   ├── Factories/
│   └── MappingProfiles.cs
└── PL/
    ├── Controllers/
    │   ├── AccountController.cs
    │   ├── HomeController.cs
    │   ├── DepartmentController.cs
    │   ├── EmployeeController.cs
    │   ├── RoleController.cs
    │   └── UsersController.cs
    ├── Views/
    ├── ViewModels/
    ├── SeedData/
    │   └── DbInitializer.cs
    └── wwwroot/
```

### Controllers

| Controller | Auth | Description |
|---|---|---|
| AccountController | AllowAnonymous | Register, Login, Logout |
| HomeController | - | Home page, Privacy, Error |
| DepartmentController | Authorize | Department CRUD |
| EmployeeController | Authorize | Employee CRUD |
| RoleController | Admin only | Role CRUD with search |
| UsersController | Admin only | User list, role assignment, delete |
