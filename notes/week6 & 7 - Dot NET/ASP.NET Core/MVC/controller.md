

| IActionResult                        | ActionResult                                                 |
| ------------------------------------ | ------------------------------------------------------------ |
| interface                            | abstract class                                               |
| create a custom response as a return | return only predefined ones for returning a View or a resource. |
|                                      |                                                              |

## ActionResult Subtypes

- **ViewResult** - Renders a specifed view to the response stream

  ```c#
  [HttpPost]
  public ViewResult RsvpForm(GuestResponse guestResponse) {
      Repository.AddResponse(guestResponse);
      return View("Thanks", guestResponse); //selects a view called "Thanks" and uses the `GuestResponse` object created by the model binder as the view model.
  }
  ```

  

- **PartialViewResult** - Renders a specifed partial view to the response stream

- **EmptyResult** - An empty response is returned

- **RedirectResult** - Performs an HTTP redirection to a specifed URL

- **RedirectToRouteResult** - Performs an HTTP redirection to a URL that is determined by the routing engine, based on given route data

- **JsonResult** - Serializes a given ViewData object to JSON format

- **JavaScriptResult** - Returns a piece of JavaScript code that can be executed on the client

- **ContentResult** - Writes content to the response stream without requiring a view

- **FileContentResult** - Returns a file to the client

- **FileStreamResult** - Returns a file to the client, which is provided by a Stream

- **FilePathResult** - Returns a file to the client



### Check User Input 

```c#
// check whether user input has satisfied our validation constraint I specified through the attributes on the GuestResponse class
[HttpPost]
public ViewResult RsvpForm(GuestResponse guestResponse) {
    if (ModelState.IsValid) {
        Repository.AddResponse(guestResponse);
        return View("Thanks", guestResponse);
    } else {
        return View();
    }
}
```

