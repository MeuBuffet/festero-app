using FesteroApp.Domain.Entities.Users;
using FluentNHibernate.Mapping;

namespace FesteroApp.Infrastructure.Databases.Mappings;

public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        Id(x => x.Id).Not.Nullable();

        Map(x => x.Name).Not.Nullable();
        Map(x => x.Document).Not.Nullable();
        Map(x => x.Password).Not.Nullable();

        Map(x => x.CreatedOn).Not.Nullable();
        Map(x => x.UpdatedOn).Not.Nullable();
        Map(x => x.DeletedOn).Nullable();

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