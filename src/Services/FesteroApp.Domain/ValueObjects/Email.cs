namespace FesteroApp.Domain.ValueObjects;

public class Email
{
    protected Email()
    {
    }

    public Email(string address) : this()
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Email inválido");

        Address = address.ToLowerInvariant();
    }

    public virtual string Address { get; protected set; }
    
    public override bool Equals(object? obj) =>
        obj is Email other && Address == other.Address;

    public override int GetHashCode() => Address.GetHashCode();
}