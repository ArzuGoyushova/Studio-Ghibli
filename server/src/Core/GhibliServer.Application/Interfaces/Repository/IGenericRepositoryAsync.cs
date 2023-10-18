using GhibliServer.Domain.Common;
using GhibliServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Interfaces.Repository
{
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<List<T>> GetAllItemsAsync();
        Task<T> GetItemByIdAsync(Guid id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(Guid id, T item);
        Task DeleteAsync(Guid id);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllItemsWithIncludesAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetItemByIdWithIncludesAsync(Guid id, params Expression<Func<T, object>>[] includes);
    }
}
