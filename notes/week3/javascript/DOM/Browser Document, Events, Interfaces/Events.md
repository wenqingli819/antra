# Events

Events = when the user or the browser manipulates a page.

### HTML5 Standard Events:

**Mouse events:**

- `click` – when the mouse clicks on an element (touchscreen devices generate it on a tap).
- `contextmenu` – when the mouse right-clicks on an element.
- `mouseover` / `mouseout` – when the mouse cursor comes over / leaves an element.
- `mousedown` / `mouseup` – when the mouse button is pressed / released over an element.
- `mousemove` – when the mouse is moved.

**Keyboard events:**

- `keydown` and `keyup` – when a keyboard key is pressed and released.

**Form element events:**

- `submit` – when the visitor submits a `<form>`.
- `focus` – when the visitor focuses on an element, e.g. on an `<input>`.

**Document events:**

- `DOMContentLoaded` – when the HTML is loaded and processed, DOM is fully built.

**CSS events:**

- `transitionend` – when a CSS-animation finishes.

[read more](https://www.w3schools.com/tags/ref_eventattributes.asp)



### Event handlers

To react on events we can assign a handler – a function that runs in case of an event.

A handler can be set in HTML with an attribute named `on<event>`.

##### `onclick` Event Type

```html
<input type="button" onclick="alert('Hello World!')" value="Click me">

<-->note that inside onclick we use single quotes, because the attribute itself is in double quotes.</-->

// OR


<input type="button" id="button" value="Button">
<script>
  button.onclick = function() {
    alert('Click!');
  };
</script>
```

```html
<script>
  function countRabbits() {
    for(let i=1; i<=3; i++) {
      alert("Rabbit number " + i);
    }
  }
</script>

<input type="button" onclick="countRabbits()" value="Count rabbits!">
```



##### `onsubmit` Event type

validate() before submit

![image-20210310001941943](../../../../../resources/image-20210310001941943.png)



`onmouseover` and `onmouseout`

![image-20210310002039788](../../../../../resources/image-20210310002039788.png)



### addEventListener



