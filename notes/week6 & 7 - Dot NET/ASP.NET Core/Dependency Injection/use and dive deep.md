DI is a first-class citizen where services are added and configured in an [IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection). 

The [IHost](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihost) interface exposes the [IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/system.iserviceprovider) instance, which acts as a container of all the registered services.

