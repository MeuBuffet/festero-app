using MeuBuffet.Domain.Interfaces;
using MeuBuffet.Infrastructure.Persistence.DbContexts;

namespace MeuBuffet.Infrastructure.Persistence
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CommitAsync() => await _context.SaveChangesAsync();
    }
}