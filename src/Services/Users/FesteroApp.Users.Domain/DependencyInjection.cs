using FesteroApp.Users.Domain.Security;
using Microsoft.Extensions.DependencyInjection;

namespace FesteroApp.Users.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}