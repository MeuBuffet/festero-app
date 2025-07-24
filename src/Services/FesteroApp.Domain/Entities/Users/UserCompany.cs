using FesteroApp.Domain.Entities.Companies;

namespace FesteroApp.Domain.Entities.Users;

public class UserCompany
{
    public UserCompany()
    {
    }

    public UserCompany(User user, Company company) : this()
    {
        User = user;
        Company = company;
    }

    public virtual int Id { get; set; }

    public virtual User User { get; set; }

    public virtual Company Company { get; set; }
}