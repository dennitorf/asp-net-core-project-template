# CompanyName ProjectName API
 
## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

Use BaseEntity as parent class for auditable entities. 

Use BaseEvent as parent class for events entities. 


### Application

This layer contains all application logic. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Persistence

This layer contains the database responsability. Using the entities defined in Domain, feel free to add the Fluent API Configuration classes for the new entities. Keep the code organized based on features, and do not forget to add your own DBSet to the AppDbContext. 

The changes on the DB are handled via migrations, feel free to create your own migrations following below command: 

# dotnet ef migrations add NameOfMigration --project Src/CompanyName.ProjectName.Persistence/CompanyName.ProjectName.Persistence.csjproject

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebUI

This layer is a Web API application based on ASP.NET Core 7. 


