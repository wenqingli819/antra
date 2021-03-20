using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQPrac
{
    public class IQueryablePrac
    {
        public class Student
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

        public static void IQueryableDemo() { 
            

            //Linq Query to Fetch all students with Gender Male
            IQueryable<Student> listStudents = Student.studentList.AsQueryable()
                    .Where(std => std.Gender == "Male");
            Console.WriteLine("Hi, IQueryable!");
            //Iterate through the collection
            foreach (var student in listStudents)
            {
                Console.WriteLine($"ID : {student.ID}  Name : {student.Name}");
            }
        }
    }
}