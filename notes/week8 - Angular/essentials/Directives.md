# Directives

> Directives are instructions in the DOM.
>
> Directives are **classes** that add more extra functionality to elements in Angular applications.



### Three Types of Directives

##### Components are directives, but directives with a template

our instruction: Angular, please add our component in this place.

```typescript
@Component({
  selector: 'app-root', //specifies the beginning and end of the component.
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
```



##### Attribute directives

change the look or behavior of an HTML element, component, or another directive.

Built-in

- `ngClass` -  dynamically add or remove a set of CSS classes

  ```typescript
  <p [ngClass]> ="key:value";
  // key is the css class names
  //value is the condition determining whether this class should be attached or not
  ```

  ```typescript
  // only add the css class if the condition is true
  
  [ngClass] = "{online:serverStates==='online'}"
  ```

  

- `ngStyle` - dynamically update and render the style for the html attribute

  ```
  <p [ngStyle]> ="key:value";
  ```

  ```typescript
  // component.html
  <p [ngStyle]> = "{backgroundColor:getColor()}"
  // the square bracket means we want to bind some property on this directive
  // [ngStyle] property expects to get a JavaScript object    
      
      
  // component.ts
  getColor(){
      return this.serverStatus ==='online'? 'green':'red';
  }
  ```

  

- `ngModel` - adds two-way data binding to an HTML form element.

custom directives

![image-20210416192052008](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416192052008.png)

##### Structural directives

manipulate the DOM layout. add or remove elements

- `*ngFor`

  ```html
  <app-server *ngFor="let server of servers"></app-server>
  ```

  ![image-20210419225708667](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210419225708667.png)

- `*ngIf = "any expression return either true or false"`

  - ngIf + else logic, using local reference

    ![image-20210419224226682](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210419224226682.png)

    <ng-template> use to mark places in the DOM

- `*ngSwitch`

[ng-template, ng-content, ng-container, and *ngTemplateOutle](https://www.freecodecamp.org/news/everything-you-need-to-know-about-ng-template-ng-content-ng-container-and-ngtemplateoutlet-4b7b51223691/)



we can create our own custom directives

- ngbDropdownItem
- movieShopHighlightColor



| Attribute Directives                                         | Structural Directives                                        |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| look like a normal HTML attribute (possibly with data binding or event binding) | look like a normal HTML attribute but have a leading *       |
| only affect / change the element they are added to           | affect a whole area in the DOM (elements get added / removed) |

![image-20210421004149149](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210421004149149.png)

![image-20210421004116989](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210421004116989.png)



### Custom Directives

general rules

1. recommend to use directives as attributes and prefixed with a namespace



##### Simple custom attribute directive

```
ng generate directive ccCardHover
```

<img src="../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210422112443209.png" alt="image-20210422112443209" style="zoom: 67%;" />

`selector` using CSS matching rules to match a component or directive to 

![image-20210422112401061](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210422112401061.png)

`ElementRef` is a wrapper for our actual DOM element and we access the DOM element using the property `nativeElement` on it.



##### Build a Hold-to-Delete Button

`$ ng g directive holdable`

attach this directive to a button and keep track of the internal state and then emit events up to the parent component

```typescript
import {Directive, HostListener, EventEmitter, Output} from  '@angular/core';
import {Observable,Subject,interval} from 'rxjs';
import {takeUntil, tap, filter} from 'rxjs/operators';

@Directive({
    selector:'[holdable]'
})

export class HoldableDirective{
    @Output() holdTime : EventEmitter<number> = new EventEmitter();
    //data(number of milliseconds that a user has held the button down) we want to emit to the parent component. 
    // let the parent component to decide how long the user can hold teh button before it fires off the delete operation
    
    state: Subject<string> = new Subject(); // 2 states, user holding the button down or not
    cancel: Observable<string>;
    
    constructor(){
        
    }
    // listen to mouse events on this element, then update the internal state
    // 2 ways user can cancle holding the button,
    // 1) mouse up
    // 2) move the mouse outside of the button area
    // we use HostListener to listen events like mouseup that are built into the DOM
    @HostListener('mouseup',['$event'])
    @HostListener('mouseleave',['$event'])
    onExit(){
        this.state.next('cancel')
    }
    
    @HostListener('mousedown',['$event'])
    onHold(){
        // %c - custom css
        console.log('%c started hold', 'color:#5fba7d; font-weight:bold;')
    this.state.next('start')    
    const n = 100; // every tenth of the second
    }
}
```

```html
<main>
    <h3> Hold to Delete </h3>
    <button class = "button" holdable (holdTime)="">     
    </button>
</main>

<router-outlet></router-outlet>
```

[unfinished, see more](https://www.youtube.com/watch?v=kl-UMCHpEsw&ab_channel=Fireship)