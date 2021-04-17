https://angular.io/guide/glossary



### XMLHttpRequest   XMR

`XMLHTTPRequest` to get data from API. retrieve data from a URL without having to do a full page refresh. 

This enables a Web page to do partial update without disrupting what the user is doing.

- JQuery.Ajax

- Angular => HttpClient    **
- ...

Components can use HttpClient to talk with API to get JSON data

Services, DI, HttpClient to talk to API

will return models to Components so that can be used to create views

https://developer.mozilla.org/en-US/docs/Glossary/XHR_(XMLHttpRequest)



**fetch APIs** VS **XMLHttpRequest**?

fetch is promise based, async await, 

![image-20210413223725631](../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210413223725631.png)

​	<img src="../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210413223907681.png" alt="image-20210413223907681" style="zoom:50%;" /> not successful

<img src="../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210413224130229.png" alt="image-20210413224130229" style="zoom:50%;" /> post 





### CORS

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

https://stackoverflow.com/questions/43985620/asp-net-core-use-multiple-cors-policies





### localStorage vs SessionStorage

The localStorage and sessionStorage properties allow to save key/value pairs in a web browser.

|         | local storage                                            | session storage                                              |
| ------- | -------------------------------------------------------- | ------------------------------------------------------------ |
| explain | more commonly used. until you manually delete            | until the tab closed. <br>A page session lasts as long as the web browser is open and survives over the page refresh.<br>if open multiple tabs with the same URL, the web browser creates a separate `sessionStorage` for each tab or window<br>`sessionStorage` data is tied to a server session, it’s only available when a page is requested from a server. The `sessionStorage` isn’t available when the page runs locally without a server. |
|         | Shared between all tabs and windows with the same origin | Visible within a browser tab, including iframes from the same origin |
| example | store token                                              |                                                              |

##### We already have cookies. Why additional objects?

- Unlike cookies, web storage objects are not sent to server with each request. Because of that, we can store much more. Most browsers allow at least 2 megabytes of data (or more) and have settings to configure that.
- Also unlike cookies, the server can’t manipulate storage objects via HTTP headers. Everything’s done in JavaScript.
- The storage is **bound to the origin** (domain/protocol/port triplet). That is, different protocols or subdomains infer different storage objects, they can’t access data from each other.

Both storage objects provide same methods and properties:

- `setItem(key, value)` – store key/value pair.
- `getItem(key)` – get the value by key.
- `removeItem(key)` – remove the key with its value.
- `clear()` – delete everything.
- `key(index)` – get the key on a given position.
- `length` – the number of stored items.

reference:

https://javascript.info/localstorage



### DOM

##### What is Document Object Model?

- a programming **API for** HTML and XML **documents**.
- It defines the logical structure of documents and the way a document is accessed and manipulated.
- Anything found in an HTML or XML document can be accessed, changed, deleted, or added using the DOM

##### How is it different from HTML?

> When a web page is loaded, the browser creates a Document Object Model of the page, which is an object oriented representation of an HTML document, that acts as an interface between JavaScript and the document itself and allows the creation of dynamic web pages.



HTML 

```html
      <TABLE>
      <ROWS> 
      <TR> 
      <TD>Shady Grove</TD>
      <TD>Aeolian</TD> 
      </TR> 
      <TR>
      <TD>Over the River, Charlie</TD>
      <TD>Dorian</TD> 
      </TR> 
      </ROWS>
      </TABLE>
```

DOM![DOM representation of the example table](https://www.w3.org/TR/WD-DOM/table.gif)

the nodes in the above diagram do not represent a data structure, they represent objects, which have functions and identity (attributes).



##### DOM consists two parts 

1. **DOM Core** 

   functionality used for XML documents

   also serves as the basis for DOM HTML. 

2. **DOM HTML**

    The Level 1 DOM HTML specification defines additional functionality needed for HTML documents.



##### difference between html attributes and properties

| HTML                                       | DOM                                                          |
| ------------------------------------------ | ------------------------------------------------------------ |
| define *attributes* on your HTML elements. | Then, once the browser parses your code, a corresponding DOM node will be created. This node is an object, and therefore it has *properties*. |

Example:

```html
<input type="text" value="Name:">
```

This HTML element has 2 attributes (`type` and `value`).

Once the browser parses this code, a [HTMLInputElement](https://developer.mozilla.org/en-US/docs/Web/API/HTMLInputElement) object will be created, and this object will contain dozens of properties like: accept, accessKey, align, alt, attributes, autofocus, baseURI, checked, childElementCount, childNodes, children, classList, className, clientHeight, etc.





##### What is XML？

Html is a subset of XML. People used to do xml transforms and XPath against html, but the DOM API and frameworks like Angular make all of that completely unnecessary

![JAXP_DOM_node_interfaces_inheritance_hierarchy](https://www.codevoila.com/cvuploads/images/201608/JAXP_DOM_node_interfaces_inheritance_hierarchy.png)



https://developer.mozilla.org/en-US/docs/Web/API/Document_Object_Model/Introduction

https://www.w3.org/TR/WD-DOM/introduction.html