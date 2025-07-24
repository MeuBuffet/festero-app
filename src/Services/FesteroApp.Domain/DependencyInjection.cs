using FesteroApp.Domain.Securities;
using Microsoft.Extensions.DependencyInjection;

namespace FesteroApp.Domain;

public static class DependencyInjection
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
    }
}