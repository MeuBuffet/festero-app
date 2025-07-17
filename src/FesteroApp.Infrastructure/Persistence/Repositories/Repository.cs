using FesteroApp.Domain.Interfaces;
using FesteroApp.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FesteroApp.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Repositório genérico com suporte a operações com e sem commit.
    /// </summary>
    public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context = context;
        protected readonly DbSet<T> _dbSet = context.Set<T>();

        /// <summary>
        /// Adiciona a entidade no contexto (sem commit).
        /// </summary>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        /// <summary>
        /// Adiciona a entidade e persiste imediatamente com commit.
        /// </summary>
        public async Task AddAndCommitAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza a entidade no contexto (sem commit).
        /// </summary>
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        /// Atualiza a entidade e persiste imediatamente com commit.
        /// </summary>
        public async Task UpdateAndCommitAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove a entidade do contexto (sem commit).
        /// </summary>
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Remove a entidade e persiste imediatamente com commit.
        /// </summary>
        public async Task RemoveAndCommitAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retorna entidade por Id.
        /// </summary>
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Retorna todas as entidades.
        /// </summary>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}