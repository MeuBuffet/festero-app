using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Securities;

namespace FesteroApp.Tests.Domain.Security;

[TestFixture]
public class JwtTokenGeneratorTests
{
    private JwtTokenGenerator _tokenGenerator = null!;
    private IConfiguration _configuration = null!;

    [SetUp]
    public void Setup()
    {
        var configData = new Dictionary<string, string>
        {
            { "Security:Key", "super-secret-key-jwt-1234567890123456" },
            { "Security:Issuer", "FesteroIssuer" },
            { "Security:Audience", "FesteroAudience" }
        };

        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configData!)
            .Build();

        _tokenGenerator = new JwtTokenGenerator(_configuration);
    }

    [Test]
    public void GenerateToken_ShouldIncludeUserClaims_AndBeReadable()
    {
        var user = new User(Guid.NewGuid(), "João da Silva", "joao@email.com", "Senha123!");
        var token = _tokenGenerator.Generate(user);

        Assert.That(token, Is.Not.Null);

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        Assert.Multiple(() =>
        {
            Assert.That(jwt.Claims.First(c => c.Type == "nameid").Value, Is.EqualTo(user.Id.ToString()));
            Assert.That(jwt.Claims.First(c => c.Type == "email").Value, Is.EqualTo(user.Email));
            Assert.That(jwt.Claims.First(c => c.Type == "unique_name").Value, Is.EqualTo(user.Name));
            Assert.That(jwt.Issuer, Is.EqualTo("FesteroIssuer"));
            Assert.That(jwt.Audiences.First(), Is.EqualTo("FesteroAudience"));
        });
    }
}