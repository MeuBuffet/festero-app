using FesteroApp.Domain.Entities.Organizations;

namespace FesteroApp.Domain.Entities.Users;

public class UserOrganization
{
    public UserOrganization()
    {
    }

    public UserOrganization(string role, User user, Organization organization) : this()
    {
        Role = role;
        User = user;
        Organization = organization;
    }

    public virtual int Id { get; set; }
    
    public virtual string Role { get; set; }

    public virtual User User { get; set; }

    public virtual Organization Organization { get; set; }
}