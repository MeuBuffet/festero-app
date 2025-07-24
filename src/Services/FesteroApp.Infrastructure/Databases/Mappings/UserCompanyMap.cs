using FesteroApp.Domain.Entities.Users;
using FluentNHibernate.Mapping;

namespace FesteroApp.Infrastructure.Databases.Mappings;

public class UserCompanyMap : ClassMap<UserCompany>
{
    public UserCompanyMap()
    {
        Table("UserCompany");
        
        Id(m => m.Id).GeneratedBy.Identity();

        References(x => x.User)
            .Column("UserId")
            .Not.Nullable()
            .Cascade.None();

        References(x => x.Company)
            .Column("CompanyId")
            .Not.Nullable()
            .Cascade.None();
    }
}