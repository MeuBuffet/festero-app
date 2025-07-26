using FesteroApp.Application.Services;
using FesteroApp.Application.UseCases.Organizations.CreateOrganization;
using FesteroApp.Application.UseCases.Organizations.DeleteOrganization;
using FesteroApp.Application.UseCases.Organizations.GetOrganization;
using FesteroApp.Application.UseCases.Organizations.GetUserByOrganization;
using FesteroApp.Application.UseCases.Organizations.InviteUserOrganization;
using FesteroApp.Application.UseCases.Organizations.UpdateOrganization;
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
        services.AddSingleton<CreateOrganizationHandler>();
        services.AddSingleton<UpdateOrganizationHandler>();
        services.AddSingleton<DeleteOrganizationHandler>();
        services.AddSingleton<InviteUserOrganizationHandler>();
        
        services.AddSingleton<CreateUserHandler>();
        services.AddSingleton<UpdateUserHandler>();
        services.AddSingleton<DeleteUserHandler>();
        
        services.AddSingleton<LoginUserHandler>();

        services.AddSingleton<ICommandBus>(a =>
        {
            var commandBus = a.GetService<MemoryContainerBus>() ?? throw new Exception("commandBus is not found");

            var createOrganizationHandler = a.GetService<CreateOrganizationHandler>();
            commandBus.Register<CreateOrganizationCommand, CreateOrganizationCommandValidator>(createOrganizationHandler!);

            var updateOrganizationHandler = a.GetService<UpdateOrganizationHandler>();
            commandBus.Register<UpdateOrganizationCommand, UpdateOrganizationCommandValidator>(updateOrganizationHandler!);

            var deleteOrganizationHandler = a.GetService<DeleteOrganizationHandler>();
            commandBus.Register<DeleteOrganizationCommand, DeleteOrganizationommandValidator>(deleteOrganizationHandler!);
            
            var inviteUserOrganizationHandler = a.GetService<InviteUserOrganizationHandler>();
            commandBus.Register<InviteUserOrganizationCommand, InviteUserOrganizationCommandValidator>(inviteUserOrganizationHandler!);
            
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
        services.AddSingleton<GetOrganizationQueryHandler>();
        services.AddSingleton<GetUserByOrganizationQueryHandler>();
        
        services.AddSingleton<GetUserQueryHandler>();
        services.AddSingleton<GetDetailUserQueryHandler>();

        services.AddSingleton<IRequestBus>(a =>
        {
            var queryBus = a.GetService<MemoryContainerBus>() ?? throw new Exception("queryBus is not found");

            var getOrganizationQueryHandler = a.GetService<GetOrganizationQueryHandler>();
            queryBus.Register<GetOrganizationQuery, GetOrganizationQueryResult>(getOrganizationQueryHandler!);

            var getUserByOrganizationQueryHandler = a.GetService<GetUserByOrganizationQueryHandler>();
            queryBus.Register<GetUserByOrganizationQuery, GetUserByOrganizationQueryResult>(getUserByOrganizationQueryHandler!);
            
            var getUserQueryHandler = a.GetService<GetUserQueryHandler>();
            queryBus.Register<GetUserQuery, GetUserQueryResult>(getUserQueryHandler!);
            
            var getDetailUserQueryHandler = a.GetService<GetDetailUserQueryHandler>();
            queryBus.Register<GetDetailUserQuery, GetDetailUserQueryResult>(getDetailUserQueryHandler!);
            
            return queryBus;
        });
    }
}