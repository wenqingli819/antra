using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQPrac
{
    public class IEnumerablePrac
    {public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            
            public static List< Student> studentList = new List< Student>() {
                new Student() {ID = 1, Name = "James", Gender = "Male"},
                new Student() {ID = 2, Name = "Sara", Gender = "Female"},
                new Student() {ID = 3, Name = "Steve", Gender = "Male"},
                new Student() {ID = 4, Name = "Pam", Gender = "Female"}
            };
        }
        public static void IEnumerableDemo()
        {
            IEnumerable<Student> listStudents = Student.studentList.Where(x => x.Gender == "Male");
            listStudents = listStudents.Take(2);
            Console.WriteLine("Hi, IEnumerable!");
            
            foreach (var std in listStudents)
            {
                Console.WriteLine(std.Name + " " + std.Gender);
            }
        }
    }
}