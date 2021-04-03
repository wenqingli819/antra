### Model binding

built in MVC. map the incoming request to the C# object (method parameters)



### pass data from Controller to View (3 ways)

> **ViewBag/ViewData** a way of adding some extra data from Controller to View along with your model. Both of these objects work well  when you use external data.	



| ViewBag                                                      | ViewData                                                     | TempData                               | ViewModel (recommended) |
| ------------------------------------------------------------ | ------------------------------------------------------------ | -------------------------------------- | ----------------------- |
| dynamic property                                             | dictionary type, key must be string                          | also a dictionary                      | strongly typed          |
| using ViewBag, the compiler will not detect an error when you use a DateTime as if it were a string. | ViewDataDictionary class.                                    | TempDataDictionary class               |                         |
| doesn’t need typecasting and null checks. <br>ViewBag internally inserts data into ViewData dictionary. So the key of ViewData and property of ViewBag must **NOT** match. | value must be typecast to an appropriate type before using it. |                                        |                         |
| can use ViewBag around any ViewData object so that you could assign dynamic properties to it, making it more flexible. | ViewData's life only lasts during the current HTTP request. ViewData values will be cleared if redirection occurs. | stays for the time of an HTTP Request. |                         |



1. `Strongly Typed Models`

<img src="../../../resources/image-20210330232818069.png" alt="image-20210330232818069" style="zoom:50%;" />

2.  `ViewBag`

    The ViewBag in ASP.NET MVC is used to transfer temporary data (which is not included in the model) from the controller to the view.

    Dynamic properties are not checked during compilation, unlike normal types. 

    Internally, ViewBag is a wrapper around [ViewData](https://www.tutorialsteacher.com/mvc/viewdata-in-asp.net-mvc).

    ![image-20210331094213861](../../../resources/image-20210331094213861.png)

    use for:

    - small amount of data
      - Shopping carts
      - Dropdown lists options
      - Widgets
      - Aggregated data

    do not use for:

    ​		complex relational data, big sets of aggregate data, data 		coming from a variety of sources, and dashboards.

> ViewBag uses the dynamic feature that was added in C# 4.0.
>
> 
>
> ViewBag=ViewData + Dynamic wrapper around the ViewData dictionary.

example1.1

![image-20210330235620665](../../../resources/image-20210330235620665.png)

example1.2 

initialized on the "View" page itself using 'ViewBag.Title = "Index"'

![img](https://csharpcorner.azureedge.net/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/Images/2.png)

example2.1 assign values in controller for the model class, and rendered it in the view 

![img](https://csharpcorner.azureedge.net/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/Images/3.png)

example2.2  pass a list of students.

![img](https://csharpcorner.azureedge.net/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/Images/4.png)



3. `ViewData`, it is like a key-value pair

![img](https://www.tutorialsteacher.com/Content/images/mvc/viewdata.png)



https://www.tutorialsteacher.com/mvc/viewdata-in-asp.net-mvc

https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/



### `Async` and `Await` 

use to prevent thread starvation 

![image-20210331202448565](../../../resources/image-20210331202448565.png)



### DI

SOLID’s [dependency inversion principle](https://stackify.com/dependency-inversion-principle/) introduces interfaces between a higher-level class and its dependencies. That decouples the higher-level class from its dependencies so that you can change the code of a lower-level class without changing the code that uses it.

.NET Core has built in DI

.NET Framework did not had.. we used to use 3rd party libs like **NinJect**, **Autofact**

##### DI 3 ways

1. **constructor injection**  

   inject the implementation of the constructor

2. method injection

3. property injection

https://www.c-sharpcorner.com/blogs/dependency-injectionc-sharp

##### Scope

1. AddScoped

   it will reuse the same instance within the HTTP request

2. AddTransient

   it will create instance each and every time

3. AddSingleton

   it will create instance and re-use the same instance throughout the application until application dies...

##### DI Steps

1. make sure your classes are written against interfaces
2. create constructor and use interfaces as parameter with readonly 
3. initialize those readonly interfaces with constructor parmeter
4. use DI framework container to register concrete types for those interfaces

##### Circular Dependencies

https://medium.com/software-ascending/circular-dependencies-in-dependency-injection-403b790daebb





### `readonly` property

we can only change it during the initialization or inside of the constructor.

![image-20210401002400425](../../../resources/image-20210401002400425.png)

why we need readonly?

if remove, then someone can create the instance anywhere in the code.

![image-20210401002532419](../../../resources/image-20210401002532419.png)