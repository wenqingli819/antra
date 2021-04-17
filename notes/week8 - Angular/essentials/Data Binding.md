# Data Binding

### What is Data Binding?

data binding = communication between typescript code (business logic) and what user sees (template html)



### ------>  output data

##### String Interpolation 

`use when we want to print some text to the website `

{{property name}}

{{property.name}}

{{'can hard code in here'}}

##### property binding

`use if want to change some property, an HTML element or directive or a coomponent`

[property] = "data"



many times we can either use string interpolation or property binding.



### <------ react to (user) events

##### event binding 

(event) - "expression"

```typescript
// server.component.ts
onCreateServer(){
    // do something
}


// server.component.html
<button xxxx (click)="onCreateServer()"> Add Server </button> 
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

##### `$event` 

to get access to the event data

so input and click our default events provided by the DOM, they ship us some data when they are fired.

the click event gives us an object holds the coordinates we clicked.

we can capture this data use `$event` and pass that to the method we are calling.



### Two-Way-Binding

combine property and event binding. bind both directions

Notice: ngModel is a directive. 

![image-20210416184348061](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416184348061.png)

[(ngModel)] = "data"         // react to events, and also update the value of  data in our component automatically. we can output this data too



Two-way data binding (used mainly in [template-driven forms](https://angular.io/guide/forms)) combines property and event binding in a single notation

```typescript
<input [(ngModel)]="hero.name">
```





### Resources

https://cupofcode.medium.com/the-main-building-blocks-of-an-angular-application-explained-cup-of-angular-part-1-dce71c88d449