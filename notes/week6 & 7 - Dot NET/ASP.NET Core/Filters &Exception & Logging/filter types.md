[filters doc](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-5.0)

### What are filters?

ASP.NET MVC Filter is a custom class where you can write custom logic to execute before or after an action method executes in a declarative or programmatic way. 

Custom filters can be created to handle cross-cutting concerns. Examples of cross-cutting concerns include **error handling**, **caching**, **configuration**, **authorization**, and **logging**.

Filters can be applied to an action method or controller

- Declarative means by applying a filter attribute to an action method or controller class 
- programmatic means by implementing a corresponding interface.



### Filter types

| **Filter Type**       | **Description**                                              | **Built-in Filter**         | **Interface**        |
| --------------------- | ------------------------------------------------------------ | --------------------------- | -------------------- |
| Authorization filters | Performs authentication and authorizes before executing an action method. | [Authorize], [RequireHttps] | IAuthorizationFilter |
| Action filters        | Performs some operation before and after an action method executes. |                             | IActionFilter        |
| Result filters        | Performs some operation before or after the execution of the view. | [OutputCache]               | IResultFilter        |
| Exception filters     | Performs some operation if there is an unhandled exception thrown during the execution of the ASP.NET MVC pipeline. | [HandleError]               | IExceptionFilt       |

Filter attributes:

- [ActionFilterAttribute](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.filters.actionfilterattribute)
- [ExceptionFilterAttribute](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.filters.exceptionfilterattribute)
- [ResultFilterAttribute](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.filters.resultfilterattribute)
- [FormatFilterAttribute](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.formatfilterattribute)
- [ServiceFilterAttribute](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.servicefilterattribute)
- [TypeFilterAttribute](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.typefilterattribute)



### Filters can be applied at three levels

- Global Level for all controllers, actions, and Razor Pages 

  ```c#
  services.AddControllersWithViews(options =>
  {
                               options.Filters.Add(typeof(MySampleActionFilter));
  });
  ```

  

- Controller Level

- Action Method Filters



Write custom filter class

1. filter folder -> xxFilter

   ![image-20210411002808538](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210411002808538.png)

2. register in Startup.cs![image-20210411002710856](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210411002710856.png)

3. check 

   ![image-20210411003717306](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210411003717306.png)





in old version, used to have `Filters.Config.cs`  to register. Now register everything in `Startup.cs`

