using MovieShop.Entity;
using MovieShop.Repository;
using MovieShop.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MovieShop.UI
{
    class ManageCast
    {
        private readonly FilmCastService filmCastService;

        public ManageCast()
        {
            filmCastService = new FilmCastService();
        }

        async Task PrintAllAsync()
        {
            var casts = await filmCastService.GetAllAsync();    
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

        async Task PrintOneAsync()
        {
            var casts = await filmCastService.GetByIdAsync(1);    
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
            //PrintAllAsync();
            PrintOneAsync();
        }
    }
}
