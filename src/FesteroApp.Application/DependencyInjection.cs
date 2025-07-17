using FluentValidation;
using FesteroApp.Application.UseCases.CreateUser;
using FesteroApp.Application.UseCases.DetailUser;
using FesteroApp.Application.UseCases.LoginUser;
using Microsoft.Extensions.DependencyInjection;

namespace FesteroApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

            services.AddScoped<IGetUserByIdHandler, GetUserByIdHandler>();
            services.AddScoped<ICreateUserHandler, CreateUserHandler>();
            services.AddScoped<ILoginUserHandler, LoginUserHandler>();

            return services;
        }
    }
}