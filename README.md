# 🎟️ EventPass

**EventPass** is a modern web application for discovering events, browsing details, and purchasing tickets. The platform also includes a comprehensive **Admin Panel** for managing the entire event ecosystem.

---

## 🚀 Tech Stack

**Frontend**
- **Angular** – Modern web framework  
- **Angular Material** – UI component library  
- **TypeScript** – Primary programming language  

**Backend**
- **.NET** – REST API framework  
- **CQRS Pattern** – Command Query Responsibility Segregation  
- **Clean Architecture** – Domain-driven design principles  

**Database**
- **SQL Server** – Primary data storage  

---

## ✨ Features

### User Portal
- 🔍 **Search & Discovery** – Find events with advanced filtering  
- 📋 **Event Details** – Comprehensive info including venues, dates, pricing, performers  
- 🎫 **Ticket Management** – Reserve and purchase tickets seamlessly  
- 👤 **Personal Profile** – Manage preferences and ticket history  

### Admin Panel
- 🎭 **Event Management** – Create, update, and manage events  
- 🏟️ **Venue Control** – Manage venue details and capacities  
- 👥 **User Administration** – Manage user accounts  
- 🎤 **Performer Management** – Artist and performer profiles  
- 📊 **Capacity Control** – Real-time availability monitoring  

---

## 🏛️ Architecture Overview

**EventPass** follows **Clean Architecture** principles with **CQRS pattern**, ensuring:

- **Separation of Concerns** – Distinct layers for domain, application, and infrastructure  
- **Domain-Driven Design** – Business logic centered around the core domain  
- **Testability** – Easy unit testing via dependency inversion  
- **Maintainability** – Modular structure for easier updates and extensions  

### Architectural Layers
- **Domain Layer** – Core business entities and rules  
- **Application Layer** – Use cases and CQRS handlers  
- **Infrastructure Layer** – External concerns (database, APIs)  
- **Presentation Layer** – User interfaces (Angular frontend)  

### CQRS Benefits
- **Scalability** – Separate read and write models  
- **Performance** – Optimized queries and commands  
- **Flexibility** – Independent evolution of read/write sides  

This architecture ensures a **robust, scalable, and maintainable platform** capable of growing with business needs.

---

## 📦 Project Structure

