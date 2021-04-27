

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

-----------

### Component communication

#### Sending data from parent to child

```
<parent-component>
  <child-component></child-component>
</parent-component>
```

use `@Input` on child component <img src="https://angular.io/generated/images/guide/inputs-outputs/input.svg" alt="Input data flow diagram" style="zoom: 25%;" />

1. configure the child component 

`@Input()` use this in the child component, it allows a parent component to update data in the child component

```typescript
//child.ts
import { Component, Input } from '@angular/core';

export class ItemDetailComponent {
  @Input() item: string; //  receive its value from the parent component.
}

// child.html
<p>
  Today's item: {{item}}
</p>
```

2. configure the parent component

```typescript
// parent.html
<app-item-detail [item]="currentItem"></app-item-detail>
    
    
// parent.ts
export class AppComponent {
  currentItem = 'Television'; 
    //With @Input() in the child component, Angular passes the value for currentItem to the child so that item renders as Television.
}
```

<img src="https://angular.io/generated/images/guide/inputs-outputs/input-diagram-target-source.svg" alt="Property binding diagram" style="zoom: 25%;" />



--------

#### Sending data from child to parent 

using @Output on child![Output diagram](https://angular.io/generated/images/guide/inputs-outputs/output.svg)

##### Child to Parent: Sharing Data via `Output()` and `EventEmitter`

> emit data from the child, which can be listened to by the parent.

scenarios: share data changes that occur on things 

- like button clicks, 
- form entries, 
- and other user events.

1. configure the child class,  `Output` and `EventEmitter`

   ```c#
   import { Output, EventEmitter } from '@angular/core';
   
   export class ItemOutputComponent {
       
   // declare a messageEvent variable with the Output decorator and set it equal to a new event emitter
   @Output() newItemEvent = new EventEmitter<string>(); 
   //uses the `@Output()` property to raise an event to notify the parent of the change.
   
   // create a function that calls emit on this value we want to sent
   addNewItem(value: string) {
       this.newItemEvent.emit(value);
     }
   }
   ```

   ```html
    <!--> child.html <-->
   
   <label>Add an item: <input #newItem></label>
    <!--> use HTML label for <input> elements <-->
   
    <!--> create a button to trigger this function. <-->
   <button (click)="addNewItem(newItem.value)">  
       Add to parent's list
   </button>
   ```


3. parent

   ```typescript
   //parent.ts
   export class AppComponent {
     items = ['item1', 'item2', 'item3', 'item4'];
   
     addItem(newItem: string) {
       this.items.push(newItem);
     }
   }
   
   
   //parent.html
   <app-item-output (newItemEvent)="addItem($event)"></app-item-output>
   ```

   

##### Child to Parent: Sharing Data via `ViewChild`

@[ViewChild](https://angular.io/api/core/ViewChild) on the parent allows a one component to be injected into another.

```typescript
// parent
export class ParentComponent implements AfterViewInit {
  @ViewChild(ChildComponent) child;
    
  constructor() { }

  message:string;

  ngAfterViewInit() {
    this.message = this.child.message
  }
}

//child
export class ChildComponent {

  message = 'Hola Mundo!';

  constructor() { }

}
```

https://fireship.io/lessons/sharing-data-between-angular-components-four-methods/

--------

#### pass data between unrelated components

When passing data between components that lack a direct connection, such as siblings, grandchildren, etc, you should you a shared service.  

[RxJS BehaviorSubject](https://xgrommx.github.io/rx-book/content/subjects/behavior_subject/index.html) 

You can also use a regular RxJS Subject for sharing data via the service, but here’s why I prefer a BehaviorSubject.

- It will always return the current value on subscription - there is no need to call `onnext`
- It has a `getValue()` function to extract the last value as raw data.
- It ensures that the component always receives the most recent data.

- [data.service.ts](https://fireship.io/lessons/sharing-data-between-angular-components-four-methods/#dataservicets)
- [parent.component.ts](https://fireship.io/lessons/sharing-data-between-angular-components-four-methods/#parentcomponentts-3)
- [sibling.component.ts](https://fireship.io/lessons/sharing-data-between-angular-components-four-methods/#siblingcomponentts)





### Component life cycle

![image-20210421222831767](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210421222831767.png)

if we are on the component, if we use snapshot and we have use routerLink to have a new route on this component. Then the url would get updated, but the content still the same.

angular doesn't re-instantiate the component if we are on the component;

it is ok to use `snapshot` for the first initialization, but to be able to react to subsequent changes, we need to `subscribe`.

`params` is an observable: a way to subscribe to some event which might happen in the future, then execute the code when it happens without having to wait for it

subscription will always live in memory because it is not closely tied to your component. but under the hood, angular cleans up the subscription for us whenever the component is destroyed . 