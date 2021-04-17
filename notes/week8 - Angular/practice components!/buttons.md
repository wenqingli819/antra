### Enabled/Disabled Button

```typescript
// servers.component.ts
...
export class ServersComponent implements OnInit{
	allowNewServer=false;   // property
    constructor(){
        //after 2 seconds, set to true
        setTimeout(()=>{
            this.allowNewServer = true;
        }, 2000);
    }
}
ngOnInt(){
    
}
...
```

```html
// servers.component.html
<button class="btn btn-primary" 
        [disabled] = "!allowNewServer">    <!-- make this disabled dynamic using property binding  -->
     Add Server
</button>

or

<button class="btn btn-primary" 
        [disabled] = "!allowNewServer">
     	Add Server
</button>
<p>{{allowNewServer}}</p>

or

<button class="btn btn-primary" 
        [disabled] = "!allowNewServer">
     	Add Server
</button>
<p>{{allowNewServer}}</p>
```

[disabled] property binding

dynamically bind some property and disabled the HTML attribute

the HTML only sets the specific property on the underlying DOM element

each HTML element you use is parsed by the browser, translate to DOM model.

Therefore, we have an element in the DOM, and this element(node) has a couple of properties, a lot of these can't even be set through attributes on the HTML elements.

One of the properties is the disabled property, and you can set it through the disabled attribute, but here we are not using the disabled attribute anymore, with square brackets, we are directly binding to this native disabled property, this HTML element has.

interact with your DOM to change something there at runtime

==besides binding to  HTML element properties, we can bind our properties, like directives, and our own component==

#### add click event

```html
<button class="btn btn-primary" 
        [disabled] = "!allowNewServer"
        (click)="onCreateServer()"
        >
     	Add Server
</button>
<p>{{allowNewServer}}</p>
```

