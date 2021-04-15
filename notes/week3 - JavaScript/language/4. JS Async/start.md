# JavaScript Async

[Callbacks](..\1. intro\1.7 functions.md#Callbacks)

promises

Async/Await

### What is Asynchronous JavaScript?

"I will finish later"

- Functions running in parallel with other functions

- e.g., `setTimeout()`

  

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