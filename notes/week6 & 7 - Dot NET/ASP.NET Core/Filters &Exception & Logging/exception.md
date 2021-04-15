https://docs.microsoft.com/en-us/dotnet/standard/exceptions/

​							Exception

/																\

Known exception			        unknown exception

bad request								fatal error

not follow the rule					sql server is down

out of the range						





**System.Exception**

![图14.1 –一个工具提示，显示File.ReadAllText方法的异常 ](https://learning.oreilly.com/library/view/learn-c-programming/9781789805864/image/Figure_14.1_B12346.jpg)





### Questions

##### whether a method should return a failure code or throw an exception?

![image-20210410183428652](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210410183428652.png)



##### Why we could see this page?

![image-20210410221538109](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210410221538109.png)

.NET Core built-in exception handler

if env.dev => in Startup file

![image-20210410221840356](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210410221840356.png)

else => HomeController => in shared folder, Error

![image-20210410221942657](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210410221942657.png)



### Common exception types

| Exceptions                         | Explain                                                      |
| ---------------------------------- | ------------------------------------------------------------ |
| System.NullReferenceException      | Very common exception related to calling a method on a null object reference |
| System.IndexOutOfRangeException    | Occurs attempting to access an array element that does not exist |
| System.IO.IOException              | Used around many file I/O type operations                    |
| System.Net.WebException            | Commonly thrown around any errors performing HTTP calls      |
| System.Data.SqlClient.SqlException | Various types of SQL Server exceptions                       |
| System.StackOverflowException      | If a method calls itself recursively, you may get this exception |
| System.OutOfMemoryException        | If your app runs out of memory                               |
| System.InvalidCastException        | If you try to cast an object to a type that it can’t be cast to |
| System.InvalidOperationException   | System.InvalidOperationException                             |
| System.ObjectDisposedException     | Trying to use an object that has already been disposed       |



### Log every exception

##### where to log

- exception

##### what to log, how much information

- datetime
- user
- data
- page url, which controller&action
- stacktrace
- message

##### format

- plain json file
- db
  - do not immediately to db. store it in text/json file, then have a background jobs that read the log and save to db

send a notification to Dev/prod support team, email to devteam@antra.com



### Where to catch exceptions

generally, centralized location where you can catch the exception, and use that to log exception and send out email

2 ways:

##### 1. custom exception filters

example: Filters => MovieShopHeaderFilter

##### 2. custom exception middleware   -- .NET Core



### Exception filters

can be configured to run globally, on a per-controller basis or even on a per-action basis.

filters = pieces of code(custom class) that can be executed before an action method or after an action method.

`[Authorize]` is one of the built-in filter. We can also customize filters.



typically put **filters folder** under MVC, but if we want to reuse it in the API and MVC, then better to put that under infrastructure



Exception filters won’t let you catch model binding exceptions, route exceptions, and exceptions that would generate other than an HTTP 500 status code, most notably HTTP 404 but also authorization exceptions such as HTTP 401 and HTTP 403.



### error monitoring tool





### Reading materials

https://www.mikesdotnetting.com/article/130/cheat-sheet-net-framework-exceptions

https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/exceptions

https://github.com/dmosyan/C-sharp-Cheatsheet#Complete-List-Of-Exception-Class-In-C#