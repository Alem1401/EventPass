# 🎟️ EventPass

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![Angular](https://img.shields.io/badge/Angular-20.0-red)
![TypeScript](https://img.shields.io/badge/TypeScript-5.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

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

```
EventPass/
├── EventPassFE/              # Angular Frontend Application
│   ├── src/
│   │   ├── app/             # Application components & modules
│   │   ├── assets/          # Static assets (images, styles)
│   │   └── environments/    # Environment configurations
│   └── README.md
│
├── Backend/                  # .NET Backend API
│   ├── Domain/              # Core business entities & rules
│   ├── Application/         # CQRS handlers & use cases
│   ├── Infrastructure/      # Database & external services
│   └── API/                 # Controllers & API endpoints
│
└── README.md
```

---

## 🛠️ Getting Started

### Prerequisites

Make sure you have the following installed:
- **Node.js** (v18 or higher)
- **.NET SDK** (v8.0 or higher)
- **SQL Server** (LocalDB or full installation)
- **Angular CLI** (`npm install -g @angular/cli`)

### Installation

#### 1. Clone the Repository
```bash
git clone https://github.com/Alem1401/EventPass.git
cd EventPass
```
#### 2. Backend Setup
```bash
cd Backend
dotnet restore
dotnet build
```
#### 3. Database Setup
```bash
# Update the connection string in appsettings.json
# Then run migrations
dotnet ef database update
```
#### 4. Frontend Setup
```bash
cd EventPassFE
npm install
```

### Running the Application

**Start the Backend:**
```bash
cd Backend
dotnet run
```
The API will be available at `http://localhost:5000` (or configured port)

**Start the Frontend:**
```bash
cd EventPassFE
ng serve
```
The application will be available at `http://localhost:4200`

---

## 📚 API Documentation

The API follows RESTful principles with the following main endpoints:

- **Events**: `/api/events` - CRUD operations for events
- **Tickets**: `/api/tickets` - Ticket purchase and management
- **Venues**: `/api/venues` - Venue information and management
- **Performers**: `/api/performers` - Artist and performer data
- **Users**: `/api/users` - User account management

**Swagger Documentation**: Available at `http://localhost:5000/swagger` when running in development mode

---

## ⚙️ Configuration

### Backend Configuration

Update `appsettings.json` in the Backend project:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EventPassDb;Trusted_Connection=True;"
  },
  "JwtSettings": {
    "SecretKey": "your-secret-key-here",
    "Issuer": "EventPass",
    "Audience": "EventPassUsers",
    "ExpirationInMinutes": 60
  }
}
```

### Frontend Configuration

Update `src/environments/environment.ts`:

```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api'
};
```

---

## 🗺️ Roadmap

- [ ] Payment gateway integration (Stripe/PayPal)
- [ ] Email notifications for ticket purchases
- [ ] QR code generation for tickets
- [ ] Mobile app (React Native/Flutter)
- [ ] QR code ticket validation system
- [ ] Multi-language support (i18n)
- [ ] Social media integration
- [ ] Advanced analytics dashboard

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. **Fork** the repository
2. Create a **feature branch** (`git checkout -b feature/amazing-feature`)
3. **Commit** your changes (`git commit -m 'Add amazing feature'`)
4. **Push** to the branch (`git push origin feature/amazing-feature`)
5. Open a **Pull Request**

Please ensure your code follows the existing code style and includes appropriate tests.

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**Alem1401**
- GitHub: [@Alem1401](https://github.com/Alem1401)
- Project Link: [https://github.com/Alem1401/EventPass](https://github.com/Alem1401/EventPass)

---

## 🙏 Acknowledgments

- Angular Team for the amazing framework
- .NET Community for Clean Architecture guidance
- Microsoft for excellent documentation and tools
- All contributors who help improve this project

---

**⭐ If you find this project useful, please consider giving it a star!**