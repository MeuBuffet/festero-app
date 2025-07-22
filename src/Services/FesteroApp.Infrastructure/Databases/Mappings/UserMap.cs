using FesteroApp.Domain.Entities.Users;
using FluentNHibernate.Mapping;

namespace FesteroApp.Infrastructure.Databases.Mappings;

public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        Id(m => m.Id).Not.Nullable();

        Map(m => m.Name).Not.Nullable();
        Map(m => m.Email).Not.Nullable();
        Map(m => m.Password).Not.Nullable();

        Map(m => m.CreatedOn).Not.Nullable();
        Map(m => m.UpdatedOn).Not.Nullable();
        Map(m => m.DeletedOn).Nullable();
    }
}