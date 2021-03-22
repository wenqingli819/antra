using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entity;
using MovieShop.Repository;

namespace MovieShop.Service
{
    class FilmCastService : ICastService
    {
        FilmCastRepo filmCastRepo;

        public FilmCastService()
        {
            filmCastRepo = new FilmCastRepo();
        }


        public async Task<IEnumerable<FilmCast>> GetByIdAsync(int id)
        {
            return await filmCastRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<FilmCast>> GetAllAsync()
        {
            return await filmCastRepo.GetAllAsync();
        }

        public async Task<bool> InsertAsync(FilmCast item)
        {
            return await filmCastRepo.InsertAsync(item);
        }

        public async Task<bool> UpdateAsync(FilmCast item, int id)
        {
            return await filmCastRepo.UpdateAsync(item,id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await filmCastRepo.DeleteAsync(id);
        }
    }
}
