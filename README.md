# MedTracker — Medical Device Maintenance System

Final Year Project — Gabriela Nicacio Lima

---

## About

MedTracker is a web-based application built with ASP.NET Core MVC for tracking medical devices, reporting incidents and recording maintenance actions. The system includes role-based authentication, a statistics dashboard with charts, and an admin panel for user management.

---

## Features

### Core
- Full CRUD for Devices, Incidents and Maintenance Actions
- Dashboard with live statistics and animated stat cards
- Incident severity and status tracking with colour-coded badges
- Cascade delete between related entities (Device → Incidents → Maintenance Actions)

### Authentication
- Login and Register with ASP.NET Core Identity
- Three roles: Admin, Technician and Viewer
- Protected routes — unauthenticated users redirected to login automatically
- User name and role badge visible in navbar after login

### Admin Panel
- View all registered users and their roles
- Change user roles (Admin, Technician, Viewer)
- Delete users
- Only accessible to Admin users

### Statistics
- Pie chart — device status distribution
- Bar chart — incidents by severity
- Doughnut chart — incident status breakdown
- Line chart — incidents reported over last 6 months
- Bar chart — maintenance actions by technician

### UI
- Professional navbar with live clock and breadcrumb navigation
- Responsive design with Bootstrap 5
- Font Awesome icons throughout
- CSS variables for consistent theming

---

## Tech Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core MVC 8.0 | Web application framework |
| Entity Framework Core 8.0 | Object-Relational Mapper |
| SQL Server LocalDB | Database for development |
| ASP.NET Core Identity 8.0 | Authentication and roles |
| Bootstrap 5 | Frontend UI framework |
| Chart.js | Statistics charts |
| Font Awesome 6 | Icon library |
| Git / GitHub | Version control |

---

## Default Users

| Email | Password | Role |
|---|---|---|
| admin@medtracker.com | Admin123! | Admin |
| tech@medtracker.com | Tech123! | Technician |
| viewer@medtracker.com | Viewer123! | Viewer |

---

## How to Run

**1.** Clone the repository
git clone https://github.com/nicaciogaby/MedicalDeviceMaintenance.git

**2.** Open the solution in Visual Studio 2022

**3.** Open Package Manager Console and run
Update-Database

**4.** Press F5 to run the application

**5.** The database will be seeded automatically with sample data and default users

**6.** Navigate to `/Account/Login` to sign in

---

## Project Structure
MedicalDeviceMaintenance/
├── Controllers/
│   ├── HomeController.cs         — Dashboard
│   ├── DevicesController.cs      — Device CRUD
│   ├── IncidentsController.cs    — Incident CRUD
│   ├── MaintenanceActionsController.cs — Maintenance CRUD
│   ├── AccountController.cs      — Login, Register, Logout
│   ├── AdminController.cs        — User management
│   └── StatisticsController.cs   — Charts and statistics
├── Models/
│   ├── Device.cs
│   ├── Incident.cs
│   ├── MaintenanceAction.cs
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   └── AdminViewModels.cs
├── Data/
│   ├── AppDbContext.cs            — Database context with Identity
│   ├── SeedData.cs               — Sample devices, incidents, maintenance
│   └── SeedRoles.cs              — Default roles and users
└── Views/
├── Home/                      — Dashboard
├── Devices/                   — Device CRUD views
├── Incidents/                 — Incident CRUD views
├── MaintenanceActions/        — Maintenance CRUD views
├── Account/                   — Login and Register
├── Admin/                     — User management
├── Statistics/                — Charts page
└── Shared/_Layout.cshtml      — Master layout

---

## Planned Features

- Search and filter on Devices and Incidents lists
- Toast notifications for user feedback
- Export data to PDF or Excel
- Deploy to Azure or AWS

---

## Project Board

Track progress and planned features at:
https://github.com/nicaciogaby/projects
