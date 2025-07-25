using System.Security.Cryptography;

namespace FesteroApp.Domain.Securities;

public class PasswordGenerator : IPasswordGenerator
{
    public string Generate(int length = 12)
    {
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+[]{}|;:,.<>?";

        if (length < 8)
            throw new ArgumentException("Senha deve ter no mínimo 8 caracteres", nameof(length));

        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[length];
        rng.GetBytes(bytes);

        var chars = bytes.Select(b => valid[b % valid.Length]).ToArray();

        return new string(chars);
    }
}