using FesteroApp.Users.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace FesteroApp.Users.Infrastructure.Persistence.DbContexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}