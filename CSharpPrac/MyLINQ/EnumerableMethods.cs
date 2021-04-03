using System;
using System.Linq;

namespace MyLinqExtensions
{
    public class EnumerableMethods
    {
        static void Main(string[] args)
        {
            var query = from method in typeof(System.Linq.Enumerable).GetMethods()
                where method.DeclaringType == typeof(Enumerable)
                orderby method.Name
                group method by method.Name;  // there are many overloads for each operator(method).
                                              // so group by method name to avoid repetitive names get printed 
            int count = 0;
            foreach (var item in query)
            {
                count++;
                Console.WriteLine(count + ": " + item.Key);
            }
            
            var query2 = from method in typeof(System.Linq.Enumerable).GetMethods()
                where method.DeclaringType == typeof(Enumerable)
                orderby method.Name
                group method by method.Name into g
                select new { Name = g.Key, Overloads = g.Count() };

            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }
        }
    }
}