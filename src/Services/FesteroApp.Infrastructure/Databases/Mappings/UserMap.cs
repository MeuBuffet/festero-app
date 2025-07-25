using FesteroApp.Domain.Entities.Users;
using FluentNHibernate.Mapping;

namespace FesteroApp.Infrastructure.Databases.Mappings;

public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        Id(m => m.Id).Not.Nullable();

        Map(m => m.Name).Not.Nullable();
        Map(m => m.Document).Not.Nullable();
        Map(m => m.Password).Not.Nullable();

        Map(m => m.CreatedOn).Not.Nullable();
        Map(m => m.UpdatedOn).Not.Nullable();
        Map(m => m.DeletedOn).Nullable();

        Component(x => x.Email, c => { c.Map(x => x!.Address).Column("Email").Not.Nullable(); });

        Component(x => x.Phone, c => { c.Map(x => x!.Number).Column("Phone").Nullable(); });

        Component(x => x.Address, c =>
        {
            c.Map(x => x!.Street).Nullable();
            c.Map(x => x!.Number).Nullable();
            c.Map(x => x!.Complement).Nullable();
            c.Map(x => x!.Neighborhood).Nullable();
            c.Map(x => x!.PostalCode).Nullable();
            c.Map(x => x!.City).Nullable();
            c.Map(x => x!.State).Nullable();
        });

        HasMany(x => x.Companies)
            .KeyColumn("UserId")
            .ExtraLazyLoad()
            .AsBag()
            .BatchSize(16)
            .Inverse().Cascade
            .AllDeleteOrphan();
    }
}