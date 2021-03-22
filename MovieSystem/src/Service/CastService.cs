using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entity;
using MovieShop.Repository;

namespace MovieShop.Service
{
    class CastService : ICastService
    {
        CastRepo castRepo;

        public CastService()
        {
            castRepo = new CastRepo();
        }


        public async Task<IEnumerable<Cast>> GetByIdAsync(int id)
        {
            return await castRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Cast>> GetAllAsync()
        {
            return await castRepo.GetAllAsync();
        }

        public async Task<bool> InsertAsync(Cast item)
        {
            return await castRepo.InsertAsync(item);
        }

        public async Task<bool> UpdateAsync(Cast item, int id)
        {
            return await castRepo.UpdateAsync(item,id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await castRepo.DeleteAsync(id);
        }
    }
}
