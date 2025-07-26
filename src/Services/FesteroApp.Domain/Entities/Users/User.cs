using FesteroApp.Domain.Entities.Organizations;
using FesteroApp.Domain.ValueObjects;
using SrShut.Cqrs.Domains;

namespace FesteroApp.Domain.Entities.Users;

public class User : AggregateRoot<Guid>
{
    public User()
    {
        Companies = new List<UserOrganization>();
    }
    
    public User(Guid id, string? name, string? document, string? password, Email? email) : this()
    {
        Id = id;
        Name = name;
        Document = document;
        Password = password;
        Email = email;

        CreatedOn = UpdatedOn = DateTime.Now;
    }

    public User(Guid id, string? name, string? document, string? password, Email? email, Phone? phone,
        Address? address) : this()
    {
        Id = id;
        Name = name;
        Document = SrShut.Common.Document.OnlyNumbers(document);
        Password = password;
        Email = email;
        Phone = phone;
        Address = address;

        CreatedOn = UpdatedOn = DateTime.Now;
    }

    public override Guid Id { get; set; }

    public virtual string? Name { get; set; }

    public virtual string? Document { get; set; }

    public virtual string? Password { get; set; }

    public virtual Email? Email { get; set; }

    public virtual Phone? Phone { get; set; }

    public virtual Address? Address { get; set; }

    public virtual DateTime? CreatedOn { get; set; }

    public virtual DateTime? UpdatedOn { get; set; }

    public virtual DateTime? DeletedOn { get; set; }

    public virtual IList<UserOrganization> Companies { get; set; }

    public virtual void AddOrganization(string role, Organization organization)
    {
        var entity = Companies.FirstOrDefault(c => c.Organization.Equals(organization));

        entity ??= new UserOrganization(role, this, organization);

        Companies.Add(entity);

        UpdatedOn = DateTime.Now;
    }

    public virtual void Delete()
    {
        DeletedOn = DateTime.Now;
    }
}