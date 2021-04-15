# Model State	

ModelState refers to a set of name and value pairs submitted to the server during a post. This allows you to save the value submitted to the server and check for errors associated with each value.  

 **Model state** represents errors that come from two subsystems

/															\

| 1. model binding                   | 2. model validation                                          |
| ---------------------------------- | ------------------------------------------------------------ |
| data conversion errors.            | data doesn't conform to business rules.                      |
| "x" is entered in an integer field | 0 is entered in a field that expects a rating between 1 and 5. |

They occur before the execution of a controller action or a Razor Pages handler method.

Web API controllers don't have to check `ModelState.IsValid` if they have the `[ApiController]` attribute. In that case, an automatic HTTP 400 response containing error details is returned when model state is invalid.







ASP.NET MVC Framework validates any data passed to the controller action that is executing, It populates a **`ModelState`** object with any validation failures that it finds and passes that object to the controller.