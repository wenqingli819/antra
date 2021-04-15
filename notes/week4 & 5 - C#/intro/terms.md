# C# Keywords

## Access Modifiers

| Type                     | Keywords                                                     |
| ------------------------ | ------------------------------------------------------------ |
| Modifier Keywords        | abstract, async, const, event, extern, new, override, partial, readonly, sealed, static, unsafe, virtual, volatile |
| Access Modifier Keywords | public, private, protected, internal                         |
| Statement Keywords       | if, else, switch, case, do, for, foreach, in, while, break, continue, default, goto, return, yield, throw, try, catch, finally, checked, unchecked, fixed, lock |
| Method Parameter Keyword | params, ref, out                                             |
| Access Keywords          | base, this                                                   |
| Namespace Keywords       | using, . operator, :: operator, extern alias                 |
| Literal Keywords         | null, false, true, value, void                               |
| Operator Keywords        | as, await, is, new, sizeof, typeof, stackalloc, checked, unchecked |
| Contextual Keywords      | add, var, dynamic, global, set, value                        |
| Type Keywords            | bool, byte, char, class, decimal, double, enum, float, int, long, sbyte, short, string, struct, uint, ulong, ushort |
| Query Keywords           | from, where, select, group, into, orderby, join, let, in, on, equals, by, ascending, descending |



### `virtual` , `override`

allow the method in the base class to be overridden in a derived class.

```c#
class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }

    public virtual void AddEmployee()
    {
        Console.Write("Enter Id => ");
        Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter FullName => ");
        FullName = Console.ReadLine();

        Console.Write("Enter Mobile => ");
        Mobile = Console.ReadLine();

        Console.Write("Enter Email => ");
        Email = Console.ReadLine();
    }

    public virtual void Print()
    {
        Console.WriteLine("Id = " + Id);
        Console.WriteLine("Name  = " + FullName);
        Console.WriteLine("Mobile = " + Mobile);
        Console.WriteLine("Email = " + Email);
    }
}

class FullTimeEmployee : Employee
{
    public decimal Salary { get; set; }
    public string Benefits { get; set; }

    public override void AddEmployee()
    {
        // base.AddEmployee();
        base.AddEmployee();
        Console.Write("Enter Salary => ");
        Salary = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter Benefits => ");
        Benefits = Console.ReadLine();
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Salary = " + Salary);
        Console.WriteLine("Benefits = " + Benefits);
    }

}

```

| override                      | new                                              |
| ----------------------------- | ------------------------------------------------ |
| extends the base class method | hides the base class method in the derived class |



### `new`

In C#, the new keyword can be used as an operator,a modifier, or a constraint. 

don't use `new` and `override` together, they have mutually exclusive meanings.

- **new Operator** 

  Used to create objects and invoke constructors. 

  

- **new Modifier** 

  Used to hide an inherited member from a base class member. 

  ```c#
  public class BaseC
  {
      public int x;
      public void Invoke() { }
  }
  public class DerivedC : BaseC
  {
  	new public void Invoke() { } //here
  }
  ```

  When used as a declaration modifier, the new keyword explicitly hides a member that is inherited from a base class. When you hide an inherited member, the derived version of the member replaces the base class version.

  Although you can hide members without using the new modifier,you geta compiler warning. If you use new to explicitly hide a member, it suppresses this warning.

  **why we want to hide?**

  If a method is not overriding the derived method then it is hiding it. A hiding method must be declared using the new keyword.
  
  more about `new` modifier: https://stackoverflow.com/questions/22809604/using-the-new-modifier-in-c-sharp
  
  
  
- **new Constraint** 

  Used to restrict types that might be used as arguments for a type parameter in a generic declaration.



### `static`

Static in generally means:

- static data describes information for all objects of a class

- e.g., if we want all accounts share the same interest rate, then storing the interest rate in every account would be a bad idea.

- something cannot be instantiated. You cannot create an object of a static class and cannot access static members using an object.

- C# classes, variables, methods, properties, operators, events, and constructors can be defined as static using the `static` modifier keyword.

  

##### Static Class

- if the class is a static. All the members of it MUST BE static.

- No  instance members or constructors.

- You cannot create an object of the static class; therefore the members of the static class can be accessed directly using a class name like `ClassName.MemberName`.

