# Component

| MVC Controller | Angular Component      |
| -------------- | ---------------------- |
| return view    | visually and logically |

```typescript
@Component({
  selector: 'app-root',      //unique
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css','another cs file'] //it is an array, meaning we could add more css files here
})
```

### selector

##### What is Selector

like the CSS selector. 

It represents the component. 

For every place that this selector appears in the HTML file, Angular will insert this component’s view.

##### Types of Selectors

- selector (most commonly used!!)

  `'app-element'`

- attribute selector

  ` selector: '[app-element]'`

  ![image-20210416161517502](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416161517502.png)

  or ![image-20210416161613830](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416161613830.png)

  need to change the html accordingly 

### 2 ways to execute any component

1. using Router

2. using selector

   can execute the component by using xx selector in any other component

   ![image-20210413145022694](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210413145022694.png)



### app.component

Router-outlet in Angular works as a placeholder which is used to load the different components dynamically based on the activated component or current route state. 

Navigation can be done using router-outlet directive and the activated component will take place inside the router-outlet to load its content.

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



### Create a component

##### 1.create a component (not recommend to do it manually)

`courses.component.ts`

`course-form.component.ts`

```typescript
import{Component} from '@angular/core';

@Component({
    selector:'courses' 
    // <courses> "courses"
    // <div class="courses"> ".courses"
     // <div id="courses"> "#courses"
    
    template:'<h2>{{title}}</h2>' //will be evaluated at runtime
})
export class CoursesComponent{
    
}
```

```typescript
import{Component} from '@angular/core';

@Component({
    selector:'courses' 
    template:`
		<h2>{{title}}</h2>
		<ul>
			<li *ngFor="let course of courses">
				{{courses}}
			</li>
		</ul>
`
})
export class CoursesComponent{
    title = "List of courses";
    courses=["course1","course2","course3"];
}
```

##### Use Angular CLI - `ng g c course`  

CLI do this automatically, but do check:

1. app.module has that component import, and it is in the declarations
2. go to the xx.component file, check the selector

##### 2.register it in a module

![image-20210414225738117](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210414225738117.png)

##### 3.add an element in an HTML markup

![image-20210416155528445](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416155528445.png)

