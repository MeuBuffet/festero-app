using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Enums;
using FesteroApp.Domain.ValueObjects;
using SrShut.Cqrs.Domains;

namespace FesteroApp.Domain.Entities.Companies;

public class Company : AggregateRoot<Guid>
{
    public Company()
    {
        UserCompanies = new List<UserCompany>();
        Children = new List<Company>();
    }

    public Company(Guid id, string? legalName, string? tradeName, string? document, string? type, Industries? industry,
        Email? email, Phone? phone, Address? address, Company? parent = null) : this()
    {
        Id = id;
        LegalName = legalName;
        TradeName = tradeName;
        Document = document;
        Type = type;
        Industry = industry;
        Email = email;
        Phone = phone;
        Address = address;
        SetTenant(parent);

        CreatedOn = UpdatedOn = DateTime.Now;
    }

    public override Guid Id { get; set; }

    public virtual string? LegalName { get; set; }

    public virtual string? TradeName { get; set; }

    public virtual string? Document { get; set; }

    public virtual string? Type { get; set; }

    public virtual Industries? Industry { get; set; }

    public virtual int? Level { get; set; }

    public virtual string? Path { get; set; }

    public virtual DateTime? CreatedOn { get; set; }

    public virtual DateTime? UpdatedOn { get; set; }

    public virtual DateTime? DeletedOn { get; set; }

    public virtual Email? Email { get; protected set; }

    public virtual Phone? Phone { get; protected set; }

    public virtual Address? Address { get; protected set; }

    public virtual Company? Parent { get; protected set; }

    public virtual IList<Company> Children { get; protected set; }
    
    public virtual IList<UserCompany> UserCompanies { get; protected set; }

    public virtual void SetTenant(Company? parent)
    {
        Parent = parent;
        Level = parent?.Level + 1 ?? 0;
        Path = parent != null ? $"{parent.Path}/{Id}" : $"/{Id}";
    }

    public virtual void Update(string? legalName, string? tradeName, string? document, string? type, Industries? industry,
        Email? email, Phone? phone, Address? address)
    {
        LegalName = legalName;
        TradeName = tradeName;
        Document = document;
        Type = type;
        Industry = industry;
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