using FesteroApp.Users.Application.UseCases.CreateUser;
using FesteroApp.Users.Application.UseCases.LoginUser;
using FesteroApp.Users.Application.UseCases.UpdateUser;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SrShut.Cqrs.Bus;
using SrShut.Cqrs.Commands;
using SrShut.Cqrs.Requests;

namespace FesteroApp.Users.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            RegisterCommands(services);
            RegisterQueries(services);
        }

        private static void RegisterCommands(this IServiceCollection services)
        {
            services.AddSingleton<CreateUserHandler>();
            services.AddSingleton<UpdateUserHandler>();
            services.AddSingleton<LoginUserHandler>();

            services.AddSingleton<ICommandBus>(a =>
            {
                var commandBus = a.GetService<MemoryContainerBus>() ?? throw new Exception("commandBus is not found");

                var createUserHandler = a.GetService<CreateUserHandler>();
                commandBus.Register<CreateUserCommand, CreateUserCommandValidator>(createUserHandler!);

                var updateUserHandler = a.GetService<UpdateUserHandler>();
                commandBus.Register<UpdateUserCommand>(updateUserHandler!);

                var loginUserHandler = a.GetService<LoginUserHandler>();
                commandBus.Register<LoginUserCommand, LoginUserCommandValidator>(loginUserHandler!);

                return commandBus;
            });
        }

        private static void RegisterQueries(this IServiceCollection services)
        {
            // services.AddSingleton<UserQueryHandler>();

            services.AddSingleton<IRequestBus>(a =>
            {
                var queryBus = a.GetService<MemoryContainerBus>() ?? throw new Exception("queryBus is not found");
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
                return queryBus;
            });
        }
    }
}