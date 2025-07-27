using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Enums;
using FesteroApp.Domain.ValueObjects;
using SrShut.Cqrs.Domains;

namespace FesteroApp.Domain.Entities.Organizations;

public class Organization : AggregateRoot<Guid>
{
    public Organization()
    {
        UserOrganizations = new List<UserOrganization>();
        Children = new List<Organization>();
        Configuration = new OrganizationConfiguration(this);
    }

    public Organization(Guid id, string? legalName, string? tradeName, string? document, OrganizationTypes? type,
        Industries? industry, Email? email, Phone? phone, Address? address, Organization? parent = null) : this()
    {
        Id = id;
        LegalName = legalName;
        TradeName = tradeName;
        Document = SrShut.Common.Document.OnlyNumbers(document);
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

    public virtual OrganizationTypes? Type { get; set; }

    public virtual Industries? Industry { get; set; }

    public virtual int? Level { get; set; }

    public virtual string? Path { get; set; }

    public virtual DateTime? CreatedOn { get; set; }

    public virtual DateTime? UpdatedOn { get; set; }

    public virtual DateTime? DeletedOn { get; set; }

    public virtual Email? Email { get; protected set; }

    public virtual Phone? Phone { get; protected set; }

    public virtual Address? Address { get; protected set; }

    public virtual Organization? Parent { get; protected set; }

    public virtual OrganizationConfiguration? Configuration { get; protected set; }

    public virtual IList<Organization> Children { get; protected set; }

    public virtual IList<UserOrganization> UserOrganizations { get; protected set; }

    public virtual void SetTenant(Organization? parent)
    {
        Parent = parent;
        Level = parent?.Level + 1 ?? 0;
        Path = parent != null ? $"{parent.Path}/{Id}" : $"/{Id}";
    }

    public virtual void Update(string? legalName, string? tradeName, string? document, OrganizationTypes? type, Industries? industry,
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

    public virtual void UpdateConfiguration(TimeSpan? workDayStart, TimeSpan? workDayEnd)
    {
        if (Configuration == null)
            Configuration = new OrganizationConfiguration(this, workDayStart, workDayEnd);
        else
            Configuration.SetWorkHours(workDayStart, workDayEnd);

        UpdatedOn = DateTime.Now;
    }

    public virtual void UpdateContact(Email email, Phone phone)
    {
        Email = email;
        Phone = phone;

        UpdatedOn = DateTime.Now;
    }

    public virtual void UpdateAddress(Address address)
    {
        Address = address;

        UpdatedOn = DateTime.Now;
    }

    public virtual void Delete()
    {
        DeletedOn = DateTime.Now;
    }
}