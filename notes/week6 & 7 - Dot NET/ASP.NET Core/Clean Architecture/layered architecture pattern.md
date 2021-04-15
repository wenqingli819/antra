![This is an illustration that describes the layered architecture. The diagram shows four horizontal layers labeled, from top to bottom: Presentation layer, Application layer, Domain layer, and Infrastructure layer. Each layer contains folder-shaped box indicating constituent components that may be found in the layer. Those components are unnamed in presentation and application to indicate that any presentation component may have its own corresponding application component. In the Domain layer, components are labeled “Model” and “Services”; in the Infrastructure layer, components are labeled “Cache” and “IoC.” ](https://learning.oreilly.com/library/view/programming-aspnet-core/9781509304448/graphics/07fig01.jpg)

- Presentation

  each screen in the presentation that posts a command to the back end of the system groups data into an input model and receives a response using classes in a view model.

- The application layer

  - made of controller-specific service classes. 

  - create a service class for each controller and have the controller action methods simply yield to the service class. Methods in the service class will receive classes in the input model and return classes from the view model. Internally, the service class will perform any due transformation to make data map nicely to the presentation and be ready for processing in the back end.

  - The primary purpose of the application layer is to abstract business processes as users perceive them and to map those processes to the hidden and protected assets of the application’s back end.

- The domain layer

   business logic. use cases.

   1. domain models

      business logic and behavior

   2. domain services

      brings data in, loads state into a domain model class

   is any core logic of the specific business that is reusable across multiple presentation layers. The domain logic is about business rules and core business tasks using a data model that is strictly business-oriented.

- #### Infrastructure 

  - data persistence (O/RM frameworks like Entity Framework), external web services, specific security API, logging, tracing, IoC containers, email, caching, and more.