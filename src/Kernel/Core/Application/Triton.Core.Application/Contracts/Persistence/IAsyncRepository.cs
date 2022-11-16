using System.Linq.Expressions;
using Triton.Core.Domain.Common;

namespace Triton.Core.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                       string? includeString = null,
                                       bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                       List<Expression<Func<T, object>>>? includes = null,
                                       bool disableTracking = true);


        Task<T> GetEntityByIdAsync(int id);
        Task<T> AddEntityAsync(T entity);
        Task<T> UpdateEntityAsync(T entity);
        Task DeleteEntityAsync(T entity);

        T GetEntityById(int id);
        T AddEntity(T entity);
        T UpdateEntity(T entity);
        void DeleteEntity(T entity);
    }
}
