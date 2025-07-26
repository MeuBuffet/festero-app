using FesteroApp.Domain.Entities.Organizations;
using FluentNHibernate.Mapping;

namespace FesteroApp.Infrastructure.Databases.Mappings;

public class OrganizationConfigurationMap : ClassMap<OrganizationConfiguration>
{
    public OrganizationConfigurationMap()
    {
        Id(x => x.Id).GeneratedBy.Identity();
        
        Map(x => x.WorkdayStart).Nullable().CustomType("TimeAsTimeSpan");
        Map(x => x.WorkdayEnd).Nullable().CustomType("TimeAsTimeSpan");

        References(x => x.Organization)
            .Column("OrganizationId").Not.Nullable()
            .Unique();
    }
}