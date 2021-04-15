# Logging

two categories:

- Logging for auditing or analytics reasons, to trace when events have occurred

  examples

  - keep a record of every time a user logs in
  - keep track of how many times a particular API method is called.
  - Logging is an easy way to record the behavior of your app, by writing a message to the log every time an interesting event occurs.

- Logging errors, or to provide a breadcrumb trail of events when an error does occur



![img](https://learning.oreilly.com/library/view/aspnet-core-in/9781617294617/17fig01_alt.jpg)





###  The ASP.NET Core logging abstractions

Microsoft built-in

- **ILogger**

  This is the interface you’ll interact with in your code. It has a Log() method, which is used to write a log message.

- **ILoggerProvider**

  This is used to create a custom instance of an ILogger, depending on the provider. A console ILoggerProvider would create an ILogger that writes to the console, whereas a file ILoggerProvider would create an ILogger that writes to a file.

- **ILoggerFactory**

  The glue between the ILoggerProvider instances and the ILogger you use in your code. You register ILoggerProvider instances with an ILoggerFactory and call CreateLogger() on the ILoggerFactory when you need an ILogger. The factory creates an ILogger that wraps each of the providers, so when you call the Log() method, the log is written to every provider.

![img](https://learning.oreilly.com/library/view/aspnet-core-in/9781617294617/17fig03_alt.jpg)



### ADDING LOG MESSAGES TO YOUR APPLICATION

#### 1. create an instance of ILogger and add logging the application

![image-20210410194057705](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210410194057705.png)

or

```c#
$"Loaded {models.Count} recipes"
```

But I recommend always using placeholders, as they provide additional information for the logger that can be used for structured logging.

![img](https://learning.oreilly.com/library/view/aspnet-core-in/9781617294617/17fig04_alt.jpg)



#### 2. properties that make up a logging record

The exact presentation of the message will vary depending on where the log is written, but each log record includes up to ***six common elements***:

1. **Log level**

2. **Event category**

3. **Message**

   content of the log message.

   - can be a static string
   - can contain placeholders for variables

4. **Parameters**

   If the message contains placeholders, then they’re associated with the provided parameters.

5. **Exception**

   If an exception occurs, you can pass the exception object to the logging function along with the message and other parameters.

6. **EventId**

   default 0. can specify, EventId of 1000, 1001...

   

#### 3. Log level

when everything is normal:

​	`Information ` level is ok

​		when an exception is thrown:

​			`warning` or `error` level log

![image-20210411011838724](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210411011838724.png)

top down. 

NameSpace: log level

Information = Information, warming, error, critical, none



![img](https://learning.oreilly.com/library/view/aspnet-core-in/9781617294617/17fig05_alt.jpg)

[doc](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-5.0#log-level)



#### 4. Log category: which component created the log

![img](https://learning.oreilly.com/library/view/aspnet-core-in/9781617294617/17fig06_alt.jpg)

achieved this by injecting ILogger<T> into RecipeController; the generic parameter T is used to set it to the category of the ILogger.

```c#
...
private readonly ILogger _log;                             
public RecipeController(RecipeService service,
                        ILogger<RecipeController> log)                   
{
    _service = service;
    _log = log;                                            
}
...
```



#### 5. log *provider*

- ***Console provider\*—** Writes messages to the console, as you’ve already seen.
- ***Debug provider\*—** Writes messages to the debug window when you’re debugging an app in Visual Studio or Visual Studio Code, for example.
- ***EventLog provider\*—** Writes messages to the Windows Event Log. Only available when targeting .NET Framework, not .NET Core, as it requires Windows-specific APIs.
- ***EventSource provider\*—** Writes messages using Event Tracing for Windows (ETW). Available in .NET Core, but only creates logs when running on Windows.
- ***Azure App Service provider\*—** Writes messages to text files or blob storage if you’re running your app in Microsoft’s Azure cloud service. The provider is automatically added when you run an ASP.NET Core 2.0 app in Azure.



2 options to customize logging for your app:

- Use WebHostBuilder instead of CreateDefaultBuilder and configure it explicitly.
- Add an additional ConfigureLogging call after CreateDefaultBuilder.



![image-20210411010655508](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210411010655508.png)



### using logging in any class

https://stackoverflow.com/questions/39031585/how-do-i-log-from-other-classes-than-the-controller-in-asp-net-core





### popular .NET logging frameworks

- NLog

- log4net

- Serilog

  - you can easily integrate with Serilog while still using the ILogger abstractions in your application code.
  - more control over your logs, such as the file format 
  - can write to multiple locations
    - Elasticsearch cluster
    - db
    - ....
  -  https://github.com/serilog/serilog/wiki/Provided-Sinks. 

  ![img](https://learning.oreilly.com/library/view/aspnet-core-in/9781617294617/17fig08_alt.jpg)



​	steps:

 https://github.com/serilog/serilog/wiki/Configuration-Basics

> **1**. Add the required Serilog NuGet packages to the solution.
>
> ```
> dotnet add package Serilog.AspNetCore
> dotnet add package Serilog.Sinks.Console
> ```

> **2**. Create a Serilog logger and configure it with the required sinks.

> **3**. Call UseSerilog() on WebHostBuilder to replace the default ILoggerFactory implementation with SerilogLoggerFactory. This configures the Serilog provider automatically and hooks up the already-configured Serilog logger.



### Source

https://learning.oreilly.com/library/view/aspnet-core-in/9781617294617/kindle_split_028.html