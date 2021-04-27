```c#
namespace Microsoft.AspNetCore.Mvc
{
    /// <summary>
    /// A base class for an MVC controller with view support.
    /// </summary>
    public abstract class Controller : ControllerBase, IActionFilter, IAsyncActionFilter, IDisposable
    {
        ..
    }
```

# Controller

can return 

- ViewResult
  - View()
  - View(viewName)
  - View(model)
  - View(viewName, model)
- PartialViewResult
  - PartialView(viewName)
  - PartialView(model)
  -  PartialView(viewName, model)
- ViewComponentResult (????????)
  - ViewComponent(componentName)
  -  ViewComponent(componentType)
  - ViewComponent(componentName, arguments)
  - ViewComponent(componentType, arguments)

- JsonResult
  - Json(data)
  - Json(data, serilizerSettings)



pass data from controller to view:								

tempData				

viewBag                       

viewData  

data model               





abstract class **Controller**  // with view support

```
AccountController : Controller
```



abstract class **ControllerBase**  // without view support, use this in API

```c#
GenresController : ControllerBase
```

