using MovieShop.Entity;
using MovieShop.Repository;
using MovieShop.Service;
using System;
using System.Collections.Generic;


namespace MovieShop.UI
{
    class ManageCast
    {
        private readonly CastService castService;

        public ManageCast()
        {
            CastService castService = new CastService();
        }

        void PrintAll()
        {
            // Object reference not set to an instance of an object.
            IEnumerable<Cast> casts = (IEnumerable<Cast>)castService.GetAllAsync();
            foreach (var item in casts)
            {
                Console.WriteLine(item.Id + " \t " + item.Name + "\t" + item.@TmdbUrl + "\t" + item.Gender + "\t" + item.ProfilePath);
            }
        }

        public void Run()
        {
            PrintAll();
        }
    }
}
