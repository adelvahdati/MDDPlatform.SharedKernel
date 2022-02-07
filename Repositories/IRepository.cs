
using System.Linq.Expressions;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.SharedKernel.Repositories
{
    public interface IRepository<T, TId> where T : BaseEntity<TId>, IAggregateRoot
    {
        Task<T> GetAsync(TId id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        
        Task<IReadOnlyList<T>> ListAsync();
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate);
        
        Task<long> CountAsync(Expression<Func<T, bool>> predicate);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAync(TId Id);
    }
}