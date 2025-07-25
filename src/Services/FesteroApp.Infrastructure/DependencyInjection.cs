using System.Data;
using FesteroApp.Domain.Interfaces.Companies;
using FesteroApp.Domain.Interfaces.Users;
using FesteroApp.Infrastructure.Databases.Mappings;
using FesteroApp.Infrastructure.Databases.Repositories;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using SrShut.Cache;
using SrShut.Common.Options;
using SrShut.Cqrs.Bus.DependencyInjections;
using SrShut.Cqrs.Traces.DependencyInjection;
using SrShut.Data.ConnectionStrings;
using SrShut.Data.Nhibernate;
using SrShut.Security.Core;

namespace FesteroApp.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        var nhFactory = CreateNhFactory(configuration);

        services.AddNhibernate(nhFactory);
        services.AddTrace().WithGuidProvider();
        services.AddCache(new CacheOptions(CacheType.LocalMemory));

        RegisterServices(services, configuration);
        RegisterRepositories(services);

        RegisterBus(services);
        RegisterEvents(services);
    }

    private static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettingsOptions>(configuration.GetSection("AppSettings"));
        services.Configure<SecurityOptions>(configuration.GetSection("Security"));

        services.AddTransient<HttpClientSecurityDelegatingHandler>();
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ICompanyRepository, CompanyNhRepository>();
        services.AddSingleton<IUserRepository, UserNhRepository>();
    }

    private static void RegisterBus(this IServiceCollection services)
    {
        services.AddBus(a =>
        {
            a.AddMemory();
        });
    }
        
    private static void RegisterEvents(IServiceCollection services)
    {
    }

    private static ISessionFactory CreateNhFactory(this IConfiguration configuration)
    {
        var connection = configuration.ConnectionString("DefaultConnectionString");

        return Fluently
            .Configure()
            .Database(MsSqlConfiguration.MsSql2012.IsolationLevel(IsolationLevel.ReadCommitted)
                .ShowSql()
                .ConnectionString(connection.ConnectionString))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>().Conventions.Add(DefaultLazy.Never())).BuildSessionFactory();
    }
}