# Notification Service API

This project implements a RESTful API for a notification service that supports sending notifications via multiple channels (e.g., email, SMS, push notifications). The API provides endpoints to manage notification types, send notifications, and retrieve notification statuses.

## Table of Contents

- Project Overview
- Architecture and Design Patterns
- Folder Structure
- Implementation Details
- Best Practices
- Getting Started
- Usage
- Technologies Used
- Contributing
- License

## Project Overview

The Notification Service API is designed to provide a scalable and maintainable notification system that supports multiple notification channels. The API allows for CRUD operations on notification types and notifications, ensuring a clean separation of concerns and adhering to SOLID principles.

## Architecture and Design Patterns

The project follows **Clean Architecture** principles and leverages several design patterns, including:

- **Domain-Driven Design (DDD):** The core domain logic is encapsulated within the `Domain` project, ensuring business rules and behaviors are centralized and encapsulated.
- **CQRS (Command Query Responsibility Segregation):** Separates read operations (queries) from write operations (commands) to optimize performance and scalability.
- **Repository Pattern:** Provides a clean API for data access operations, abstracting the data layer and promoting testability.
- **Unit of Work Pattern:** Ensures atomic operations across multiple repositories, maintaining data consistency.
- **Dependency Injection (DI):** Uses DI to manage dependencies, promoting loose coupling and enhancing testability.

## Folder Structure

The project is organized into several layers to adhere to Clean Architecture:

- **NotificationService.API**: Contains the controllers, configuration, and startup files for the ASP.NET Core Web API.
- **NotificationService.Application**: Holds the application logic, including commands, queries, services, interfaces, and handlers.
- **NotificationService.Domain**: Contains the domain entities, value objects, enums, and domain logic.
- **NotificationService.Infrastructure**: Includes data access implementations, such as repositories and the Entity Framework Core context.

## Implementation Details

1. **NotificationService.API**

   - **Controllers**: Implements RESTful endpoints for managing notifications and notification types.
     - `NotificationController`: Handles endpoints for creating, updating, deleting, and retrieving notifications.
     - `NotificationTypeController`: Manages endpoints for CRUD operations on notification types.

2. **NotificationService.Application**

   - **Interfaces**: Defines contracts for services (`INotificationService`, `INotificationTypeService`) and repositories (`INotificationRepository`, `INotificationTypeRepository`).
   - **Commands and Queries**: Implements the CQRS pattern, with separate classes for commands (create, update, delete) and queries (get, list).
   - **Services**: Encapsulates business logic and coordinates operations using repositories and unit of work.
   - **Handlers**: Contains command and query handlers that perform the actual operations using the service layer.

3. **NotificationService.Domain**

   - **Entities**: Represents the core domain models, such as `Notification` and `NotificationType`.
   - **Value Objects**: Defines value objects, such as `NotificationContent`, encapsulating specific concepts within the domain.
   - **Enums**: Enumerations used throughout the domain, such as `Channel` for notification delivery methods.

4. **NotificationService.Infrastructure**

   - **Data**: Configures Entity Framework Core, including the `NotificationContext` DbContext.
   - **Repositories**: Implements repository interfaces to perform CRUD operations against the data store.
   - **Unit of Work**: Implements a unit of work to manage transactions across multiple repositories.

## Best Practices

- **Separation of Concerns**: Divided the application into multiple projects, each responsible for a specific concern.
- **Encapsulation**: Entities and value objects encapsulate all business rules and invariants, ensuring data consistency and validity.
- **Asynchronous Programming**: Utilizes async/await throughout the application to ensure non-blocking operations, enhancing performance and scalability.
- **Dependency Injection**: Promotes loose coupling and testability by injecting dependencies through constructors.
- **Error Handling and Validation**: Uses a unified `Result` pattern for error handling and validation, providing a consistent approach to managing operation results.

## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or Visual Studio Code
- SQL Server (if not using the In-Memory Database)

### Installation

1. Clone the repository:

   ```
   git clone https://github.com/shreyansbhatt/notification-service.git
   cd notification-service
   ```

2. Open the solution in Visual Studio or Visual Studio Code.

3. Restore the NuGet packages:

   ```
   dotnet restore
   ```

4. Run the database migrations (if using SQL Server):

   ```
   dotnet ef database update -p NotificationService.Infrastructure -s NotificationService.API
   ```

### Running the Application

- Run the application using Visual Studio or the .NET CLI:

  ```
  dotnet run --project NotificationService.API
  ```

## Usage

### Endpoints

- **Notification Types**:
  - `GET /api/notificationtypes`: Get all notification types.
  - `GET /api/notificationtypes/{id}`: Get a specific notification type by ID.
  - `POST /api/notificationtypes`: Create a new notification type.
  - `PUT /api/notificationtypes/{id}`: Update an existing notification type.
  - `DELETE /api/notificationtypes/{id}`: Delete a notification type.

- **Notifications**:
  - `POST /api/notifications/send`: Send a notification.
  - `GET /api/notifications/{id}`: Get a notification by ID.
  - `GET /api/notifications/all`: Get all notifications with optional filters.

## Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (In-Memory Database and SQL Server)
- MSTest (Unit Testing)
- Moq (Mocking Framework)
- Swagger/OpenAPI (API Documentation)

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any improvements or suggestions.

## License

This project is licensed under the GNU License. See the `LICENSE` file for details.
