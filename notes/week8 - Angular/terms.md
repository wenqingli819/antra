https://angular.io/guide/glossary

#### XMLHttpRequest

`XMLHTTPRequest` to get data from API. retrieve data from a URL without having to do a full page refresh. 

This enables a Web page to do partial update without disrupting what the user is doing.

- JQuery.Ajax

- Angular => HttpClient    **
- ...

Components can use HttpClient to talk with API to get JSON data

Services, DI, HttpClient to talk to API

will return models to Components so that can be used to create views





**fetch APIs** VS **XMLHttpRequest**?

fetch is promise based, async await, 

![image-20210413223725631](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210413223725631.png)

​	<img src="../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210413223907681.png" alt="image-20210413223907681" style="zoom:50%;" /> not successful

<img src="../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210413224130229.png" alt="image-20210413224130229" style="zoom:50%;" /> post 





#### CORS

cross-origin resource sharing

![image-20210414002751546](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210414002751546.png)

browser implements the same origin policy as a part of the security model.

allow data to be shared from the same url,

blocks data from external url unless certain conditions are met:

- Access-Control-Allow-Origin: foo.com

  ![image-20210414003117799](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210414003117799.png)

  allow * 

- preflight put, patch, delete (non-standard headers)

  ![image-20210414003541248](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210414003541248.png)

  make sure it allows requested methods

  Access-Control-Max-Age: 86400

  

### Decorators

= annotation

Modules, components and services are classes that use *decorators*,  provide metadata that tells Angular how to use them.

- `@Component()`
- `@Directive()`
- `@Pipe()`
- `@Injectable()`
- `@NgModule()`