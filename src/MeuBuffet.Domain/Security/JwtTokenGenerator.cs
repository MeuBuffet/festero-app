using MeuBuffet.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeuBuffet.Domain.Security
{

    public class JwtTokenGenerator(IConfiguration configuration) : ITokenGenerator
    {
        private readonly IConfiguration _configuration = configuration;

        public string Generate(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Security:Key"]!);
            var expiration = DateTime.UtcNow.AddHours(8);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.Name!)
            ]),
                Expires = expiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Security:Issuer"],
                Audience = _configuration["Security:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            return $"Bearer {tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor))}";
        }
    }
}