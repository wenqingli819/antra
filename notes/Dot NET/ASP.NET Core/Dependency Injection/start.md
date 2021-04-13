### What is DI?

> *Dependency Injection* is a set of software design principles and patterns that enables you to develop loosely coupled code.

similar to a central software design principle called the ==Liskov Substitution Principle==. This principle states that we should be able to replace one implementation of an interface with another without breaking either the client or the implementation.

intercepting one implementation with another implementation of the same interface is known as the ==*Decorator* design pattern==



[How to explain dependency injection to a 5-year-old? )](https://stackoverflow.com/questions/1638919/how-to-explain-dependency-injection-to-a-5-year-old)

![image-20210409201925759](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210409201925759.png)

What this means in terms of object-oriented software development is this: collaborating classes (the five-year-old) should rely on infrastructure (the parents) to provide necessary services.



- 

  <img src="https://learning.oreilly.com/library/view/dependency-injection-principles/9781617294730/image_fi/294730c01/01-04.png" alt="01-04.eps" style="zoom:50%;" />

  In contrast to the hardwired hair dryer, plugs and sockets define a loosely coupled model for connecting electrical appliances.

<img src="../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210409211447655.png" alt="image-20210409211447655" style="zoom: 33%;" />

When you aggregate several implementations into one, you use the ==*Composite* design pattern==. 

 The power strip enables you to add and remove the hair dryer while the computer is running. 

<img src="https://learning.oreilly.com/library/view/dependency-injection-principles/9781617294730/image_fi/294730c01/01-09.png" alt="01-09.eps" style="zoom:50%;" />

When traveling, you often need to use an adapter to plug an appliance into a foreign socket (for example, to recharge a camera). This corresponds to the ==*Adapter design pattern*==. Sometimes, translation is as simple as changing the shape of the plug, or as complex as changing the electric current from alternating current (AC) to direct current (DC).



### purpose of DI

- maintainability
  - through *loose coupling*.
  - Program to an interface, not an implementation.
  -  ==*Open/Closed Principle*==: a new requirement should only necessitate the addition of a new class, with no changes to other already-existing classes of the system.

- late binding

- support unit testing

  - Being able to add new features without touching existing parts of the system means that problems are isolated.

- DI is not a Service Locator/Abstract Factory. DI makes you never have to imperatively ask for Dependencies. Rather, you require consumers to supply them.

  ```c#
  // Service Locator/Abstract Factory
  public interface IServiceLocator
  {    
      //one method allowing the creation of all sorts of types
  	object GetService(Type serviceType);
  }
  ```



With software, a client often expects a service to be available. If you remove the service, you get a `NullReferenceException`.





### Benefits and scope



### Dependency Injection Questions

##### Dependency Injection, Dependency Inversion, Inversion of Control?



##### Do we need DI Containers to apply DI?

 - It’s entirely possible to apply DI without using a DI Container
 - Where do the instances come from?



##### I see that interfaces are used with DI. Is there a reason abstract classes aren't used? Just wondering.

We can use whatever abstractions we like with Dependency Injection.

**interfaces**,

- generally preferred 

abstract classes

- use when we have shared code in the implementations 

base classes.

https://blog.ploeh.dk/2018/02/19/abstract-class-isomorphism/





### other related concepts

other related concepts such as **SOLID**, **Clean Code**, and even **Aspect-Oriented Programming**.





Resources

https://blog.ploeh.dk/2014/06/10/pure-di/

