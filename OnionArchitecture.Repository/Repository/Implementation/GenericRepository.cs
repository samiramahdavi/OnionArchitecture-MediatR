using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Repository.Context;
using OnionArchitecture.Repository.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionArchitecture.Repository.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(long id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<T> GetAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}
