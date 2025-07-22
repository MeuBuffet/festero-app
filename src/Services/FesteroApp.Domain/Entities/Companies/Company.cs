using FesteroApp.Domain.ValueObjects;

namespace FesteroApp.Domain.Entities.Companies;

public class Company
{
    public Company()
    {
    }

    public Company(Guid id, string? name, string? corporateName, string? document, Email email, Phone phone, Address address) : this()
    {
        Id = id;
        Name = name;
        CorporateName = corporateName;
        Document = document;
        Email = email;
        Phone = phone;
        Address = address;

        CreatedOn = UpdatedOn = DateTime.Now;
    }

    public virtual Guid Id { get; set; }

    public virtual string? Name { get; set; }

    public virtual string? CorporateName { get; set; }

    public virtual string? Document { get; set; }

    public virtual DateTime? CreatedOn { get; set; }

    public virtual DateTime? UpdatedOn { get; set; }

    public virtual DateTime? DeletedOn { get; set; }

    public virtual Email Email { get; protected set; }

    public virtual Phone Phone { get; protected set; }

    public virtual Address Address { get; protected set; }

    public virtual void Update(string? name, string? corporateName, string? document, Email email, Phone phone,
        Address address)
    {
        Name = name;
        CorporateName = corporateName;
        Document = document;
        Email = email;
        Phone = phone;
        Address = address;

        UpdatedOn = DateTime.Now;
    }

    public virtual void UpdateContact(Email email, Phone phone)
    {
        Email = email;
        Phone = phone;
    }

    public virtual void UpdateAddress(Address address)
    {
        Address = address;
    }

    public virtual void Delete()
    {
        DeletedOn = DateTime.Now;
    }
}