# Job Candidate Management (Backend API)

Job Candidate Management is a backend API developed to organize and handle applicant data. By providing the ability to create, read, update, and delete (CRUD) candidate data, it guarantees efficient management of job candidate details.

## Table of Contents:
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Project Structure](#project-structure)
- [Libraries Used](#libraries-used)
- [Running the Project](#running-the-project)
- [API Documentation](#api-documentation)
- [Testing](#testing)
- [Future Improvements](#future-improvements)

---

## Getting Started:
You can start by using Visual Studio to open the solution. This project provides scalable and user-friendly APIs designed especially for managing Job Candidates.

---

## Prerequisites:
Make sure you have the following before beginning the project:
1. **.NET SDK (version 8.0 or higher)**: Download and install from the official [Microsoft .NET website](https://dotnet.microsoft.com/download).
2. **Integrated Development Environment (IDE)**: Use Visual Studio.

---

## Project Structure
To make the project clean, well-structured, and for better maintainability, I have placed the files in separate directories making separate libraries.

### /JobCandidateManagement.API
Under this directory, there are subdirectories for handling separate operations required for the API.
- **/API** : This directory contains the main source code for the Job Candidate Management API.
- **/Data** : This directory is divided into further subdirectories. Each subdirectory contains its own logic.
  - **/EntityMap** : Defines the entity models and validation.
  - **/JobCandidateDbContext** : Stores the database context, responsible for interacting with the database and managing data access.
- **/MediatR** : Used MediatR Design pattern with CQRS. Contains the core business logic of the application and processing data.
- **/Models** : Stores the entity model.
- **/Test** : All of the Candidate Management API's unit tests are located in this directory, which is divided into subdirectories to match the source code's layout.
  - **/Service** : Helper class for handler.
  - **/TestCases** : Contains test cases to validate business logic.
  - **/TestData** : Includes mock data for testing purposes.

### /JobCandidateManagement.App.Common
Under this directory, it includes services that are consumed by other making it as common. Subdirectories present under this are:
- **/Configuration** : Includes class for mapper configuration.
- **/Mapper/Automapper** : Contains mapping logic for the conversion between entity models and view models.

### /JobCandidateManagement.UI.Models
This directory includes the data transfer objects used for input and output in API requests and responses.

---

## Libraries Used:
Various libraries have been used in this project for its core functionality.
1. **EntityFrameworkCore** : An Object-Relational Mapper (ORM) for .NET applications that makes data access easier by using .NET objects to communicate with databases.
2. **EntityFrameworkCore.SqlServer** : A database provider for Entity Framework Core that allows EF Core to work with Microsoft SQL Server databases.
3. **EntityFrameworkCore.Tools** : Used to perform tasks like database migrations, scaffold models, and inspect the database schema.
4. **MediatR** : A library for implementing the Mediator pattern in .NET applications.
5. **AutoMapper** : An object-to-object mapping library in .NET.
6. **XUnit** : Unit testing framework for .NET applications.
7. **NSubstitute** : Mocking library for .NET that allows us to create mock objects.
8. **EntityFrameworkCore.InMemory** : Allows us to use an in-memory database for testing or lightweight situations.

---

## Running the Project

To manage the project run, take these actions:
- Make a local copy of the repository.
- Confirm that you have installed version 8.0 or higher of the .NET SDK.
- Open Visual Studio and open the project.
- Adjust the `appsettings.json` file's connection string to correspond with your environment's settings.

---

## Testing
This project uses **XUnit** for testing.

---

## API Documentation
You can check API Endpoints from here: [Swagger UI](https://localhost:7063/swagger/index.html)

---

## Future Improvements
There are several potential improvements that could enhance the functionality, performance, maintainability, and scalability of our system. Some of the major enhancements include:

- **Error Handling and Logging** : To handle common exceptions, we can use middleware or exception filters to implement centralized error handling. Incorporate logging to monitor processes and mistakes (e.g., `ILogger`).
- **Authentication and Authorization** : Implementing permission (such as role-based access control) and authentication (such as JWT tokens) for sensitive data and endpoints will add security levels.
- **CI/CD Integration** : One future objective is to automate deployment and testing using a continuous integration/continuous deployment pipeline.
