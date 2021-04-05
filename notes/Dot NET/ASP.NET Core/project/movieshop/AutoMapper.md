## AutoMapper

https://docs.automapper.org/en/latest/Getting-started.html

map the DTOs (Data Transfer Objects) in your application to the model objects.

### why need?

```c#
class Main{
    Person per = new Person();
    per.FirstName = "Shiv";
    per.LastName = "Koirala";
    // say we want to move the data from person object into employee object
    Employee emp = new Employee();
    //source property      destination property
    emp.FirstName = per.FirstName;
    emp.LastName = per.LastName;
    // this is fine. but suppose if we want to reuse this maping code again and again
    
    
    // SO, we want to centralize this mapping code in some central library, then reuse the mapping code
    Mapper.CreateMap<Person, Employee>();  //1. create a map
    Employee emp = Mapper.Map<Employee>(per); //2. perform the mapping
    // copy the data from person object to employee
    
}
class Employee{}
class Person{}
```

![image-20210404192616162](../../../../../resources/image-20210404192616162.png)



if the property names are the same in two classes, they transfer automatically.

if different, then:

```c#
Person per  = new Person();
per.FirstName = "Shiv";
per.LastName = "Koirala";
//create a map
Mapper.CreateMap<Person,Employee>()
    .ForMemeber(dest=>dest.FName, opt =>opt.MapFrom(src =>src.FirstName))
    .ForMember(dest => dest.LName, opt => opt.MapFrom(src =>src.LastName));
```





### Two steps:

1. create a map
2. perform the mapping

```c#
 public class AuthorModel
 {
     public int Id{get; set;}
     public string FirstName{get;set;}
     public string LastName{get; set;}
     public string Address{get; set;}
 }

public class AuthorDTO
{
        public int Id{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Address{get; set;}
}

//create a map between these two types, AuthorModel and AuthorDTO.
var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AuthorModel, AuthorDTO>();
            });

//perform the mapping between the types
IMapper iMapper = config.CreateMapper();
var source = new AuthorModel();
source.Id = 1;
source.FirstName = "Joydip";
source.LastName = "Kanjilal";
source.Address = "India";
var destination = iMapper.Map<AuthorModel, AuthorDTO>(source);
```

