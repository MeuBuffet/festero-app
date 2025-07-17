using FesteroApp.Domain.Interfaces;
using FesteroApp.Infrastructure.Persistence.DbContexts;

namespace FesteroApp.Infrastructure.Persistence
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CommitAsync() => await _context.SaveChangesAsync();
    }
}