using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Cast> GetByIdAsync(int id)
        {
            var cast = await _dbContext.Casts.Where(c => c.Id == id).Include(c => c.MovieCasts)
                .ThenInclude(c => c.Movies).FirstOrDefaultAsync();
            return cast;
        }

        public async Task<IEnumerable<Cast>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cast>> ListAsync(Expression<Func<Cast, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCountAsync(Expression<Func<Cast, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetExisitAsync(Expression<Func<Cast, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Cast> AddAsync(Cast entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Cast> UpdateAsync(Cast entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Cast entity)
        {
            throw new NotImplementedException();
        }


    }
}
