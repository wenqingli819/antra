

![image-20210402175803422](../../../../../resources/image-20210402175803422.png)

Important docs:

[validation attributes](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-5.0)  //for MVC model

[tag helpers](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-5.0)  // for view

### Data Validation

- validation attributes

  - for ef model // persistent ![image-20210402180656347](../../../../../resources/image-20210402180656347.png)

  - for view![image-20210402181150634](../../../../../resources/image-20210402181150634.png)

  - for business objects (vs rules for EF models)

    use `automapper` to simplify the code - map the ef model into business model

- built-in validation attributes

  ![image-20210402180345958](../../../../../resources/image-20210402180345958.png) 
  
- OR Fluent API

- validate using `DbContext` API for changed objects




more

https://learning.oreilly.com/videos/mastering-entity-framework/9781788398527/9781788398527-video3_2