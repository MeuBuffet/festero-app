using FesteroApp.Application.Services;
using FesteroApp.Application.UseCases.Companies.CreateCompany;
using FesteroApp.Application.UseCases.Companies.DeleteCompany;
using FesteroApp.Application.UseCases.Companies.GetCompany;
using FesteroApp.Application.UseCases.Companies.GetUserByCompany;
using FesteroApp.Application.UseCases.Companies.InviteUserCompany;
using FesteroApp.Application.UseCases.Companies.UpdateCompany;
using FesteroApp.Application.UseCases.Users.CreateUser;
using FesteroApp.Application.UseCases.Users.DeleteUser;
using FesteroApp.Application.UseCases.Users.GetDetailUser;
using FesteroApp.Application.UseCases.Users.GetUser;
using FesteroApp.Application.UseCases.Users.LoginUser;
using FesteroApp.Application.UseCases.Users.UpdateUser;
using Microsoft.Extensions.DependencyInjection;
using SrShut.Cqrs.Bus;
using SrShut.Cqrs.Commands;
using SrShut.Cqrs.Requests;
using CreateCompanyCommandValidator = FesteroApp.Application.UseCases.Companies.CreateCompany.CreateCompanyCommandValidator;

namespace FesteroApp.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IEmailService, EmailService>();
        
        RegisterCommands(services);
        RegisterQueries(services);
    }

    private static void RegisterCommands(this IServiceCollection services)
    {
        services.AddSingleton<CreateCompanyHandler>();
        services.AddSingleton<UpdateCompanyHandler>();
        services.AddSingleton<DeleteCompanyHandler>();
        services.AddSingleton<InviteUserCompanyHandler>();
        
        services.AddSingleton<CreateUserHandler>();
        services.AddSingleton<UpdateUserHandler>();
        services.AddSingleton<DeleteUserHandler>();
        
        services.AddSingleton<LoginUserHandler>();

        services.AddSingleton<ICommandBus>(a =>
        {
            var commandBus = a.GetService<MemoryContainerBus>() ?? throw new Exception("commandBus is not found");

            var createCompanyHandler = a.GetService<CreateCompanyHandler>();
            commandBus.Register<CreateCompanyCommand, CreateCompanyCommandValidator>(createCompanyHandler!);

            var updateCompanyHandler = a.GetService<UpdateCompanyHandler>();
            commandBus.Register<UpdateCompanyCommand, UpdateCompanyCommandValidator>(updateCompanyHandler!);

            var deleteCompanyHandler = a.GetService<DeleteCompanyHandler>();
            commandBus.Register<DeleteCompanyCommand, DeleteCompanyCommandValidator>(deleteCompanyHandler!);
            
            var inviteUserCompanyHandler = a.GetService<InviteUserCompanyHandler>();
            commandBus.Register<InviteUserCompanyCommand, InviteUserCompanyCommandValidator>(inviteUserCompanyHandler!);
            
            var createUserHandler = a.GetService<CreateUserHandler>();
            commandBus.Register<CreateUserCommand, CreateUserCommandValidator>(createUserHandler!);

            var updateUserHandler = a.GetService<UpdateUserHandler>();
            commandBus.Register<UpdateUserCommand, UpdateUserCommandValidator>(updateUserHandler!);

            var deleteUserHandler = a.GetService<DeleteUserHandler>();
            commandBus.Register<DeleteUserCommand, DeleteUserCommandValidator>(deleteUserHandler!);
            
            var loginUserHandler = a.GetService<LoginUserHandler>();
            commandBus.Register<LoginUserCommand, LoginUserCommandValidator>(loginUserHandler!);
            
            return commandBus;
        });
    }

    private static void RegisterQueries(this IServiceCollection services)
    {
        services.AddSingleton<GetCompanyQueryHandler>();
        services.AddSingleton<GetUserByCompanyQueryHandler>();
        
        services.AddSingleton<GetUserQueryHandler>();
        services.AddSingleton<GetDetailUserQueryHandler>();

        services.AddSingleton<IRequestBus>(a =>
        {
            var queryBus = a.GetService<MemoryContainerBus>() ?? throw new Exception("queryBus is not found");

            var getCompanyQueryHandler = a.GetService<GetCompanyQueryHandler>();
            queryBus.Register<GetCompanyQuery, GetCompanyQueryResult>(getCompanyQueryHandler!);

            var getUserByCompanyQueryHandler = a.GetService<GetUserByCompanyQueryHandler>();
            queryBus.Register<GetUserByCompanyQuery, GetUserByCompanyQueryResult>(getUserByCompanyQueryHandler!);
            
            var getUserQueryHandler = a.GetService<GetUserQueryHandler>();
            queryBus.Register<GetUserQuery, GetUserQueryResult>(getUserQueryHandler!);
            
            var getDetailUserQueryHandler = a.GetService<GetDetailUserQueryHandler>();
            queryBus.Register<GetDetailUserQuery, GetDetailUserQueryResult>(getDetailUserQueryHandler!);
            
            return queryBus;
        });
    }
}