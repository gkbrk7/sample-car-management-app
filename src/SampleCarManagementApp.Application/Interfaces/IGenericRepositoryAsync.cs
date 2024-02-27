using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SampleCarManagementApp.Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? filter = default, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}