using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LINQPrac
{
    public class Linq101
    {
        public static void linqQuerySyntax()
        {
            // 1. Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            // 2. LINQ Query using Query Syntax
            var QuerySyntax = from n in integerList
                              where n > 5
                              select n;
            Console.WriteLine("Hi, Query Syntax!");
            // 3. Execution
            foreach(var item in QuerySyntax)
            {
                Console.Write(item + " ");
            }
        }
        public static void linqMethodSyntax()
        {
            // 1. Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            // 2. LINQ Query using Method Syntax
            var methodSyntax = integerList.Where(n => n > 5).ToList();
            
            Console.WriteLine("Hi, Method Syntax!");
            // 3. Execution
            foreach(var item in methodSyntax)
            {
                Console.Write(item + " ");
            }
        }

        public static void linqMixedSyntax()
        {
            // 1. Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            // 2. LINQ Query using Mixed Syntax
            var MixedSyntax = (from n in integerList
                                    where n > 5
                                    select n).Sum();
            
            Console.WriteLine("Hi, Mixed Syntax!");
            // 3. Execution
            Console.Write("Sum Is : " + MixedSyntax);
        }
        
    }
}