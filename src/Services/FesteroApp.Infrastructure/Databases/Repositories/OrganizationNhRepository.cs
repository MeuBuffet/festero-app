using FesteroApp.Domain.Entities.Organizations;
using FesteroApp.Domain.Interfaces.Organizations;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Linq;
using SrShut.Data;
using SrShut.Nhibernate;

namespace FesteroApp.Infrastructure.Databases.Repositories;

public class OrganizationNhRepository(
    IConfiguration configuration,
    IUnitOfWorkFactory<ISession> sessionManager,
    IServiceProvider serviceProvider)
    : EventBusRepository<Organization>(
        configuration,
        sessionManager,
        serviceProvider),
        IOrganizationRepository
{
    public async Task<IList<Organization>> GetAccessibleOrganizationsAsync(Guid currentOrganizationId)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        var current = await session.GetAsync<Organization>(currentOrganizationId);
        if (current == null) return new List<Organization>();

        return await session.Query<Organization>()
            .Where(c => c.Path!.StartsWith(current.Path!))
            .ToListAsync();
    }

    public async Task<bool> HasOrganizationByDocument(string? document)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        return await session.Query<Organization>()
            .Where(u => u.Document == document)
            .AnyAsync();
    }

    public async Task<bool> HasUserByEmail(string document)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        return await session.Query<Organization>()
            .Where(u => u.Document == document)
            .AnyAsync();
    }

    public async Task<Organization> GetAsyncByEmail(string document)
    {
        using var unitOfWork = UnitOfWorkFactory.Get();
        var session = unitOfWork.Context;

        return await session.Query<Organization>()
            .Where(u => u.Document == document)
            .FirstOrDefaultAsync();
    }
}