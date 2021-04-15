# Cookies

### What are Cookies?

- HTTP is a stateless protocol. 
- But for a commercial website, it is required to maintain session information among different pages. 
- In many situations, using cookies is the most efficient method of remembering and tracking preferences, purchases, commissions, and other information required for better visitor experience or site statistics.
- Don't store sensitive data in cookie!!



### How it works?

Your server sends some data to the visitor's browser in the form of a cookie. 

The browser may accept the cookie. If it does, it is stored as a plain text record on the visitor's hard drive. 

Now, when the visitor arrives at another page on your site, the browser sends the same cookie to the server for retrieval. Once retrieved, your server knows/remembers what was stored earlier.

Cookies are a plain text data record of 5 variable-length fields −

**Expires** − The date the cookie will expire. If this is blank, the cookie will expire when the visitor quits the browser.

**Domain** − The domain name of your site.

**Path** − The path to the directory or web page that set the cookie. This may be blank if you want to retrieve the cookie from any directory or page.

**Secure** − If this field contains the word "secure", then the cookie may only be retrieved with a secure server. If this field is blank, no such restriction exists.

**Name=Value** − Cookies are set and retrieved in the form of key-value pairs



### CRUD cookie in JavaScript

#### Set Cookie

```javascript
document.cookie = "cookiename=cookievalue"
```

##### Set Cookie Example

![image-20210310003522275](../../../../resources/image-20210310003522275.png)

**Note** − Cookie values may not include semicolons, commas, or whitespace. For this reason, you may want to use the JavaScript **escape()** function to encode the value before storing it in the cookie. If you do this, you will also have to use the corresponding **unescape****()** function when you read the cookie value.



#### Remove Cookie on a specific time

```javascript
document.cookie = "cookiename=cookievalue; expires= Thu, 21 Aug 2014 20:00:00 UTC"
```

![image-20210310003752250](../../../../resources/image-20210310003752250.png)



#### get Cookie

```javascript
var x =  document.cookie
```

![image-20210310003713168](../../../../resources/image-20210310003713168.png)



#### Delete Cookie

 set the value of the cookie to empty and set the value of expires to a passed date.

```javascript
document.cookie = "cookiename= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
```

![image-20210310003824390](../../../../resources/image-20210310003824390.png)



#### encode and decode cookie

The `btoa()` method encodes a string in base-64.

```javascript
function createCookie() {

    document.cookie = "uname=" + btoa(document.querySelector("#txtUsername").value);
  /*  document.cookie = "password=daniel"
    document.cookie = "uid=87xjw"*/

    
}
function showCookie() {

    alert(atob(document.cookie.split("=")[1]))
}
```

