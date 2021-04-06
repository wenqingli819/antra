using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext; // why protected? it is going to be inherited 

        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        { 
            _dbContext.Set<T>().Add(entity);    // add to memory
            await _dbContext.SaveChangesAsync(); // use save so we have the action goes to database 
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            // need to send ID from UI
            _dbContext.Entry(entity).State = EntityState.Modified; //tell EF, i am doing an update
            await _dbContext.SaveChangesAsync(); // any transaction will happen only when call saveChanges
            return entity;
        }

        public virtual async Task<T> GetByIdAsync(int id)   //virtual, meaning optional to override
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)  // optional filter
        {
            if (filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).CountAsync();
            }
            return await _dbContext.Set<T>().CountAsync();
        }

        public virtual async Task<bool> GetExisitAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return false;
            }
            return await _dbContext.Set<T>().Where(filter).AnyAsync(); //any is very efficient
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

    }
}
