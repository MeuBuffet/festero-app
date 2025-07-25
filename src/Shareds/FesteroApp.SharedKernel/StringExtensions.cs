namespace FesteroApp.SharedKernel;

public static class StringExtensions
{
    public static string ToCamelCase(this string value)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return char.ToLowerInvariant(value[0]) + value[1..];
    }
    
    public static (string FirstName, string LastName) SplitFullName(this string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return ("", "");

        var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return parts.Length == 1 ? (parts[0], "") : (parts[0], parts[^1]);
    }
}