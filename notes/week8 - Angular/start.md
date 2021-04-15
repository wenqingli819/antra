### What is Angular?

- component-based framework
- A collection of well-integrated libraries that cover a wide variety of features, including **routing**, **forms management**, **client-server communication**, and more
- A suite of developer tools to help you develop, build, test, and update your code

Why Angular?

- we can use JavaScript/jQuery too



### AngularJS vs Angular

| AngularJS      | Angular2              | Angular4                                                     |
| -------------- | --------------------- | ------------------------------------------------------------ |
| 2010           | 2016                  |                                                              |
| overly complex | rewrite to typescript | ![image-20210415002918022](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210415002918022.png) |



### Components

building blocks that compose an application.

```javascript
import { Component } from '@angular/core';

@Component({
  selector: 'hello-world',
  template: `
    <h2>Hello World</h2>
    <p>This is my first component!</p>
    `,
})
export class HelloWorldComponent {
  // The code in this class drives the component's behavior.
}
```




