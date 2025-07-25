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
            Role = c.Role.ToString(),
        }).ToList();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!.Address!),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim("resources", JsonSerializer.Serialize(resources)),
            ]),
            Expires = expiration,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Security:Issuer"],
            Audience = _configuration["Security:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
}