using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using FesteroApp.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FesteroApp.Domain.Securities;

public class JwtTokenGenerator(IConfiguration configuration) : ITokenGenerator
{
    private readonly IConfiguration _configuration = configuration;

    public string Generate(User user, List<UserCompany> companies)
    {
        var key = Encoding.ASCII.GetBytes(_configuration["Security:Secret"]!);
        var expiration = DateTime.UtcNow.AddHours(4);

        var resources = user.Companies.Select(c => new ResourcesAccess
        {
            TenantId = c.Company.Id,
            Company = c.Company.TradeName!,
            Role = c.Role.ToString(),
        }).ToList();

        var roles = companies.Select(c => c.Role.ToString()).Distinct().ToList();

        var claims = new List<Claim>
        {
            new("id", user.Id.ToString()),
            new("email", user.Email!.Address!),
            new("name", user.Name!),
            new("roles", JsonSerializer.Serialize(resources)),
            new("expiresIn", $"{expiration:yyyy-MM-ddTHH:mm:ss}")
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiration,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Security:Issuer"],
            Audience = _configuration["Security:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

        return $"Bearer {token}";
    }
}