### What is Angular?

- component-based framework
- A collection of well-integrated libraries that cover a wide variety of features, including **routing**, **forms management**, **client-server communication**, and more
- A suite of developer tools to help you develop, build, test, and update your code

Why Angular?

- we can use JavaScript/jQuery too



### AngularJS vs Angular

| AngularJS      | Angular2              | Angular4                                                     |
| -------------- | --------------------- | ------------------------------------------------------------ |
| 2010           | 2016                  |                                                              |
| overly complex | rewrite to typescript | ![image-20210415002918022](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210415002918022.png) |



### Learning Map

![image-20210416142931608](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416142931608.png)



`npm install --save bootstrap@4`

```typescript
// angular.json
"styles": [      "node_modules/bootstrap/dist/css/bootstrap.min.css",
 "src/styles.css"
            ],
```

`ng serve`



### How an Angular App gets Loaded and Started?

- index.html served by the server

- Angular is a framework which allows you to create single page application.     => index.html



angular gets started at this main.ts file. In here, we bootstrap an Angular application

![image-20210416145008234](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416145008234.png)

and we pass the module as argument

![image-20210416145042253](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416145042253.png)

Angular will analyzes the `app.component` when it starts, and it knows the `app-root` selector

![image-20210416144624694](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416144624694.png)

now Angular can handle the app-root in index.html

![image-20210416144451860](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416144451860.png)

and the app.component.html has some html code

![image-20210416144726608](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416144726608.png)

![image-20210416144544872](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416144544872.png)

`ng serve` rebuilt our project, JavaScript bundles and automatically add the right imports in the index.html file.

![image-20210416144759280](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210416144759280.png)





[when-to-use-class-or-interface-in-angular-project](https://stackoverflow.com/questions/54356711/when-to-use-class-or-interface-in-angular-project)