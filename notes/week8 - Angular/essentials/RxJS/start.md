### What is RxJs?

> RxJS is a library for composing asynchronous and event-based programs by using observable sequences.  - **RxJS docs**



Collect

- use RxJS to send HTTP request and receive the response 

- create a stream of data, the stream is observable, we can watch it as items are added or emitted to the stream.

Pipe through a set of operations 

- transform 
- filter
- process

Combine

- combine the custom data with invoice data to display a customer with their overdue invoices

Cache







- **An Observable** is a stream of data
- **Observers** can register up to 3 callbacks:
  - *next* is called 1:M time to push new values to the observer
  - *error* is called at most 1 time when an error occurred
  - *complete* is called at most 1 time on completion

Without subscribing the stream won't start emitting values. This is what we call a **cold** **observable.**

It's similar to subscribing to a newspaper or magazine... you won't start getting them until you subscribe. Then, it creates a 1 to 1 relationship between the producer (observable) and the consumer (observer).

### RxJS operators

 two kinds of operators:

- Creation operators
- Pipeable operators: transformation, filtering, rate limiting, flattening

#### zip()

- `zip` doesn’t start to emit until each inner observable emits at least one value
- `zip` emits as long as emitted values can be collected from all inner observables
- `zip` emits values as an array

![img](https://www.freecodecamp.org/news/content/images/2020/05/1_oY4pB5RbNeloyauM1tpWmg.png)



#### combineLatest()

- `combineLatest` doesn’t start to emit until each inner observable emits at least one value
- When any inner observable emits a value, emit the last emitted value from each

With `combineLatest`, order matters!!

![img](https://www.freecodecamp.org/news/content/images/2020/05/1_TrJG2NP6PgA0HJMj598lpQ.png)

#### forkJoin()

- If one of the inner observables throws an error, all values are lost
- `forkJoin` doesn’t complete

![img](https://www.freecodecamp.org/news/content/images/2020/05/1_O-Uis5OrgaeUrh6JSgHkTg.png)

[ref](https://www.freecodecamp.org/news/understand-rxjs-operators-by-eating-a-pizza/)



Promises vs. Observables

self-subscribe or not

Forgetting to subscribe

accidently making multiple http requests

hot & cold observables

shared observables