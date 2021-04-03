using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LINQPrac
{
    public class InnerJoin
    {
        public void Test()
        {
            var people = new Musician();
            var orders = new Order();

            foreach (var p in people)
            {
                Console.WriteLine(p);
            }
            
            // var query = from p in people
            //     join o in orders on p.MusicianId equals o.MusicianId
            //     select new { Musician = p.Name, OrderId = o.OrderId };
            //
            // foreach (var item in query)
            // {
            //     Console.WriteLine(item);
            // }
        }
    }
}