razor view

![image-20210331200155379](../../../../resources/image-20210331200155379.png)



### View Rules

- Action method name in controller = view name

- every view has only one model

- View

  - start with `ViewStart` => Layout  //header, footer

    ![image-20210403132800120](../../../../resources/image-20210403132800120.png) @RenderBody is the placeholder for the particular view you want to show

- ### PartialView 

  `_xx`

  for simple UI senarios, static 

  it is a view inside of another view

  responsible for render the data for the parent view 

  ==remember==

  - we don't directly call them, gonna use that inside of another view

  ##### example

  _MovieCard

  properties: movieid, title, posterurl

  

- ### [ASP.NET Core MVC Components](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-5.0)

  ​	for more complex UI and data driven scenarios

  ​	examples:
  - Dynamic navigation menus
  - Tag cloud (where it queries the database)
  - Login panel
  - Shopping cart
  - Recently published articles
  - Sidebar content on a typical blog
  - A login panel that would be rendered on every page and show either the links to log out or log in, depending on the log in state of the user





![image-20210401125146679](../../../../resources/image-20210401125146679.png)

put reusable UI components or partial view







![image-20210403141503933](../../../../resources/image-20210403141503933.png)

1. create a ViewComponent classs : ViewComponent

   similar to controllers

   DI, constructor

![image-20210403143903809](../../../../resources/image-20210403143903809.png)

**THINK**: Who should call this method?

(header) Layout

![image-20210403144615564](../../../../resources/image-20210403144615564.png)