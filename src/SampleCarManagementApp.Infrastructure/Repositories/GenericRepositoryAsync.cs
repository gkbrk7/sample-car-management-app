using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleCarManagementApp.Application.Interfaces;
using SampleCarManagementApp.Infrastructure.Contexts;

namespace SampleCarManagementApp.Infrastructure.Repositories
{
    public class GenericRepositoryAsync<T>(ApplicationDbContext dbContext) : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext dbContext = dbContext;

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await dbContext.Set<T>().AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return entity;

        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken)
        {
            return filter is null ?
                await dbContext.Set<T>()
                    .AsNoTracking()
                    .ToListAsync(cancellationToken: cancellationToken) :
                await dbContext.Set<T>()
                    .Where(filter)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken: cancellationToken);

        }

        public async Task<IReadOnlyList<T>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            return filter is null ?
                 await dbContext.Set<T>()
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken: cancellationToken) :
                 await dbContext.Set<T>()
                    .Where(filter)
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            return await dbContext.Set<T>()
                .FirstOrDefaultAsync(filter, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}