using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHuntApi.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        /*
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        */
        Task<bool> DeleteAsync(string id);

        Task SaveAsync();
    }
}