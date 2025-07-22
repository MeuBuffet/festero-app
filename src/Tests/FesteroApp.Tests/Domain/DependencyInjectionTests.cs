using FesteroApp.Domain;
using FesteroApp.Domain.Securities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FesteroApp.Tests.Domain;

[TestFixture]
public class DependencyInjectionTests
{
    [Test]
    public void AddDomain_Registers_TokenGenerator_AsScoped()
    {
        var configData = new Dictionary<string, string>
        {
            { "Security:Key", "super-secret-key-1234567890" },
            { "Security:Issuer", "test-issuer" },
            { "Security:Audience", "test-audience" }
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configData!)
            .Build();

        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddDomain();
        var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();
        var service1 = scope.ServiceProvider.GetService<ITokenGenerator>();
        var service2 = scope.ServiceProvider.GetService<ITokenGenerator>();

        Assert.Multiple(() =>
        {
            Assert.That(service1, Is.Not.Null);
            Assert.That(service2, Is.Not.Null);
            Assert.That(typeof(JwtTokenGenerator), Is.EqualTo(service1!.GetType()));
        });
        Assert.That(service2, Is.SameAs(service1)); 
    }
}