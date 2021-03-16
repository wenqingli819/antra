# C# Keywords

### Access Modifiers

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



- **new Constraint** 

  Used to restrict types that might be used as arguments for a type parameter in a generic declaration.





- symbol characters

  `%`

  `@`

  `$`

- types
  - **class**
    - string
    - ...
  - **struct**
    - int
    - ...
  - **enum**
  - **interface**
  - **delegate**

https://www.tutorialsteacher.com/csharp/csharp-keywords

[c# keywords](http://ccftp.scu.edu.cn:8090/Download/189bbcbb-73fd-47a6-837b-f1cc093eaa74.pdf)

