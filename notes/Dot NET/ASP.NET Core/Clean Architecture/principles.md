# Principles

### separation of concerns

avoid mixing different code responsibilities in the same(method|class|project)

##### The Big Three

1. data access
2. business rules and domain model
3. user interface



### SOLID

##### single responsibility

not coupling your tools together

no god class to do everything

anytime if you want to change one of those responsibilities, you have to chance of messing up or breaking any working code.



##### Don't repeat yourself

take duplicate(fundamentally the same) logic, refactor it into methods, group methods into cohesive classes

group classes into folders and namespaces by

- responsibility
- level of abstraction
- etc

further group class folders into projects



##### Dependency Inversion Principle

interface that allow you to plug in technology to be able to modularize our appliances  and switch out which thing we want to plug in a given time.

**adapter design pattern**

if in an application that doesn't have the correct interface that you want and how you can use an adapter to solve the problem.

##### Invert(and inject) dependencies

both high level classes and implementation-detail classes should depend on abstractions(interfaces).

**Explicit dependencies principle**

request all dependencies via their constructor

why interfaces are important?

![image-20210405143405097](../../../../resources/image-20210405143405097.png)

![image-20210405143355641](../../../../resources/image-20210405143355641.png)

《working effectively with legacy code》

==vertical slice architecture==

break apart your monolithic application that has all the code that runs together and it allows you test pieces of it in isolation from one another 



