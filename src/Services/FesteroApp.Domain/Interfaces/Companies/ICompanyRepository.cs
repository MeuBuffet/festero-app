using FesteroApp.Domain.Entities.Companies;
using SrShut.Data;

namespace FesteroApp.Domain.Interfaces.Companies;

public interface ICompanyRepository : IRepository<Company>
{
    Task<IList<Company>> GetAccessibleCompaniesAsync(Guid currentCompanyId);
}