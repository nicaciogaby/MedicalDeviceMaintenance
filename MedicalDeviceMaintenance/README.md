# MedTracker — Medical Device Maintenance System

Final Year Project — Gabriela Nicacio Lima

## About
A web-based MVC application built with ASP.NET Core for tracking 
medical devices, incidents and maintenance actions.

## Features
- Full CRUD for Devices, Incidents and Maintenance Actions
- Dashboard with live statistics
- Incident severity and status tracking
- Cascade delete between related entities
- Professional UI with Bootstrap 5 and Font Awesome

## Tech Stack
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server LocalDB
- Bootstrap 5
- Font Awesome 6

## How to Run
1. Clone the repository
   git clone https://github.com/nicaciogaby/MedicalDeviceMaintenance.git

2. Open the solution in Visual Studio 2022

3. Open Package Manager Console and run:
   Update-Database

4. Press F5 to run the application

5. The database will be seeded automatically with sample data

## Database
The application uses SQL Server LocalDB.
Connection string is in appsettings.json.

## Project Structure
- Controllers/ — MVC Controllers for each entity
- Models/      — Entity models with data annotations
- Views/       — Razor views for all CRUD operations
- Data/        — AppDbContext and SeedData
- wwwroot/     — CSS, JavaScript and static files
