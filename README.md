# 🚇 MetroX Management System

![C#](https://img.shields.io/badge/C%23-.NET-blue)
![EF Core](https://img.shields.io/badge/EFCore-SQLServer-green)
![Status](https://img.shields.io/badge/Status-Completed-success)
![Architecture](https://img.shields.io/badge/Architecture-Layered-orange)

---

## 📌 Project Overview

MetroX is a smart metro ticket management system developed using C#, SQL Server, and Entity Framework Core.

The project simulates a real metro booking environment where users can manage tickets, trains, and stations through a professional console interface with database integration and analytics reports.

---

# ✨ Features

## 🎫 Ticket Management
- Book New Ticket
- View All Tickets
- Search Tickets
- Delete Tickets
- Revenue Reports

## 🚆 Train Management
- Train Information
- Capacity Management
- Train-Ticket Relationships

## 📍 Station Management
- Multiple Stations
- Station Locations
- One-to-Many Relationships

## 📊 Analytics & Reports
- Total Revenue
- Ticket Statistics
- LINQ Queries
- Price Filtering

## 🖥️ Console UI
- Professional Table Output
- Colored Console Interface
- Structured Menu System

---

# 🛠️ Technologies Used

- C#
- .NET Console Application
- Entity Framework Core
- SQL Server
- LINQ
- EF Core Code First

---

# 🧠 Concepts Applied

- CRUD Operations
- Service Layer Architecture
- Entity Relationships
- Include() for Related Data
- Database Migrations
- Exception Handling
- Validation
- Clean Console UI

---

# 🗄️ Database Design

## Entities
- Tickets
- Trains
- Stations

## Relationships
- One Train → Many Tickets
- One Station → Many Tickets

---

# 📂 Project Structure

```text
MetroX/
│
├── Data/
├── Models/
├── Services/
├── UI/
├── Seed/
│
├── Program.cs
├── README.md
└── MetroX.sln
```

---

# 🚀 Getting Started

## 1️⃣ Clone Repository

```bash
git clone https://github.com/Anoudalsaidi/Smart-Metro-System.git
```

---

## 2️⃣ Install Required Packages

```powershell
Install-Package Microsoft.EntityFrameworkCore

Install-Package Microsoft.EntityFrameworkCore.SqlServer

Install-Package Microsoft.EntityFrameworkCore.Tools
```

---

## 3️⃣ Create Database

```powershell
Add-Migration InitialCreate

Update-Database
```

---

## 4️⃣ Run Project

```bash
dotnet run
```

---

# 📈 Sample Reports

- Total Revenue
- Ticket Statistics
- Search Results
- Expensive Tickets
- Train Usage Analytics

---

# 🎯 Learning Outcomes

This project helped in understanding:

- EF Core Code First
- SQL Server Integration
- LINQ Queries
- Database Relationships
- Layered Architecture
- Clean Console UI Design
- Backend Development Workflow

---

# 🔮 Future Improvements

- Authentication System
- Admin Dashboard
- Payment Simulation
- ASP.NET Core Web API Version
- Role Management
- Async/Await Support

---

# 👩‍💻 Author

Anoud Alsaidi

## 🌐 GitHub
https://github.com/Anoudalsaidi

---

# ⭐ Project Status

✅ Completed  
🚀 Continuously Improving
