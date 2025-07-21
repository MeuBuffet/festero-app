using FesteroApp.Users.Domain.Security;
using Microsoft.Extensions.DependencyInjection;

namespace FesteroApp.Users.Domain
{
    public static class DependencyInjection
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
        }
    }
}