using System;
using System.Collections.Generic;

namespace DelegatePrac
{
    public class PredicatePrac
    {
        public static void PredicateDelegate()
        {
            List<string> countrylist = new List<string>();
            countrylist.Add("USA,Jersey City");
            countrylist.Add("India,Mumbai");
            countrylist.Add("China,Nanchang");

            Predicate<string> isLocInList = s =>
            {
                foreach (var loc in countrylist)
                {
                    string[] location = loc.Split(',');
                   
                    if (location[0].ToLower().Equals(s.ToLower()))
                    {
                        return true;
                    }
                }
                return false;
                
                
                
            };
            Console.WriteLine("Hello Predicate Delegate!");
            Console.WriteLine(isLocInList("china") );
            Console.WriteLine(isLocInList("NANCHANG"));
        }
        
    }
}