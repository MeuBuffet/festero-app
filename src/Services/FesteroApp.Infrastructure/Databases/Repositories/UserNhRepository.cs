using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces.Users;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Linq;
using SrShut.Data;
using SrShut.Nhibernate;

namespace FesteroApp.Infrastructure.Databases.Repositories;

public class UserNhRepository : EventBusRepository<User>, IUserRepository
{
    public UserNhRepository(
        IConfiguration configuration,
        IUnitOfWorkFactory<ISession> sessionManager,
        IServiceProvider serviceProvider)
        : base(configuration, sessionManager, serviceProvider)
    {
    }

    public async Task<bool> IsCredentialsValid(string email, string? password)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        return await session.Query<User>()
            .Where(u => u.Email!.Address == email && u.Password == password)
            .AnyAsync();
        
        unitOfWork.Complete();
        session.Dispose();
    }

    public async Task<bool> HasUserByEmail(string email)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        return await session.Query<User>()
            .Where(u => u.Email!.Address == email)
            .AnyAsync();
    }

    public async Task<User> GetAsyncByEmail(string email)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        return await session.Query<User>()
            .Where(u => u.Email!.Address == email)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> HasUserByDocument(string document)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        return await session.Query<User>()
            .Where(u => u.Document! == document)
            .AnyAsync();
    }
}