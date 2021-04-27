### What’s a Lifecycle Hook?

Angular app is basically made of *Components*. Each one of them has a lifecycle which is managed by Angular, meaning that Angular creates it, renders it, creates and renders its children, checks it when its data-bound properties change, and – eventually – destroys it before removing it from the DOM.

 a **lifecycle hook** is an *event* that will trigger whenever a specific situation happens to the *Component* during its lifecycle.



![Component Life Cycle Hook](https://dz2cdn1.dzone.com/storage/temp/9807927-component-lifecycle.jpg)

| lifecycle hook        | run     |                                                              |
| --------------------- | ------- | ------------------------------------------------------------ |
| constructor           | 1       |                                                              |
| ngOnChanges           | n times | get old & new value ![image-20210420135814698](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210420135814698.png) |
| ngOnInit              | 1       |                                                              |
| ngDoCheck             | n times | triggered by events, promises give us back some data         |
| ngAfterContentInit    | 1       |                                                              |
| ngAfterContentChecked | n times |                                                              |
| ngAfterViewInit       |         | you now can access to templates and use their values. before you can't check the value on the DOM because it hasn't been rendered yet |
| ngAfterViewChecked    |         |                                                              |
| ngOnDestroy           |         |                                                              |



#### when and why to use ngOnchanges?

**Use ngOnChanges** to detect changes from a variable decorated by @Input

only changes from the parent component will trigger this function

Also remember that changes from the parent still update the child value even without implementing **ngOnChanges**. ngOnChanges simply adds the benefit of tracking those changes with previous and current value.

##### Scenario:

you write that event to handle any extra work you need to perform when something happens.

for example u wanna change UI based on input property, and lifecycle provides those methods.