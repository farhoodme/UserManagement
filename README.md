# UserManagement
Simple RESTful API for user management

### Project Architecture
Project developed based on **Domain Driven Design** patterns and **SOLID** principles which consists of three fundamental layers:

**Domain Layer:** Includes business objects and business rules.

**Application Layer:** Mediates between the Http Api (or Presentation) and Domain Layers. This layer perform specific application tasks using business objects and implements the application logic.

**Infrastructure Layer:** Provides generic technical capabilities that support higher layers mostly using libraries.

DDD mostly interest in the **Domain** and the **Application** layers

#### Domain Layer
This layer includes **Entities**, **Repositories** and **Domain Services**.
In the solution three projects named **UserManagement.Domain**, **UserManagement.Domain.Shared** and **UserManagement.EntityFrameworkCore** created the domain layer.

Entities are derived from the generic Entity<TKey> class and defines an Id property with the given primary key type.
**Auditing Interface** in the UserManagement.Domain.Shared project is use for implement CreationTime and LastModificationTime properties of entities.

This project provide a default generic repository for each entity. You can inject IRepository<TEntity, TKey> into your service and perform standard CRUD operations.
and also you can create the custom repository for entities and extend the IRepository<TEntity, TKey>.

Domain Services is used for implement the domain logic. and depends on repositories.
In this project the **UserManager** class is a domain service that implement to the domain logic for check user TCKN is exsits or not.
Domain Service methods typically get and return the domain objects (Entities).
Domain Services can used in the Application Services (Application Services get/return Data Transfer Objects).

#### Application Layer
This layer includes the **Application Services** and used to implement the use cases of application and expose domain logic to the presentation layer or Http Api client.
Thus, the presentation layer is completely isolated from domain layer.
In the solution three projects named **UserManagement.Application** and **UserManagement.Application.Contracts** created the application layer.

Application Services uses the Repositories and Domain Services and get/return Data Transfer Objects to the Http Api or Presentation layer.

Data Transfer Objects (DTO) are used to transfer data between the Application Layer and the Presentation Layer or Http Api clients.


### How to Run?

#### Create the Database
Check the **connection string** in the `appsettings.json` file under the **.HttpApi.Host** project.
The solution is configured to use **Entity Framework Core** with **MS SQL Server**.

#### Apply the Migrations
In the **Package Manager Console** make **.EntityFramreworkCore** project as Default Project.
using `Update-Database` command and create database and applies pending migrations.

#### Run the Application
In the solution explorer right click to the **.HttpApi.Host** project and select **Set as StartUp Project**.
Run the application which will open the SwaggerUI page in your browser:



