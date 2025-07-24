using FesteroApp.Domain.ValueObjects;
using SrShut.Cqrs.Domains;

namespace FesteroApp.Domain.Entities.Companies;

public class Company : AggregateRoot<Guid>
{
    public Company()
    {
    }

    public Company(Guid id, string? legalName, string? tradeName, string? document, Email email, Phone phone,
        Address address, Company? tentant = null) : this()
    {
        Id = id;
        LegalName = legalName;
        TradeName = tradeName;
        Document = document;
        Email = email;
        Phone = phone;
        Address = address;
        SetTentant(tentant);

        CreatedOn = UpdatedOn = DateTime.Now;
    }

    public override Guid Id { get; set; }

    public virtual string? LegalName { get; set; }

    public virtual string? TradeName { get; set; }

    public virtual string? Document { get; set; }

    public virtual int Level { get; set; }

    public virtual string? Path { get; set; }

    public virtual DateTime? CreatedOn { get; set; }

    public virtual DateTime? UpdatedOn { get; set; }

    public virtual DateTime? DeletedOn { get; set; }

    public virtual Email Email { get; protected set; }

    public virtual Phone Phone { get; protected set; }

    public virtual Address Address { get; protected set; }

    public virtual Company TentantCompany { get; protected set; }

    public virtual void SetTenant(Company? tentant)
    {
        TentantCompany = tentant;
        Level = tentant?.Level + 1 ?? 0;
        Path = tentant != null ? $"{tentant.Path}/{Id}" : $"/{Id}";
    }

    public virtual void Update(string? name, string? corporateName, string? document, Email email, Phone phone,
        Address address)
    {
        LegalName = name;
        TradeName = corporateName;
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