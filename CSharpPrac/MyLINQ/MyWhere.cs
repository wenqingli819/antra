using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLinqExtensions
{
    public static class MyWhere
    {
        public static IEnumerable<T> Where <T> (this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }

    class Program
    {
        public static IEnumerable<int> GetList()
        {
            var length = 6;
            for (int i = 1; i <= length; i++)
            {
                yield return i;
            }
        }

        // static void Main(string[] args)
        // {
        //     var list = GetList();
        //     var query = list.Where(num => num < 3).Select(num => num);
        //     foreach (var item in query) //1,
        //     {
        //         Console.WriteLine(item);
        //     }
        // }
    }
}