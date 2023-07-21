using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobHuntApi.Contracts;
using JobHuntApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHuntApi.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly JobHuntApiDbContext _jobHuntApiDbContext;
        public RepositoryBase(JobHuntApiDbContext jobHuntApiDbContext)
        {
            this._jobHuntApiDbContext = jobHuntApiDbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _jobHuntApiDbContext.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _jobHuntApiDbContext.Remove(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _jobHuntApiDbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _jobHuntApiDbContext.Set<T>().FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _jobHuntApiDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _jobHuntApiDbContext.Update(entity);
            await SaveAsync();
        }
    }
}