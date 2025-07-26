using FesteroApp.Domain.Entities.Organizations;
using SrShut.Data;

namespace FesteroApp.Domain.Interfaces.Organizations;

public interface IOrganizationRepository : IRepository<Organization>
{
    Task<IList<Organization>> GetAccessibleOrganizationsAsync(Guid currentOrganizationId);
    Task<bool> HasOrganizationByDocument(string? document);
}