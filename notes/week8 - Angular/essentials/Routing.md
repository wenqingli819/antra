# Routing and navigation

### What is Routing

Angular will grab the path from the URL. It will match the path against the routes registered in our application (component).

Angular will not magically know which path should render which component. It’s our responsibility to tell Angular what to render when a specific URL is visited. This process is what’s known as routing.

The router maps URL-like paths to views instead of pages.

 the router can *lazy-load* the module on demand.

The router logs activity in the browser's history, so the back and forward buttons work as well.



### Routing scenarios

- when you need to pass parameters to the route
  - to navigate to the product detail view, we need to pass the `product ID`, so that component can retrieve it and display it to the user.



### Steps:

- **configure the routes**

  ```typescript
  { path:'product/:id', component: ProductComponent }
  ```

  /product/1
  /product/2

  The **id** is dynamic and changes as per the selected Product. To handle such scenario use [ angular router](https://www.tektutorialshub.com/angular/angular-routing-navigation/)

  

  ==route order matters!!!!!!!!==

  

- ##### add a router outlet

  <router-outlet>

  where we display the corresponding component when a given route becomes active

  ![image-20210415004551512](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210415004551512.png)

- ##### defining the navigation and add links

  ```typescript
<a [routerLink]="['/Product', product.productID]">{{product.name}} </a>
  
  ```

//dynamically takes the value of id from the product object.

 <img src="../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210415004803856.png" alt="image-20210415004803856" style="zoom:33%;" />



 

 

  ![image-20210415004839520](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210415004839520.png)



follower => follower detail

dynamic url

we don't send "/followers/1" , this parameter should be rendered dynamically

use [routerLink] property binding syntax, bind a expression

![image-20210415005046959](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210415005046959.png)



![image-20210415005439743](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210415005439743.png)



### Accessing URL parameters: Snapshot vs Subscription

1. import `ActivatedRoute`and DI it in our component, in order to get the params we want.

2. two ways of accessing the params

   | route.snapshot.paramMap                                      | route.paramMap.subscribe                                     |
   | ------------------------------------------------------------ | ------------------------------------------------------------ |
   | **not to update** your URL parameter within the same component you are accessing it, | **update** the URL parameter within the same component, then you have to use a subscription. |
   | the parameter **would only be accessed once, when the component loads**. Hence, it won’t be updated, even if you change its value from within the same component. |                                                              |



## Routing Information

RouterModule.forRoot  is defined in RouterModule class, it’s a static method  
We use this define our main/root routes, as application grows we can separate them in to small routers where we use forChild method that will help us better separate or app in to different areas

The order of the routes is important and we need to have more specific routes first and more generic routes next.  Not found Route should be last as ** is a wild character and it will catch all rotes.

##### RouterOutlet

Second step is to add Router Outlet as Angular will display a component associate to the route

##### RouterLink

We don’t use href on our anchor tag because it's going to reloads all the files and initializes the angular app again and which might become slower as application grows. 
That’s why we use  directive called routerLink, for simple routes we use it as an attribute and set it to a route
Ex:  <a class="nav-link" routerLink="/login">Login</a>

When you want generate links dynamically like adding data to URL we should use routerLink as property binding syntax , here we bind it to an expression where first element of the array is the path followed by route parameter
<a class="nav-link" [routerLink]="['/admin/books', book.id ]">Login</a>

##### RouterLinkActive

We use  routerLinkActive="active" to apply CSS when the link is active, we can add multiple CSS classes with spaces
Ex : 

```typescript
<li class="nav-item"  routerLinkActive="active">
<a class="nav-link" routerLink="/login">Login</a>
</li>
```





##### Get the Route Parameters

First thing we need to do is Inject Activated route class in our constructor. Then in ngOnInit we can get the parameter and its value

```typescript
this.route.paramMap
	.subscribe(params => 
	{
	console.log(params);
	console.log(params.get('id'));
});
// looks like its case-sensitive
// get() method returns a string, use + sign before to convert to number.
```

Here we  use Observable because Observable will stream data of async events and all subscribers will be notified of any changes
Angular typically destroys one component and recreates new component when we navigate from one page to another page.
If in your app there is a scenario where you want to be on **same Component** but you want to **change route params** then `route.paramMap` is used.

If you are sure that You don’t allow user to be on same page  and navigate back and forth then we can use a **snapshot** instead of Observable
this.route.snapshot.paramMap.get('id')

##### Routes with multiple Parameters

Ex: http://localhost:4200/admin/books/title/22
<a class="nav-link" [routerLink]="['/admin/books', book.id, book.title ]">Login</a>

##### Query String (optional)  Parameters

<a class="nav-link"  routerLink="/shoppingcart"  [queryParams="{page: 1, search: 'hunger'}"]>Shopping Cart</a>
Subscribing to multiple observables on same time

let newObservable = Observable.combineLatest([
	this.route.paramMap,
	this.route.queryParamMap
]);

newObservable.subscribe(
	combined => {
	const id = combined[0].get('id');
	const search = combined[0].get('search');
	// then call the service based on these
}
);

##### Programmatic Routing

Many times you want to navigate to different page using Programming like when user clicks on a button link etc.?
Here is import Router and use Router class.
this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
this.router.navigate(['/login'],  {relativeTo: this.Route}); // relative to which path, by default its home

From Abhilash Reddy 