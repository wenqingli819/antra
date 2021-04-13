using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IAsyncRepository<Genre> _genreRepository;
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;
        private const string genresCacheKey = "genres";
        private readonly TimeSpan _cacheDuration = TimeSpan.FromDays(20);

        public GenreService(IAsyncRepository<Genre> genreRepository, IMemoryCache cache, ILogger<GenreService> logger)
        {
            _genreRepository = genreRepository;
            _logger = logger;
            _cache = cache;
        }
        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            _logger.LogInformation("Using cache for GenreService");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // if cache does not contain genresCacheKey, go to repo and get data; otherwise use the cached data
            var genres = await _cache.GetOrCreateAsync(genresCacheKey, CacheCheck);
            sw.Stop();

            _logger.LogInformation("Elapsed={0}", sw.Elapsed);
            return genres;

            #region normal way. do not use. use cache instead
            //var genres = await _genreRepository.ListAllAsync();
            //var genresModel = new List<GenreModel>();
            //foreach (var genre in genres)
            //{
            //    genresModel.Add(new GenreModel()
            //    {
            //        Id = genre.Id, Name = genre.Name
            //    });
            //}
            //return genresModel.OrderBy(g=>g.Name);
            #endregion

        }

        private async Task<IEnumerable<GenreModel>> CacheCheck(ICacheEntry entry)
        {
            entry.SlidingExpiration = _cacheDuration;
            var genres= await _genreRepository.ListAllAsync();
            var genresModel = new List<GenreModel>();
            foreach (var genre in genres)
            {
                genresModel.Add(new GenreModel()
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return genresModel.OrderBy(g => g.Name);
        }
    }
}
