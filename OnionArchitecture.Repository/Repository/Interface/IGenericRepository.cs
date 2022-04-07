using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionArchitecture.Repository.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> Exists(long id);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
