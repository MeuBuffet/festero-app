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

    public CurrentUserToken Generate(User user, List<UserCompany> companies)
    {
        var key = Encoding.ASCII.GetBytes(_configuration["Security:Secret"]!);
        var expiration = DateTime.UtcNow.AddHours(4);

        var resources = user.Companies.Select(c => new ResourcesAccess
        {
            TenantId = c.Company.Id,
            Role = c.Role.ToString(),
        }).ToList();

        var roles = companies.Select(c => c.Role.ToString()).Distinct().ToList();

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email!.Address!),
            new(ClaimTypes.Name, user.Name!),
            new("resources", JsonSerializer.Serialize(resources))
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

        return new CurrentUserToken
        {
            Id = user.Id,
            Name = user.Name!,
            Email = user.Email!.Address!,
            Token = $"Bearer {token}",
            ExpireIn = expiration,
            Roles = roles
        };
    }
}