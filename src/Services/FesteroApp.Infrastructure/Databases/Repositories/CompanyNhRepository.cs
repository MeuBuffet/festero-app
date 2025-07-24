using FesteroApp.Domain.Entities.Companies;
using FesteroApp.Domain.Interfaces.Companies;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Linq;
using SrShut.Data;
using SrShut.Nhibernate;

namespace FesteroApp.Infrastructure.Databases.Repositories;

public class CompanyNhRepository(
    IConfiguration configuration,
    IUnitOfWorkFactory<ISession> sessionManager,
    IServiceProvider serviceProvider)
    : EventBusRepository<Company>(configuration, sessionManager, serviceProvider), ICompanyRepository
{
    public async Task<IList<Company>> GetAccessibleCompaniesAsync(Guid currentCompanyId)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;
        
        var current = await session.GetAsync<Company>(currentCompanyId);
        if (current == null) return new List<Company>();

        return await session.Query<Company>()
            .Where(c => c.Path!.StartsWith(current.Path!))
            .ToListAsync();
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