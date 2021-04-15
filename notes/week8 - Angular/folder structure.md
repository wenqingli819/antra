#### e2e

**end to end test** to the application. automated tests that simulate a real user.

#### node_modules

store all 3rd party libs 

we don't deploy this folder to server

#### src

- app

  - module
  - component

- assets

  store static files: text file, images, icons

- environments

  configuration settings for different environments

  - prod
  - dev

```c#
// inside src

favicon.ico     //icon displayed in the browser
    
index.html     // no reference to css, script. these will be dynamically inserted into this page
    
main.ts     // boostrap the main module (AppModule) of the application 

polyfills.ts  //import some scripts that are required for running angular. fill the gap between js that angular needs and the features supported by the current browsers
    
styles.css //gloval styles for the application
    
```



```c#
// outside src

.editorconfig            //if work in a team, make sure same settings in here

package.json
    
```

npm install pacakge.json



![image-20210414180507563](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210414180507563.png)

webpack: Compiling...

==webpack== is a build automation tool that gets all our scripts and stylesheets, combines them in a bundle , and then minify the bundle  for optimization.

![image-20210414181844181](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210414181844181.png)

hot module replacement -  webpack automatically refresh the browser when source code changes

![image-20210414181954191](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210414181954191.png)

webpack automatically inject these scripts into index.html at runtime

![image-20210414180429664](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210414180429664.png)