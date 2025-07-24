using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FesteroApp.Domain.Entities.Companies;
using FesteroApp.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FesteroApp.Domain.Securities;

public class JwtTokenGenerator(IConfiguration configuration) : ITokenGenerator
{
    private readonly IConfiguration _configuration = configuration;

    public string Generate(User user, Company company)
    {
        var key = Encoding.ASCII.GetBytes(_configuration["Security:Key"]!);
        var expiration = DateTime.UtcNow.AddHours(2);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!.Address!),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim("tenant_id", company.Id.ToString()),
            ]),
            Expires = expiration,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Security:Issuer"],
            Audience = _configuration["Security:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
}