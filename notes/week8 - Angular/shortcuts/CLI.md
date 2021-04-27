# Angular CLI

[recursively unzip](https://stackoverflow.com/questions/107995/how-do-you-recursively-unzip-archives-in-a-directory-and-its-subdirectories-from)

```
find . -name "*.zip" | while read filename; do unzip -o -d "`dirname "$filename"`" "$filename"; done;
```



[Angular CLI](https://github.com/angular/angular-cli)

​	`ng new ProjectName`

​	![image-20210423135621080](../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210423135621080.png)

`npm i bootstrap --save`

`ng add @ng-bootstrap/ng-bootstrap`





​	• `ng g c my-new-component`
​	• `ng g c books/bookform` --flat : flat add component in existing folder without creating specific folder.
​	• `ng g cl my-new-class`
​	• `ng g d my-new-directive`: add a directive to your application
​	• `ng g e my-new-enum`
​	• `ng g m my-new-module`
​	• `ng g p my-new-pipe`
​	• `ng g s my-new-service`

ng g s core/services/room

​	• `ng g c --skipTests=true component-name`
​	• `ng g m subfolder/modulename --routing --flat`  New Module with routing 



`npm i `          // npm install

`ng serve`

`ng serve --port 4201`