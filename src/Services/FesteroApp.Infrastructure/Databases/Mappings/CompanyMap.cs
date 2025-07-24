using FesteroApp.Domain.Entities.Companies;
using FluentNHibernate.Mapping;

namespace FesteroApp.Infrastructure.Databases.Mappings;

public class CompanyMap : ClassMap<Company>
{
    public CompanyMap()
    {
        Id(x => x.Id).GeneratedBy.GuidComb();
        Map(x => x.LegalName).Not.Nullable();
        Map(x => x.TradeName).Not.Nullable();
        Map(x => x.Document).Not.Nullable();
        Map(x => x.Type).Not.Nullable();
        Map(x => x.Industry).Not.Nullable();

        Map(x => x.CreatedOn).Not.Nullable();
        Map(x => x.UpdatedOn).Not.Nullable();
        Map(x => x.DeletedOn).Nullable();
        Map(x => x.Level).Not.Nullable();
        Map(x => x.Path).Not.Nullable();

        Component(x => x.Email, c => { c.Map(x => x.Address).Column("Email").Not.Nullable(); });

        Component(x => x.Phone, c => { c.Map(x => x.Number).Column("Phone").Not.Nullable(); });

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
        
        References(x=>x.Parent)
            .Column("ParentId")
            .Nullable()
            .Cascade.None();
        
        HasMany(x => x.Children)
            .KeyColumn("ParentId") 
            .Inverse()
            .Cascade.All();
        
        HasMany(x => x.UserCompanies)
            .KeyColumn("CompanyId")
            .Inverse()
            .Cascade.All();
    }
}