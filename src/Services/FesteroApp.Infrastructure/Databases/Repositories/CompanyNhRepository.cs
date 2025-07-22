using FesteroApp.Domain.Entities.Companies;
using FesteroApp.Domain.Interfaces.Companies;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Linq;
using SrShut.Data;
using SrShut.Nhibernate;

namespace FesteroApp.Infrastructure.Databases.Repositories;

public class CompanyNhRepository : EventBusRepository<Company>, ICompanyRepository
{
    public CompanyNhRepository(
        IConfiguration configuration,
        IUnitOfWorkFactory<ISession> sessionManager,
        IServiceProvider serviceProvider)
        : base(configuration, sessionManager, serviceProvider)
    {
    }

    public async Task<bool> HasUserByEmail(string document)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        return await session.Query<Company>()
            .Where(u => u.Document == document)
            .AnyAsync();
    }

    public async Task<Company> GetAsyncByEmail(string document)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        return await session.Query<Company>()
            .Where(u => u.Document == document)
            .FirstOrDefaultAsync();
    }
}