- Indexers and destructors cannot be static

- `var` cannot be used to define static members. You must specify a type of member explicitly after the `static` keyword.

- Static classes are sealed class and therefore, cannot be inherited.

- A static class remains in memory for the lifetime of the application domain in which your program resides.

  

##### Static Methods

- Static methods can be overloaded but cannot be overridden.
- Static methods cannot access or call non-static variables unless they are explicitly passed as parameters.

| Normal Method                            | Static Method                                                |
| ---------------------------------------- | ------------------------------------------------------------ |
| object.Method()                          | Class.Method()                                               |
|                                          | cannot be instainated. In other words, cannot use the `new` keyword to create a variable of the class type  ❌ |
| can access static and non-static members | cannot access non-static members ❌                           |
|                                          | can call static field/method                                 |



##### Static Constructors

Is a Java static block equivalent to a C# static constructor?

Yes!

- Used to initialize static members
- no access modifiers 
- no Parameter constructors
- The static constructor for a class executes before any instance of the class is created 
- A static constructor cannot be called directly.
- The user has no control on when the static constructor is executed in the program. 



##### Static Fields in Non-static Class

- More common than declare an entire class as static.

- shared across all the instances. So, changes done by one instance would reflect in others.



### `var` 

var mostly used for anonymous type. 

type is signed to the variable at **complier time**

anoymous type cannot modify the value. read only.

### `dynamic`

dynamic type

![image-20210317154051374](/Users/babydeveloper/Library/Application Support/typora-user-images/image-20210317154051374.png)

![image-20210317154122682](/Users/babydeveloper/Library/Application Support/typora-user-images/image-20210317154122682.png)

not compiler type, type is signed to the variable at **runtime**



### `sealed`

"I am not available for any kind of inheritance further. Do not inherit me now."

![img](https://learning.oreilly.com/library/view/learn-c-in/9781787287044/assets/d26bb8ce-ae3b-4a01-99b4-ee656a06ae0c.png)

| abstract class                                               | sealed class                                                 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| abstract method and virtual method can be overridden in derived classes | abstract method and virtual method CANNOT  be overridden in derived classes |



## Types

### Five different user defined types inside C#

1. Class  

   nested class

2. Strut  

   - Struct is a scale down or light weight version of a class

     | **Question**                                                 | **Struct**                                                |
     | ------------------------------------------------------------ | --------------------------------------------------------- |
     | Is  this a value type or a reference                         | A  struct is a value type                                 |
     | Do  instances live on the stack or the heap?                 | Struct  instances are called objects and live on the heap |
     | Can  you declare a default constructor                       | No                                                        |
     | If  you  declare a  constructor, will the compiler still write the  default constructor? | Yes                                                       |
     | If  you  don’t initialize a field in your own constructor, will the compiler  automatically initialize it for you? | No                                                        |
     | Are  you allowed to initialize instance fields at their point of declaration? | No                                                        |

3. Interface 

4. Enum 

5. Delegates



## General

### XML

- XML stands for extensible Markup Language.

- A markup language is used to provide information about a document.

- Tags are added to the document to provide the extra information.

- HTML tags tell a browser how to display the document.

- XML tags give a reader some idea what some of the data means.

##### What is XML Used For?

- XML documents are used to transfer data from one place to another often over the Internet.
- Data Interchange between systems.
- XML subsets are designed for particular applications.
  - One is RSS (Rich Site Summary or Really Simple Syndication ). It is used to send breaking news bulletins from one web site to another.
  - A number of fields have their own subsets. These include chemistry, mathematics, and books publishing.
  - Most of these subsets are registered with the W3Consortium and are available for anyone’s use.

##### Advantages of XML

- text (Unicode) based.
- can be displayed differently in different media.
- can be modularized. Parts can be reused.

##### Difference Between HTML and XML

| HTML                                                         | XML                                                          |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| HTML tags have a fixed meaning and browsers know what it is. | XML tags are different for different applications, and users know what they mean. |
| for display                                                  | for describe documents and data.                             |

##### Querying XML with XPath and XQuery













### References

https://www.tutorialsteacher.com/csharp/csharp-keywords

[c# keywords](http://ccftp.scu.edu.cn:8090/Download/189bbcbb-73fd-47a6-837b-f1cc093eaa74.pdf)

