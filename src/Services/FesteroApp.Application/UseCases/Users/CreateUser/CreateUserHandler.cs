using FesteroApp.Domain.Entities.Organizations;
using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces.Organizations;
using FesteroApp.Domain.Interfaces.Users;
using FesteroApp.Domain.ValueObjects;
using FesteroApp.SharedKernel.Securities;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Users.CreateUser;

public class CreateUserHandler(
    IUserRepository userRepository,
    IOrganizationRepository organizationRepository,
    IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository = userRepository!;
    private readonly IOrganizationRepository _organizationRepository = organizationRepository!;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(CreateUserCommand command)
    {
        using var scope = _unitOfWork.Get(true);

        Throw.IsFalse(Document.IsValid(command.Document!), "User.Document", "Document inválido.");
        Throw.IsFalse(Document.IsValid(command.Organization!.Document!), "Organization.Document", "Document da organização inválido.");
        Throw.IsTrue(await _userRepository.HasUserByEmail(command.Email!), "User.Create", "Este e-mail já está vinculado. Verifique sua senha ou utilize um e-mail diferente para continuar.");
        Throw.IsTrue(await _userRepository.HasUserByEmail(command.Organization!.Email!), "Organization.Create", "Este e-mail já está vinculado. Verifique sua senha ou utilize um e-mail diferente para continuar.");
        
        var userEmail = new Email(command.Email!);
        var userPhone = new Phone(command.Phone!);
        var userAddress = new Address(command.Street!, command.Number!, command.Neighborhood!, command.Complement,
            command.PostalCode!, command.City!, command.State!);

        var organizationEmail = new Email(command.Organization!.Email!);
        var organizationPhone = new Phone(command.Organization!.Phone!);
        var organizationAddress = new Address(command.Organization!.Street!, command.Organization!.Number!,
            command.Organization!.Neighborhood!, command.Organization!.Complement,
            command.Organization!.PostalCode!, command.Organization!.City!, command.Organization!.State!);

        Organization? tentant = null;

        if (command.Organization.TenantId.HasValue)
        {
            tentant = await _organizationRepository.GetAsyncById(command.Organization.TenantId.Value);
            Throw.IsNull(tentant, "Organization.GetAsyncById", "Organização matriz não encontrada.");
        }

        var organization = new Organization(Guid.NewGuid(), command.Organization.LegalName, command.Organization.TradeName,
            command.Organization.Document, command.Organization.Type, command.Organization.Industry, organizationEmail, organizationPhone, organizationAddress, tentant);
        var user = new User(Guid.NewGuid(), command.Name, command.Document, command.Password, userEmail, userPhone,
            userAddress);

        await _organizationRepository.AddAsync(organization);
        
        user.AddOrganization(Roles.ADMIN, organization);
        
        await _userRepository.AddAsync(user);

        command.Id = user.Id;
        
        scope.Complete();
    }
}