# Component

| MVC Controller | Angular Component      |
| -------------- | ---------------------- |
| return view    | visually and logically |

```typescript
@Component({
  selector: 'app-root',      //html tag to render view
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
```

**selector**: the CSS element selector that represents the component. For every place that this selector appears in the HTML file, Angular will insert this component’s view.



2 ways to execute any component

1. using Router

2. using selector

   can execute the component by using xx selector in any other component

   ![image-20210413145022694](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210413145022694.png)





### app.component

<router-outlet>

</router-outlet>

Router-outlet in Angular works as a placeholder which is used to load the different components dynamically based on the activated component or current route state. Navigation can be done using router-outlet directive and the activated component will take place inside the router-outlet to load its content.

![image-20210415102636879](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210415102636879.png)

remember to add route in here



### `ngOnInit()`

`ngOnInit` : component's life cycle hook which runs first after `constructor(default method)` when the component is being initialized.

An `ngOnInit()` is a good place for a component to fetch its initial data. Components should be cheap and safe to construct. You should not, for example, fetch data in a component constructor.

```typescript
import { Component, OnInit } from '@angular/core';

export class App implements OnInit {
  constructor() {
     // Called first time before the ngOnInit()
  }

  ngOnInit() {
     // Called after the constructor and called  after the first ngOnChanges() 
  }
}
```

https://stackoverflow.com/questions/35763730/difference-between-constructor-and-ngoninit

https://angular.io/guide/lifecycle-hooks#initializing-a-component-or-directive