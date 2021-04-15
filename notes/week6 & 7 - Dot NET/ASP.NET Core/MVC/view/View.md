razor view

![image-20210331200155379](../../../../../resources/image-20210331200155379.png)



### View Rules

- Action method name in controller = view name

- every view has only one model

- View

  - start with `ViewStart` => Layout  //header, footer

    ![image-20210403132800120](../../../../../resources/image-20210403132800120.png) @RenderBody is the placeholder for the particular view you want to show

  

  ### PartialView 

  a reusable smaller view, built around a template and inject some data.

  `_xx`

  for simple UI senarios, static 

  it is a view inside of another view

  responsible for render the data for the parent view 

  ==remember==

  - we don't directly call them, gonna use that inside of another view

  ##### Example Usage:

  - It is excellent to isolate banners and menus, maybe some tables and sidebars, but not autonomous web parts. 

  - breaking up complex views

    Large forms, especially multi-stepped forms. **tab-based forms**

    https://learning.oreilly.com/library/view/programming-aspnet-core/9781509304448/ch06.xhtml#ch06

  - 

  ##### example

  _MovieCard

  properties: movieid, title, posterurl

  

  in layout header section, `loginInfoPartial`

  

  ##### Passing Data to Partial Views

  ```c#
  @Html.Partial("pv_Grid")
  ```

  

  ### Component

  ##### What is it

  “Composition UI” pattern

  for more complex UI and data driven scenarios

   self-contained components that include both logic and view.

  Within the view component class, you may have database or service references and might ask the system to inject dependencies for you.

  

  ##### Writing a View Component

  In the context of a view, you reference view components via a C# block and pass them any input data that is required. Internally, the view component will run its own logic, process the data you passed in, and return a view ready for rendering.

  ```c#
  
  public class GenresViewComponent : ViewComponent
      {
          private readonly IGenreService _genreService;
  
          public GenresViewComponent(IGenreService genreService)
          {
              _genreService = genreService;
          }
          public async Task<IViewComponentResult> InvokeAsync()
          {
              var genres = await _genreService.GetAllGenres();//get data
              return View(genres);   //will look for Default view
          }
      }
  ```

  ##### Connecting Components to Razor Views

  When you return from the *InvokeAsync* method, if no view name is specified then a *default.cshtml* file is assumed.

  ##### Rules

  - *Views/Shared* /Components
  - The view component class can be placed anywhere in the project, but all views used by view components are restricted to a specific location. In particular, you **must have a Components folder that has one child folder for each view component.** 
  - If it makes sense to have multiple view components limited to just one controller, then it is okay to have a *Components* folder under the controller folder in *Views*.

  ##### Invoking a View Component

  ```c#
   @await Component.InvokeAsync("Genres") 
  ```

  another example

  ```c#
  @await Component.InvokeAsync("LatestBookings", new { maxLength = 4 })    // can add any parameter
  -----------------------------------------------    
      
  public IActionResult LatestBookings(int maxNumber)  
  {
      return ViewComponent("LatestBookings", maxNumber);
  }
  ```

  

  ##### examples:

  - Dynamic navigation menus
  - Tag cloud (where it queries the database)
  - Login panel
  - Shopping cart
  - Recently published articles
  - Sidebar content on a typical blog
  - A login panel that would be rendered on every page and show either the links to log out or log in, depending on the log in state of the user

  

![image-20210401125146679](../../../../../resources/image-20210401125146679.png)

put reusable UI components or partial view



![image-20210403141503933](../../../../../resources/image-20210403141503933.png)

1. create a ViewComponent classs : ViewComponent

   similar to controllers

   DI, constructor

![image-20210403143903809](../../../../../resources/image-20210403143903809.png)

**THINK**: Who should call this method?

(header) Layout

![image-20210403144615564](../../../../../resources/image-20210403144615564.png)



Difference between PartialView and Component

 

| PartialView                                                  | Component                                                    |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| a plain Razor template that receives and incorporates data in the template. | receives input parameters, retrieves its data, and then incorporates it in the template. |



### Aggregating Data and UI Templates

aggregation of data coming from different queries.

```c#
public class DashboardViewModel 
{
   public IList<MonthlyRevenue> ByMonth { get; set; }
   public IList<EmployeeOfTheMonth> TopPerformers { get; set; }
   public int PercentageOfPeopleInTheOffice { get; set; }
}
```

```c#
public DashboardViewModel Populate()
{
    var model = new DashboardViewModel();

    // Trigger the monthly revenue query
    model.ByMonth = RetrieveMonthlyRevenues(DateTime.Now.Year);

    // Trigger the top performers query
    model.TopPerformers = RetrieveTopPerformersRevenues(DateTime.Now.Year, DateTime.Now.Month);
    
    // Trigger the occupancy query
    model.PercentageOfPeopleInTheOffice = RetrieveOccupancy(DateTime.Now);
    return model;
}
```

```c#
<div>@Html.Partial("pv_MonthlyRevenues", Model.ByMonth)</div>

<div>@Html.Partial("pv_TopPerformers", Model.TopPerformers)</div>

<div>@Html.Partial("pv_Occupancy", Model.PercentageOfPeopleInTheOffice)</div>
```

Another approach consists of splitting this view into three smaller, independent pieces, each dedicated to one query task. 

```c#
<div>@await Component.InvokeAsync("MonthlyRevenues", DateTime.Now.Year)</div>

<div>@await Component.InvokeAsync("TopPerformers", DateTime.Now)</div>

<div>@await Component.InvokeAsync("Occupancy", DateTime.Now)</div>
```

The controller responsible for rendering the dashboard view does not need to go through the application service, and it can just render the view. Rendering the view will then trigger components.



##### Impact of View Components

 view components are not necessarily a way to speed up the application.

- view component is rendered (and subsequently populated) independently, the database logic might result to be less than optimized. Unless the data lives in distinct and unrelated sources, multiple independent queries might involve multiple connections and multiple commands.





https://www.codecademy.com/learn/asp-net-i/modules/asp-net-razor-syntax/cheatsheet