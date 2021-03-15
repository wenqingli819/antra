# JavaScript Async

[Callbacks](..\1. intro\1.7 functions.md#Callbacks)

promises

Async/Await

### What is Asynchronous JavaScript?

"I will finish later"

- Functions running in parallel with other functions

- e.g., `setTimeout()`

  

### `Promise`

"I promise a Result"!

- A promise is an object that may produce a single value some time in the future: either a resolved value, or a reason that it’s not resolved (e.g., a network error occurred). 
- Promises are eager, meaning that a promise will start doing whatever task you give it as soon as the promise constructor is invoked. If you need lazy, check out [observables](https://github.com/Reactive-Extensions/RxJS) or [tasks](https://github.com/rpominov/fun-task).
- 3 possible states: 
  - fulfilled, 
  - rejected, 
  - or pending. 

| Result  | Call                    |
| :------ | :---------------------- |
| Success | myResolve(result value) |
| Error   | myReject(error object)  |

##### Explain `Promise` in Human Language

This is a real-life analogy for things we often have in programming:

1. A **“producing code”** that does something and takes time. For instance, some code that loads the data over a network. That’s a “singer”.
2. A **“consuming code”** that wants the result of the “producing code” once it’s ready. Many functions may need that result. These are the “fans”.
3. **A *promise* is a special JavaScript object that links the “producing code” and the “consuming code” together**. In terms of our analogy: this is the “subscription list”. The “producing code” takes whatever time it needs to produce the promised result, and the “promise” makes that result available to all of the subscribed code when it’s ready.

==Note:== JavaScript promises are more complex than a simple subscription list: they have additional features and limitations.

#### Code

```javascript
let promise = new Promise(function(resolve, reject) {
   // the function is executed automatically when the promise is constructed
  	resolve("done");

  	reject(new Error("…")); // ignored
  	setTimeout(() => resolve("…")); // ignored
    
    // The executor should call only one resolve or one reject. Any state change is final.
});
```



```javascript
let promise = new Promise(function(resolve, reject) {
  setTimeout(() => resolve("done!"), 1000);
});

// resolve runs the first function in .then
promise.then(
  result => alert(result), // shows "done!" after 1 second
  error => alert(error) // doesn't run
);

//--------------------------------------------------------------------

let promise = new Promise(function(resolve, reject) {
  setTimeout(() => reject(new Error("Whoops!")), 1000);
});

// reject runs the second function in .then

promise.then(
  result => alert(result), // doesn't run
  error => alert(error) // shows "Error: Whoops!" after 1 second
);

```

#### Finally

```javascript
new Promise((resolve, reject) => {
  setTimeout(() => resolve("result"), 2000)
})
  .finally(() => alert("Promise ready"))
  .then(result => alert(result)); // <-- .then handles the result

//--------------------------------------------------------------------

new Promise((resolve, reject) => {
  throw new Error("error");
})
  .finally(() => alert("Promise ready"))
  .catch(err => alert(err));  // <-- .catch handles the error object
```

#### `Callback` VS `Promise`

| Promises                                                     | Callbacks                                                    |
| :----------------------------------------------------------- | :----------------------------------------------------------- |
| Promises allow us to do things in the natural order. First, we run `loadScript(script)`, and `.then` we write what to do with the result. | We must have a `callback` function at our disposal when calling `loadScript(script, callback)`. In other words, we must know what to do with the result *before* `loadScript` is called. |
| We can call `.then` on a Promise as many times as we want. Each time, we’re adding a new “fan”, a new subscribing function, to the “subscription list”. More about this in the next chapter: [Promises chaining](https://javascript.info/promise-chaining). | There can be only one callback.                              |



### `Async`/`Await`

*"async and await make promises easier to write"*

- `async` makes a function **return a Promise**

- `await` makes a function **wait for a Promise**

```javascript
async function f() {
  return 1;
}

f().then(alert); // 1
```

​					||

```javascript
async function f() {
  return Promise.resolve(1);
}

f().then(alert); // 1
```

##### await

`await` work only inside `async` functions

```javascript
async function f() {

  let promise = new Promise((resolve, reject) => {
    setTimeout(() => resolve("done!"), 1000)
  });

  let result = await promise; //The function execution “pauses” at this line and resumes when the promise settles, with result becoming its result. 

  alert(result); // "done!"
}

f();
```

##### Error handling

```javascript
async function f() {
  await Promise.reject(new Error("Whoops!"));
}
```

​						||

```javascript
async function f() {
  throw new Error("Whoops!");
}
```

###### try catch block

```javascript
async function f() {

  try {
    let response = await fetch('/no-user-here');
    let user = await response.json();
  } catch(err) {
    // catches errors both in fetch and response.json
    alert(err);
  }
}

f();
```





Further read:

https://javascript.info/promise-basics

https://medium.com/javascript-scene/master-the-javascript-interview-what-is-a-promise-27fc71e77261