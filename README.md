# OBAFramework.Template

🧱 A starter template for internal Web API projects at **OBA MMC**, built on .NET 8.

This template helps teams quickly bootstrap new microservices or web APIs using our internal best practices.

---

## 📦 Features

- ✅ Layered Architecture
- 🧅 Onion Repository Pattern
- ⚡ CQRS support with real working examples
- 🔄 Unit of Work for raw T-SQL and Dapper
- 🛠️ Dual ORM: **Dapper** + **Entity Framework Core**
- 🧬 Fluent Migrations for DB schema
- 👤 Base Authentication & Authorization
- 📁 FileService for handling uploads/downloads
- 📄 Swagger integration
- 🚨 Exception Handling
- 📝 Daily file-based logging
...
---

## 🚀 Getting Started

### ✅ Install the Template

```bash
dotnet new install https://dev.azure.com/???
📂 Create a New Project
bash
Copy
Edit
dotnet new obafw -n MyNewService
This will:

Rename all "OBAFramework" occurrences to MyNewService

Create a new directory with the new service name

📚 Project Structure
Project	Description
OBAFramework.Domain	Domain models and shared logic
OBAFramework.Repository	Repositories (EF Core & Dapper)
OBAFramework.Service	Business services
OBAFramework.ApiResponse	API layer, auth system, Swagger, etc.

🧪 Example Endpoints
GET /api/example/GetDecreaseGraduate — Fully wired CQRS example
(ExampleQuery → Repository → Service → Controller using Dapper)

GET /api/example/GetData — Simple request
(Model → Repository → Service → Controller)

📌 Notes
This template is intended for internal use only.

Requires .NET SDK 8.0 or later.

Daily logs are stored as text files in Logs/yyyy-MM-dd.log.

🔄 Updating the Template
After changes:

bash
Copy
Edit
dotnet new uninstall obafw
dotnet new install https://dev.azure.com/???
🙋 Support
Maintained by OBA MMC Development Team

pgsql
Copy
Edit
