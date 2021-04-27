# Data Binding

### What is Data Binding?

data binding = communication between typescript code (business logic) and what user sees (template html)



##### one-way data binding

- component 	--> 	view
  - **string interpolation**
  - **property binding**
  - attribute, class, style
- view     <--       component
  - using the **event binding** technique.

##### two-way data binding 

![ ](https://www.infragistics.com/community/cfs-filesystemfile/__key/CommunityServer.Blogs.Components.WeblogFiles/dhananjay_5F00_kumar.twowaydatabinding/5076.img4.PNG)

exchange data from the component to view and from view to the component. combine property and event binding. bind both directions.



### ------>  output data

##### String Interpolation 

` set values for properties of HTML elements or directives `

```c#
{{property name}}

{{'can hard code in here'}}
```



### property binding

`use if want to change some property, an HTML element or directive or a component`

##### Basic Syntax

```html
[property] = "data"    <!-- [] makes dynamic expression, without the brackets -> static value -->
```

##### Examples

```html
<!-- Notice the colSpan property is camel case -->
<tr><td [colSpan]="1 + 1">Three-Four</td></tr>
```

```html
<!-- Bind button disabled state to `isUnchanged` property -->
<button [disabled]="isUnchanged">Disabled Button</button>
```

```html
<!-- setting a property of a directive -->
//app.component.html
<p [ngClass]="classes">[ngClass] binding to the classes property making this blue</p>


//app.component.ts
classes = 'special';
```

```html
<!--  vind value between components-->
<app-item-detail [childItem]="parentItem"></app-item-detail>

// item-detail.component.ts
// declear childItem in temDetailComponent.
@Input() childItem: string;

// app.component.ts  -> some parent component
parentItem = 'lamp';

<!--  With this configuration, the view of <app-item-detail> uses the value of lamp for childItem. -->
```

![image-20210419112131870](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210419112131870.png)



**String Interpolation vs property binding**

Often [interpolation](https://angular.io/guide/interpolation) and property binding can achieve the same results.

use either form when rendering data values as strings, though interpolation is preferable for readability. However, when setting an element property to a non-string data value, you must use property binding.

| String Interpolation                                         | property binding                                             |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| converts the {{expression}} results to strings               | does not convert the expression result to a string.          |
| a convenient alternative to property binding.                | bind properties to DOM elements                              |
| **Avoid side effects:** The expression shouldn’t attempt to modify the application’s state in any way. | **Avoid side effects:** Avoid expressions that tend to cause unknown side effects. Stick to using data properties and methods/functions that have return value. The increment and decrement operators can’t be used here and variables can’t be assigned. |

example:

toggle button functionality, set paths programmatically, and share values between components.



### <------ react to (user) events

### event binding 

(event) - "expression"

$event

```typescript
// server.component.ts
onCreateServer(){
    // do something
}


// server.component.html
<button (click)="onCreateServer()"> Add Server </button> 
//when click event occurs, use this funciton
```



listen to the user input event

```html
<label> Server Name </label>
<input type = "text"
       class = "form-control"
       (input) = "onUpdateServerName($event)">
<p>{{serverName}}</p> 


<!--> COMPONENT.ts <-->
..
servernName='';
...
onUpdateServerName(events:Event){
    console.log(event);
	this.serverName = (<HTMLInputElement>event.target).value;
    }
```

![image-20210416183805224](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416183805224.png)

##### [`$event`](https://developer.mozilla.org/en-US/docs/Web/Events) = data emitted with that event

to fetch the event data

so `input` and `click` our default events provided by the DOM, they ship us some data when they are fired.

the click event gives us an object holds the coordinates we clicked.

we can capture this data use `$event` and pass that to the method we are calling.

```typescript
 this.serverName = (<HTMLInputElement>event.target).value;
```

```typescript
(input) = "myFunction()"
    
(click)="myFunction()"      
(dblclick)="myFunction()"   

(submit)="myFunction()"

(blur)="myFunction()"  
(focus)="myFunction()" 

(scroll)="myFunction()"

(cut)="myFunction()"
(copy)="myFunction()"
(paste)="myFunction()"

(keyup)="myFunction()"
(keypress)="myFunction()"
(keydown)="myFunction()"

(mouseup)="myFunction()"
(mousedown)="myFunction()"
(mouseenter)="myFunction()"

(drag)="myFunction()"
(drop)="myFunction()"
(dragover)="myFunction()"
```



### [Two-Way-Binding](https://angular.io/guide/two-way-binding)

(used mainly in [template-driven forms](https://angular.io/guide/forms)) 

combine property and event binding. bind both directions

- [Property binding](https://angular.io/guide/property-binding) sets a specific element property.

- [Event binding](https://angular.io/guide/event-binding) listens for an element change event.

  ![Data Binding](https://angular.io/generated/images/guide/architecture/component-databinding.png)

The component and view are always in sync, and changes made on either end are immediately updated both ways. Two-way binding is commonly used when dealing with forms where the user input is used to update the component’s state and vice versa.

![image-20210416184348061](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416184348061.png)

##### Basic Syntax

```typescript
<input [(ngModel)]="hero.name"> 
//1. trigger on the input event, and update the value of hero.name in our component automatically
//2. also update the value of the input element if we change hero.name somewhere else
```



### Binding to custom events

`@Output`

`EventEmitter`  `emit`

If data changed in child component, we want to inform the parent component

![image-20210417160243627](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210417160243627.png)

![image-20210417160226556](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210417160226556.png)

set @Output on child component![image-20210417160535241](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210417160535241.png)



### Local reference in Templates

a local reference can be place in any html element(with all its properties, not just the data).

// local reference in template pass through function

![image-20210417223631196](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210417223631196.png)

![image-20210417223838193](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210417223838193.png)

### Get access to DOM through @ViewChild

// local reference in template pass through @ViewChild

```typescript
@ViewChild('the name of the local reference') localref: ElementRef;
```



### Attribute, class, and style bindings





### Resources

https://cupofcode.medium.com/the-main-building-blocks-of-an-angular-application-explained-cup-of-angular-part-1-dce71c88d449