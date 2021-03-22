using MovieShop.Entity;
using MovieShop.Repository;
using MovieShop.Service;
using System;
using System.Collections.Generic;


namespace MovieShop.UI
{
    class ManageCast
    {
        private readonly CastRepo castRepo;

        public ManageCast()
        {
            castRepo = new CastRepo();
        }

        void PrintAll()
        {
            IEnumerable<Cast> casts = (IEnumerable<Cast>)castRepo.GetAllAsync();     // if without the cast, it will show error too, "are you missing a cast?"
            //Unhandled exception. System.InvalidCastException: 
            //Unable to cast object of type 'AsyncStateMachineBox`1[System.Collections.Generic.IEnumerable`1[MovieShop.Entity.Cast],
            //                                                      MovieShop.Repository.CastRepo+<GetAllAsync>d__1]' 
            // to type 'System.Collections.Generic.IEnumerable`1[MovieShop.Entity.Cast]'.
            if (casts == null)
            {
                Console.WriteLine("something wrong happened");
            }
            else
            {
                foreach (var item in casts)
                {
                    Console.WriteLine(item.Id + " \t " + item.Name + "\t" + item.@TmdbUrl + "\t" + item.Gender + "\t" + item.ProfilePath);
                }
            }
        }

        public void Run()
        {
            PrintAll();
        }
    }
}
