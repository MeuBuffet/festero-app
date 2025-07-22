using FesteroApp.Domain.Entities.Companies;
using FluentNHibernate.Mapping;

namespace FesteroApp.Infrastructure.Databases.Mappings;

public class CompanyMap : ClassMap<Company>
{
    public CompanyMap()
    {
        Id(x => x.Id).GeneratedBy.GuidComb();
        Map(x => x.Name).Not.Nullable();
        Map(x => x.CorporateName).Not.Nullable();
        Map(x => x.Document).Not.Nullable();
        Map(x => x.CreatedOn).Not.Nullable();
        Map(x => x.UpdatedOn).Not.Nullable();
        Map(x => x.DeletedOn).Nullable();

        Component(x => x.Email, c =>
        {
            c.Map(x => x.Address).Column("Email").Not.Nullable();
        });

        Component(x => x.Phone, c =>
        {
            c.Map(x => x.Number).Column("Phone").Not.Nullable();
        });

        Component(x => x.Address, c =>
        {
            c.Map(x => x.Street).Not.Nullable();
            c.Map(x => x.Number).Not.Nullable();
            c.Map(x => x.Complement).Nullable();
            c.Map(x => x.Neighborhood).Not.Nullable();
            c.Map(x => x.PostalCode).Not.Nullable();
            c.Map(x => x.City).Not.Nullable();
            c.Map(x => x.State).Not.Nullable();
        });
    }
}