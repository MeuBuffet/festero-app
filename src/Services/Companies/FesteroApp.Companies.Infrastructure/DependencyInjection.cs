using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FesteroApp.Companies.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {

            return services;
        }
    }
}