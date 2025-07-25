using FesteroApp.Domain.Entities.Companies;
using FesteroApp.Domain.ValueObjects;
using SrShut.Cqrs.Domains;

namespace FesteroApp.Domain.Entities.Users;

public class User : AggregateRoot<Guid>
{
    public User()
    {
        Companies = new List<UserCompany>();
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
        Document = document;
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

    public virtual IList<UserCompany> Companies { get; set; }

    public virtual void AddCompany(string role, Company company)
    {
        var entity = Companies.FirstOrDefault(c => c.Company == company);

        entity ??= new UserCompany(role, this, company);

        Companies.Add(entity);

        UpdatedOn = DateTime.Now;
    }

    public virtual void Delete()
    {
        DeletedOn = DateTime.Now;
    }
}