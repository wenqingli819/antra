# Lexical Environment

In JavaScript, every running function, code block `{...}`, and the script as a whole have an internal (hidden) associated object known as the ***Lexical Environment*.**



### 1. variables 

- A variable is a property of a special internal object, associated with the currently executing block/function/script.
- Working with variables is actually working with the properties of that object.

​											                             	Lexical Environment

​											/										                                           	\

​             *Environment Record*     																		reference

stores local variables as its properties                                                        to the outer lexical environment

(and some other information like the value of `this`).                     (the one associated with the outer code)

<img src="../../../../../resources/image-20210309115923624.png" alt="image-20210309115923624" style="zoom:67%;" />   ***global* Lexical Environment**

The global Lexical Environment has no outer reference, that’s why the arrow points to `null`.



### 2. Function Declarations

A function is also a value, like a variable.

**Function Declaration is instantly fully initialized.**

we can use a function even before its declaration.



### 3. Inner and outer Lexical Environment



### 4. returning a function

```javascript
function makeCounter() {
  let count = 0;

  return function() {
    return count++;
  };
}

let counter = makeCounter();
```



**Closure**

There is a general programming term “closure”, that developers generally should know.

A [closure](https://en.wikipedia.org/wiki/Closure_(computer_programming)) is a function that remembers its outer variables and can access them. In some languages, that’s not possible, or a function should be written in a special way to make it happen.