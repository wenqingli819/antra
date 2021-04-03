# MovieShop Code Structure



![image-20210402211137989](../../../../../resources/image-20210402211137989.png)



## MVC![image-20210401195301699](../../../../../resources/image-20210401195301699.png)

​		controllers

​				HomeController.cs

​				MoviesController.cs

​		models

​		views

​				home

​				movies

​						index.cshtml

​						![image-20210330232818069](../../../../../resources/image-20210330232818069.png)





## ApplicationCore

![image-20210401195349161](../../../../../resources/image-20210401195349161.png)

#### 	models

​			request

​			response

​					`MovieCardResponseModel.cs`

#### 	entities

#### 	repositoryInterfaces

#### 	serviceInterfaces



## Infrastructure

![image-20210401195504876](../../../../../resources/image-20210401195504876.png)

​		Data

​				`MovieShopDbContext.cs`

```c#
DbContext
DbSet<Genre> Genres { get; set; }
...
```

​		repositories
​				`MovieRepository.cs`

​		services

​				`MovieService.cs`

## API

![image-20210401195516330](../../../../../resources/image-20210401195516330.png)





--------------

### ER Diagram



Favorite table

![image-20210402101749527](../../../../../resources/image-20210402101749527.png)

id	mid	uid

1       1        1

2        1        1



mid	uid

1      	 1   

1        	2





![image-20210402001144943](../../../../../resources/image-20210402001144943.png)

combination of userID and PurchaseID should be unique

userID      PurchaseID 

1				1

1				2

2				1

2				2



## packages

MVC

![image-20210402211310920](../../../../../resources/image-20210402211310920.png)

![image-20210402211442093](../../../../../resources/image-20210402211442093.png)

![image-20210402211450093](../../../../../resources/image-20210402211450093.png)

![image-20210402211457626](../../../../../resources/image-20210402211457626.png)