using FesteroApp.Domain.Entities.Users;
using FluentNHibernate.Mapping;

namespace FesteroApp.Infrastructure.Databases.Mappings;

public class UserOrganizationMap : ClassMap<UserOrganization>
{
    public UserOrganizationMap()
    {
        Id(x => x.Id).GeneratedBy.Identity();
        
        Map(x => x.Role).Not.Nullable();

        References(x => x.User)
            .Column("UserId")
            .Not.Nullable()
            .Cascade.None();

        References(x => x.Organization)
            .Column("OrganizationId")
            .Not.Nullable()
            .Cascade.None();
    }
}