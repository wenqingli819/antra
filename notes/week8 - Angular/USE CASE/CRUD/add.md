### Add new item

method1(not recommended): use **local references** and **@ViewChild**

![image-20210421000623274](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210421000623274.png)

access local reference using @ViewChild

we want to emit this event which include Ingredient(name, amount) to the parent shopping-list component that manages an array of ingredients.

![image-20210421000143760](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210421000143760.png)

here we use `const` instead of `let` because we are not going to change these values.

![image-20210421000234725](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210421000234725.png)

![image-20210421000318649](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210421000318649.png)