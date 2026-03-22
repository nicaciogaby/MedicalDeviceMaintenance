# Medical Device Maintenance & Incident Tracking System

## Project Overview

This project is a web-based system designed to help track medical device incidents and maintenance activities.

The system allows users to:

- Register medical devices
- Record incidents related to devices
- Track maintenance actions taken to resolve issues
- Maintain a history of device problems and solutions

This project is part of the **Higher Diploma in Science in Computing** at **Atlantic Technological University Sligo**.

---

## Technologies Used

- ASP.NET Core MVC (.NET 8)
- C#
- Entity Framework Core
- SQL Server LocalDB
- HTML / CSS / Bootstrap
- GitHub for version control

---

## System Architecture

The application follows an MVC architecture:

- **Models** → Data structures (Device, Incident, MaintenanceAction)
- **Views** → User interface pages
- **Controllers** → Application logic

Database access is handled using **Entity Framework Core (Code-First approach)**.

---

## Features Implemented

Current system functionality includes:

- Device Management (CRUD)
- Incident Tracking
- Incident Status Workflow (Open, In Progress, Closed)
- Linking Incidents to Devices
- Maintenance Actions linked to Incidents
- Navigation menu for system sections
- Basic user interface using Bootstrap

---

## Database Structure

The system contains three main entities:

**Device**
- Id
- Name
- SerialNumber
- Location
- CreatedAt

**Incident**
- Id
- Title
- Description
- Status
- ReportedAt
- DeviceId

**MaintenanceAction**
- Id
- ActionTaken
- ActionDate
- IncidentId

Relationships:
Device → Incidents → MaintenanceActions


---

## How to Run the Project

1. Clone the repository
2. Open the solution in **Visual Studio**
3. Run database migrations:

Add-Migration InitialCreate
Update-Database


4. Run the project
5. Navigate to:

Devices
/Incidents
/MaintenanceActions


---

## Project Status

The project currently includes the core functionality required for the **interim submission**.

Future improvements may include:

- Incident dashboard
- Search and filtering
- Improved UI
- Reporting features

---

## Author

Gabriela Nicacio Lima  
Higher Diploma in Science in Computing  
Atlantic Technological University Sligo