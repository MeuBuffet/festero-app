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

        HasMany(x => x.Companies)
            .KeyColumn("UserId")
            .Inverse()
            .Cascade.All();
    }
}