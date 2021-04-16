# Directives

> Directives are classes that add more extra functionality to elements in Angular applications.
>



### Three Types of Directives

##### Component direc

##### ives

```typescript
@Component({
  selector: 'app-root', //specifies the beginning and end of the component.
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
```



##### Attribute directives

change the look or behavior of an HTML element, component, or another directive.

- `NgClass` - add or remove a set of CSS classes
- `NgStyle` - add or remove a set of HTML styles
- `NgModel` - adds two-way data binding to an HTML form element.



##### Structural directives

manipulate the DOM layout

- `*NgFor`
- `*NgIf`
- `*NgSwitch`





we can create our own custom directives

- ngbDropdownItem
- movieShopHighlightColor