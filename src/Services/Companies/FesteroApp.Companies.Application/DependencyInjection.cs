using FesteroApp.Companies.Application.UseCases.CreateCompany;
using FesteroApp.Companies.Application.UseCases.DetailCompany;
using FesteroApp.Companies.Application.UseCases.UpdateCompany;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SrShut.Cqrs.Bus;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Companies.Application
{
     public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            RegisterCommands(services);
            RegisterQueries(services);
        }
        
        private static void RegisterCommands(IServiceCollection services)
        {
            services.AddSingleton<CreateCompanyHandler>();
            services.AddSingleton<UpdateCompanyHandler>();

            services.AddSingleton<ICommandBus>(a =>
            {
                var commandBus = a.GetService<MemoryContainerBus>() ?? throw new Exception("commandBus is not found");

                var createUserHandler = a.GetService<CreateCompanyHandler>();
                commandBus.Register<CreateCompanyCommand, CreateCompanyCommandValidator>(createUserHandler!);
                
                var loginUserHandler = a.GetService<UpdateCompanyHandler>();
                commandBus.Register<UpdateCompanyCommand>(loginUserHandler!);

                return commandBus;
            });
        }
        
        private static void RegisterQueries(IServiceCollection services)
        {
            // services.AddSingleton<UserQueryHandler>();
            //
            // services.AddSingleton<IRequestBus>(a =>
            // {
            //     var queryBus = a.GetService<MemoryContainerBus>() ?? throw new Exception("queryBus is not found");
            //
            //     var productHandler = a.GetService<ProductQueryHandler>();
            //     queryBus.Register<ProductQuery, ProductQueryResult>(productHandler);
            //     queryBus.Register<ProductByIdQuery, ProductByIdQueryResult>(productHandler);
            //     queryBus.Register<ProductStockQuery, ProductStockQueryResult>(productHandler);
            //     queryBus.Register<ProductHistoryByIdQuery, ProductHistoryByIdQueryResult>(productHandler);
            //
            //     var saleHandler = a.GetService<SaleQueryHandler>();
            //     queryBus.Register<SaleQuery, SaleQueryResult>(saleHandler);
            //     queryBus.Register<SaleByIdQuery, SaleByIdQueryResult>(saleHandler);
            //
            //     var userHandler = a.GetService<UserQueryHandler>();
            //     queryBus.Register<UserQuery, UserQueryResult>(userHandler);
            //
            //     return queryBus;
            // });
        }
    }
}