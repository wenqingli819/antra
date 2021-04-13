### What is Angular?

- component-based framework
- A collection of well-integrated libraries that cover a wide variety of features, including **routing**, **forms management**, **client-server communication**, and more
- A suite of developer tools to help you develop, build, test, and update your code



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





lazy load pages based on roles

src -> **main.ts**

Every Angular application will have  at least one `AppModule`, we can create as many as we want

`AdminModule` ==> Functionality of Admins

`AccountModule` ==> user account

`SharedModule` 

`MovieModule`

we load these modules lazily 





TypeScript class that is decorated with NgModule will become an Angular Module

![image-20210413142457198](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210413142457198.png)