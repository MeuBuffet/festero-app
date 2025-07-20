using FesteroApp.Users.Domain.Interfaces;
using FesteroApp.Users.Infrastructure.Persistence.DbContexts;

namespace FesteroApp.Users.Infrastructure.Persistence
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CommitAsync() => await _context.SaveChangesAsync();
    }
}