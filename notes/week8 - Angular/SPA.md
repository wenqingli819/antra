# SPA

| traditional web app | single page application |
| ------------------- | ----------------------- |
| ASP.NET MVC         | Angular, React, Vue     |

`XMLHTTPRequest` objects are used to interact with servers.

retrieve data from a URL without having to do a full page refresh. This enables a Web page to update just part of a page without disrupting what the user is doing.



Bundle all your view HTML and send it to browser when you request first time



### What is SPA?

##### old time:

browser                                                       web server

​					 --send request -->  

​					<-- (always) get a new page back --



##### SPA:

browser                                                       web server

first time come to the website, browser downloads a little program in js and run it

you don't need to reload the page anymore

it will communicate to the server over the internet and get the information you need without reloading the page.

  

saves bandwidth 

Gmail is one of the leaders of SPA approach.



In a good SPA, both content and resources – HTML, JavaScript, CSS, and so on – are either retrieved within a single page load or are dynamically fetched when needed. This also means that the page doesn't reload or refresh; it just changes and adapts in response to user actions, performing the required server-side calls behind the scenes.



### Advantages of SPA:

- No server side roundtrip

  no need to retrieve a full HTML page

- Effective routing

  server-side routing, client-side routing

- Performance and flexibility

  usually transfers all of its UI to the client

  -  good for network performance as increasing client-side rendering and offline processing reduces the UI impact over the network. 
  - developer will be able to completely rewrite the application front-end with little or no impact on the server, aside from a few of the static resource files.



### Disadvantage using SPA:

1. **initial load will be slow, we can use lazy loading**

   Guards
   instead of using all the pages,
   we modularized the application

   


