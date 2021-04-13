action result --> action invoker system component to produce the actual response

**senario1:** action result = *ViewResult* object

view engine (default - Razor view engine) is kicked off to produce some HTML markup. 

view engine consume templates from a given folder structure and the internal markup language(Razor) they understand and parse on the way to generating HTML.



### ELEMENTS OF THE SYNTAX

​													Razor file

​				/																				\

HTML expressions  														@	code expressions



### predefined properties on the base *RazorPage* class

- HTML helper
  - not been using much. Except the *CheckBox* helper.
- tag helper, preferred! 

### Some Code Examples

```c#
 <table>
        <thead>
           <th>City</th>
           <th>Country</th>
           <th>Ever been there?</th>
        </thead>
    @foreach (var city in Model.Cities) {
       <tr>
          <td>@city.Name</td>
          <td>@city.Country</td>
          <td>@city.Visited ?"Yes" :"No"</td>
       </tr>
    }
    </table>
```

```c#
<p> @("Welcome, " + user) </p>
```

