When to use IEnumerable<Emloyee>, and when to use  IQueryable <Emloyee>?  Can I just use `var`?

Yes.



If everyone can write method for a type no matter the person own the code or not, if it is that flexible, will we end up with thousands of methods in one class?

http://firstclassthoughts.co.uk/Articles/Design/LINQExtensionMethodsBestPractices.html



When to use `into`? 

-  `select` keyword, follow by `into` 

  ```c#
  var teenAgerStudents = from s in studentList
      where s.age > 12 && s.age < 20
      select s
          into teenStudents
          where teenStudents.StudentName.StartsWith("B")
          select teenStudents;
  ```

  

- When used with the `join` keyword, `into` will add a variable containing all of the matching items from the join. (This is called a [Group Join](http://msdn.microsoft.com/en-us/library/bb311040.aspx))

  ```c#
  Dim groupQuery = From s In studentList
                   Group By s.Age Into Group
  ```

  

When to use `let`?

 It projects a new range variable, allows re-use of the expression and makes the query more readable.

```c#
var lowercaseStudentNames = from s in studentList
                            let lowercaseStudentName = s.StudentName.ToLower()
                                where lowercaseStudentName.StartsWith("r")
                                select lowercaseStudentName;

foreach (var name in lowercaseStudentNames){
  Console.WriteLine(name);
}
```



When and why use underscores for variables in C#? e.g., _emps.

It is a prefix for private **variable**.

