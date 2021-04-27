### What’s the difference between [style] and [ngStyle] in Angular?

| style                                             | ngStyle                                                      |
| ------------------------------------------------- | ------------------------------------------------------------ |
| single bindings                                   | bind to an object that expresses as many conditions and cases as you need |
| [style.color]="errorMessageColor"                 | <div [ngStyle]="currentStyles">   xxx  </div>                |
| <div [style.color]="hasError ? 'red' : 'black' "> |                                                              |



```html
<div [ngStyle]="currentStyles">   xxx  </div>

this.currentStyles = {     
       'font-style':  this.canSave  ? 'italic' : 'normal',  
       'color':       this.hasError ? 'red'   : 'black',     
       'font-size':   this.hasError ? '24px'   : '12px'   
};
```



There are many ways to bind data, which way is more suitable under what scenario?

https://blog.briebug.com/blog/5-ways-to-pass-data-into-child-components-in-angular





when use @input in the child component, is the parent component and child component sharing the same instance to hold that data, or do we create a new instance in different components,  then data gets copied to that instance?

after component gets disposed the instance will be gone. 





when does the component be destroyed by the 

I used log console to see it, it seems ever time I fresh the page, the old one would be gone and a new component instance will be created

