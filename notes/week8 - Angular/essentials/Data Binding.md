# Data Binding

```typescript
li>{{hero.name}}</li>
<app-hero-detail [hero]="selectedHero"></app-hero-detail>
<li (click)="selectHero(hero)"></li>
```

- The `{{hero.name}}` [*interpolation*](https://angular.io/guide/interpolation) displays the component's `hero.name` property value within the `<li>` element.
- The `[hero]` [*property binding*](https://angular.io/guide/property-binding) passes the value of `selectedHero` from the parent `HeroListComponent` to the `hero` property of the child `HeroDetailComponent`.
- The `(click)` [*event binding*](https://angular.io/guide/user-input#binding-to-user-input-events) calls the component's `selectHero` method when the user clicks a hero's name.

Two-way data binding (used mainly in [template-driven forms](https://angular.io/guide/forms)) combines property and event binding in a single notation

```typescript
<input [(ngModel)]="hero.name">
```



### **a. One way binding:** 

A bind from the component **to** **the DOM** (Document Object Model, HTML is a kind of DOM). In our example, in line 2 we created an attribute called `**sentence**` and bound the h1 tag to it.



### **b. Property binding:** 

A property is a data variable of the component, so binding to property means being notified when the property changes — that means, from the component **to the DOM**..

![img](https://miro.medium.com/max/2944/1*Xi-v_y78jgo0RwzoNLdukA.png)

`cup-of-code` component has two properties: sentence and drink.

we bind our sentences *“My favorite drink is”* and *“coffee”* to these properties.

- Notice that I used the `**@Input()**` notation and that I added it to the **imports** from @angular/core.
- In the second variable, I used two different names: from the outside, it is called `**type-of-drink**` and from inside the component it is called `**drink**`.



### **c. Attribute binding:** 

> **What is the difference between attributes and properties?**
> *The difference is subtle.*
> *Attributes are referring to additional information of an object.*
> *Properties are describing the characteristics of an object.*
> *Most people use these two words as synonyms.*
> *[*https://www.researchgate.net/post/What_are_the_differences_between_attribute_and_properties*]*![img](https://miro.medium.com/max/1982/1*DtwuOQtp-_4jCiYGrbfH9w.png)



### **d. Two-way binding**

changes on one side will impact the other side, and vice-versa.

```typescript
<input [(ngModel)]="typeOfDrink"> 
    or
<input [value]="typeOfDrink" (input)="typeOfDrink=$event.target.value">
```

Notice that you can use the double brackets only with `ngModel`!



### **e. Event binding:**



### Resources

https://cupofcode.medium.com/the-main-building-blocks-of-an-angular-application-explained-cup-of-angular-part-1-dce71c88d449