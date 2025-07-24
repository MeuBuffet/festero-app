namespace FesteroApp.Domain.ValueObjects;

public class Address
{
    protected Address()
    {
    }

    public Address(string? street, string? number, string? neighborhood, string? complement, string? postalCode, string? city, string? state) : this()
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        Complement = complement;
        PostalCode = postalCode;
        City = city;
        State = state;
    }

    public virtual string? Street { get; protected set; }

    public virtual string? Number { get; protected set; }

    public virtual string? Neighborhood { get; protected set; }

    public virtual string? Complement { get; protected set; }

    public virtual string? PostalCode { get; protected set; }

    public virtual string? City { get; protected set; }

    public virtual string? State { get; protected set; }

    public override bool Equals(object? obj) =>
        obj is Address other && Street == other.Street && Number == other.Number;

    public override int GetHashCode() => HashCode.Combine(Street, Number);
}