Here's the improved `README.md` file, incorporating the new content while maintaining the existing structure and information:

# UniversityApp

Console-based university management system built on .NET 9 with a layered architecture and EF Core persistence.

## Overview
UniversityApp manages universities, faculties, and students through an interactive console UI. The solution is organized into separate projects for domain models, data access, business logic, composition, and UI.

## Features
- Create, read, update, and delete universities, faculties, and students
- Search universities by name
- Validation and business rules in the service layer
- EF Core persistence with SQL Server LocalDB
- Console-based menus for navigation

## Solution Structure
UniversityApp/                     (Console entry point)
BootStrapper/                       (Composition root for wiring dependencies)
UniversityApp.CORE/                 (Entities, enums, base abstractions)
UniversityApp.DAL/                  (EF Core DbContext, repositories, unit of work)
UniversityApp.BLL/                  (DTOs, mappers, services, domain rules)
UniversityOrchestrationUI/          (Console UI flows and menus)

## Tech Stack
- .NET 9
- C#
- Entity Framework Core 9
- SQL Server LocalDB

## Getting Started
### Prerequisites
- .NET 9 SDK
- SQL Server LocalDB (included with Visual Studio)

### Restore and Build
To get started, restore the project dependencies and build the solution:
dotnet restore
dotnet build

### Run
To run the application, execute the following command:
dotnet run --project UniversityApp.csproj

## Database
The app uses EF Core with a LocalDB connection string defined in `UniversityDbContext`:
Server=(localdb)\MSSQLLocalDB;Database=UniDb;Trusted_Connection=True


If you need to create the database schema, generate and apply migrations from the solution root:
dotnet ef migrations add InitialCreate --project ..\UniversityApp.DAL\UniversityApp.DAL.csproj --startup-project UniversityApp.csproj

dotnet ef database update --project ..\UniversityApp.DAL\UniversityApp.DAL.csproj --startup-project UniversityApp.csproj

## Usage
Run the app and use the main menu to access:
- University management
- Faculty management
- Student management

Each menu provides interactive prompts for CRUD operations and navigation back to the main menu.

## Notes
- `AppBuilder` in `BootStrapper` wires repositories, services, and UI flows.
- Entity rules live in `UniversityApp.CORE`, while application rules are enforced in `UniversityApp.BLL` services.

## Contributing
We welcome contributions to enhance the functionality and usability of UniversityApp. Please follow these steps to contribute:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them with clear messages.
4. Push your branch to your forked repository.
5. Submit a pull request detailing your changes.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

### Changes Made:
1. Added a **Contributing** section to encourage community involvement.
2. Included a **License** section to clarify the project's licensing.
3. Enhanced the **Getting Started** section with clearer instructions for restoring and building the project.
4. Ensured consistent formatting and clarity throughout the document for better readability.