

![image-20210309200431169](../../../../../resources/image-20210309200431169.png)



## DOM (Document Object Model)

DOM allows us to do anything with elements and their contents.

| document      | html tag |
| ------------- | -------- |
| document.body | \<body>  |

`style.background`

`innerHTML`

`offsetWidth`

```javascript
document.body.style.background = 'red'; // make the background red

setTimeout(() => document.body.style.background = '', 3000); // return back
```



#### There are [12 node types](https://dom.spec.whatwg.org/#node). In practice we usually work with 4 of them:

1. `document` – the “entry point” into DOM.
2. element nodes – HTML-tags, the tree building blocks.
3. text nodes – contain text.
4. comments – sometimes we can put information there, it won’t be shown, but JS can read it from the DOM.



### Searching

| Method                   | Searches by... | Can call on an element? | Live? |
| ------------------------ | -------------- | ----------------------- | ----- |
| `querySelector`          | CSS-selector   | ✔                       | -     |
| `querySelectorAll`       | CSS-selector   | ✔                       | -     |
| `getElementById`         | `id`           | -                       | -     |
| `getElementsByName`      | `name`         | -                       | ✔     |
| `getElementsByTagName`   | tag or `'*'`   | ✔                       | ✔     |
| `getElementsByClassName` | class          | ✔                       | ✔     |

##### getElement

- id must be unique
- `document.getElementById(id)`

```javascript
let elem = document.getElementById('elem');

  // make its background red
  elem.style.background = 'red';
```

- `elem.getElementsByTagName(tag)`
- `elem.getElementsByClassName(className)`

##### querySelector

- `elem.querySelectorAll(css)` returns all elements inside `elem` matching the given CSS selector.

```javascript
  let elements = document.querySelectorAll('ul > li:last-child');

  for (let elem of elements) {
    alert(elem.innerHTML); // "test", "passed"
  }
```

