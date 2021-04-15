[Serilog.net](https://serilog.net/)

```c#
$ dotnet add package Serilog.Sinks.Console
$ dotnet add package Serilog.Sinks.File
```

![image-20210411161620908](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210411161620908.png)

replace the default `ILoggerFactory` with a custom factory that contains a single logging provider, `SerilogLoggerProvider`

This configuration is a bit of a departure from the standard ASP.NET Core logging setup, but it prevents Serilog’s features from conflicting with equivalent features of the default LoggerFactory, such as filtering

![img](https://learning.oreilly.com/library/view/aspnet-core-in/9781617294617/17fig08_alt.jpg)



Logging levels

From low to high, these are 

Verbose , 

Debug , 

Information , 

*Warning* , 

Error,

*Fatal* .







logging switcher?



















https://medium.com/@z2hteam/serilog-configuration-in-net-core-project-9179645cc729

https://benfoster.io/blog/serilog-best-practices/

https://blog.datalust.co/smart-logging-middleware-for-asp-net-core/