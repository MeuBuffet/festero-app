using FesteroApp.Users.Application.UseCases.CreateUser;
using FesteroApp.Users.Application.UseCases.DetailUser;
using FesteroApp.Users.Application.UseCases.LoginUser;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FesteroApp.Users.Application
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