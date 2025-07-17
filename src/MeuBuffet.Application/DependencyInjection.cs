using FluentValidation;
using MeuBuffet.Application.UseCases.CreateUser;
using MeuBuffet.Application.UseCases.DetailUser;
using MeuBuffet.Application.UseCases.LoginUser;
using Microsoft.Extensions.DependencyInjection;

namespace MeuBuffet.Application
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