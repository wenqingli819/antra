# Directives

> Directives are instructions in the DOM.
>
> Directives are classes that add more extra functionality to elements in Angular applications.



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
  // also work with property binding
  //key-vlue pairs, key is the css class names, the value is the condition determining whether this class should be attached or not
  // only add the class if the condition is true
  [ngClass] = "{online:serverStates==='online'}"
  ```

  

- `ngStyle` - dynamically update and render the style for the html property

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

- `*ngIf = "any expression return either true or false"`

  - ngIf + else logic

    ![image-20210416193148972](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416193148972.png)

    

- `*ngSwitch`





we can create our own custom directives

- ngbDropdownItem
- movieShopHighlightColor