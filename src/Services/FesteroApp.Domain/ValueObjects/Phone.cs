using System.Text.RegularExpressions;
using SrShut.Common;

namespace FesteroApp.Domain.ValueObjects;

public class Phone
{
    protected Phone()
    {
    }

    public Phone(string number) : this()
    {
        Throw.IsNull(number, "PhoneNumber.Number", "Telefone é obrigatório.");

        var digits = Regex.Replace(number, @"\D", "");

        Throw.IsTrue(digits.Length < 10 || digits.Length > 11, "Phone.Number", "Número de telefone inválido.");

        Number = digits;
    }

    public virtual string? Number { get; protected set; }

    public override string ToString()
    {
        return Number.Length == 11
            ? $"({Number[..2]}) {Number.Substring(2, 5)}-{Number[7..]}"
            : $"({Number[..2]}) {Number.Substring(2, 4)}-{Number[6..]}";
    }

    public override bool Equals(object? obj) =>
        obj is Phone other && Number == other.Number;

    public override int GetHashCode() => Number.GetHashCode();
}