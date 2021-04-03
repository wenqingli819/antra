razor view

![image-20210331200155379](../../../../resources/image-20210331200155379.png)



### View Rules

- every view has only one model

- View

  - start with `ViewStart` => Layout  //header, footer

    ![image-20210403132800120](../../../../resources/image-20210403132800120.png) @RenderBody is the placeholder for the particular view you want to show

- PartialView => reusable view

  `_xx`

  ​	reuse any UI view in another

  ​	for simple UI senarios, static 

- [ASP.NET Core MVC Components](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-5.0)

  ​	more complex UI and data driven scenarios

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

