using MeuBuffet.Domain.Security;
using Microsoft.Extensions.DependencyInjection;

namespace MeuBuffet.Domain
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