# Onion Architecture
> Onion Architecture was introduced by Jeffrey Palermo to provide a better way to build applications in perspective of better testability, maintainability, and dependability on the infrastructures like databases and services.
Onion, Clean or Hexagonal architecture are the same. Which is based on the Domain-Driven Desgin approach.

###### Domain Layer
At the center part of the Onion Architecture, the domain layer exists; this layer represents the business and behavior objects. The idea is to have all of your domain objects at this core. It holds all application domain objects. Besides the domain objects, you also could have domain interfaces. These domain entities don’t have any dependencies. Domain objects are also flat as they should be, without any heavy code or dependencies.

###### Repository Layer
This layer creates an abstraction between the domain entities and business logic of an application. In this layer, we typically add interfaces that provide object saving and retrieving behavior typically by involving a database. This layer consists of the data access pattern, which is a more loosely coupled approach to data access. We also create a generic repository, and add queries to retrieve data from the source, map the data from data source to a business entity, and persist changes in the business entity to the data source.

###### Services Layer
The Service layer holds interfaces with common operations, such as Add, Save, Edit, and Delete. Also, this layer is used to communicate between the UI layer and repository layer. The Service layer also could hold business logic for an entity. In this layer, service interfaces are kept separate from its implementation, keeping loose coupling and separation of concerns in mind.

###### UI Layer
It’s the outer-most layer, and keeps peripheral concerns like UI and tests. For a Web application, it represents the Web API or Unit Test project. This layer has an implementation of the dependency injection principle so that the application builds a loosely coupled structure and can communicate to the internal layer via interfaces.

Benefits of Onion Architecture
1.	Onion Architecture layers are connected through interfaces. Implantations are provided during run time.
2.	Application architecture is built on top of a domain model.
3.	All external dependency, like database access and service calls, are represented in external layers.
4.	No dependencies of the Internal layer with external layers.
5.	Couplings are towards the center.
6.	Flexible and sustainable and portable architecture.
7.	No need to create common and shared projects.
8.	Can be quickly tested because the application core does not depend on anything.

# References
1. https://www.codeguru.com/csharp/understanding-onion-architecture/
2. https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/
3. https://blog.ploeh.dk/2013/12/03/layers-onions-ports-adapters-its-all-the-same/


About My Project
I have implemented this project in ASP.net Core web API. 
It contains following features

1. Application is implemented on Onion architecture
2. Swagger UI
3. RESTful API
4. Entityframework Core
5. Expection handling
6. Automapper
7. Validation
8. Unit testing via XUnit
9. Integration testing via NUnit
10. Versioning
11. CQRS Pattern

# After download run these commands
1. add-migration Initial-commit-Application -Context ApplicationDbContext -o Migrations/Application
2. add-migration Identity-commit -Context IdentityContext -o Migrations/Identity
3. update-database -Context ApplicationDbContext 
4. update-database -Context IdentityContext
