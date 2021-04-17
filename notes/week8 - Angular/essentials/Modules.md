# Angular Modules

a container for a group of related components

The purpose of a NgModule is to declare each thing you create in Angular and group them together, like packages in Java or namespaces in C#.

## AppModule

Every Angular App have at least one root module which we call `AppModule`, to bootstrap the application.

Typescript needs us to register components/ modules in here. 

When Angular runs, it knows that these components and modules are parts of the application.

![img](https://miro.medium.com/max/1197/1*4gxQIsHfJLFatrbcon2RwA.png)



==Note==

when creating a new component, you need to **import** it to the corresponding module file and add the component to the **declarations**!



### Example modules 

Courses, Messaging, Instructor, Admin

Forms, ReactiveForms, Http, Router

feature modules



Angular's modularity system called` NgModules`.

They can contain components, service providers, and other code files whose scope is defined by the containing NgModule.

