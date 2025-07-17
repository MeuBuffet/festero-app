using MeuBuffet.Domain.Entities.Users;
using System.Linq.Expressions;

namespace MeuBuffet.Domain.Interfaces
{
    /// <summary>
    /// Interface de repositório genérico com suporte a commit opcional.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);
        Task AddAndCommitAsync(T entity);

        void Update(T entity);
        Task UpdateAndCommitAsync(T entity);

        void Remove(T entity);
        Task RemoveAndCommitAsync(T entity);

        Task<T?> GetByAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}