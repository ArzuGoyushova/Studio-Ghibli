using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Domain.Common;
using GhibliServer.Persistence.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;  
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _dbSet.FindAsync(id);
            if(item == null)
            {
                throw new Exception("Not Found");
            }
            _appDbContext.Remove(item);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllItemsAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetItemByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<T> UpdateAsync(Guid id, T item)
        {
            _appDbContext.Attach(item);
            _appDbContext.Entry(item).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();

            return item;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<T>> GetAllItemsWithIncludesAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetItemByIdWithIncludesAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}
