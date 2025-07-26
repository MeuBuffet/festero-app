using FesteroApp.Domain.Entities.Organizations;
using FesteroApp.Domain.Interfaces.Organizations;
using FesteroApp.Domain.ValueObjects;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Organizations.CreateOrganization;

public class CreateOrganizationHandler(IOrganizationRepository userRepository, IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<CreateOrganizationCommand>
{
    private readonly IOrganizationRepository _repository = userRepository;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(CreateOrganizationCommand command)
    {
        Throw.IsFalse(Document.IsValid(command.Document!), "Organization.Document", "Document inválido.");

        using var scope = _unitOfWork.Get(true);

        if (await _repository.HasOrganizationByDocument(command.Document))
            scope.Complete();

        var email = new Email(command.Email!);
        var phone = new Phone(command.Phone!);
        var address = new Address(command.Street!, command.Number!, command.Neighborhood!, command.Complement,
            command.PostalCode!, command.City!, command.State!);

        Organization? parent = null;

        if (command.TenantId.HasValue)
        {
            parent = await _repository.GetAsyncById(command.TenantId.Value);
            Throw.IsNull(parent, "Organization.Create", "Organização matriz não encontrada.");
        }

        var organization = new Organization(Guid.NewGuid(), command.LegalName, command.TradeName, command.Document,
            command.Type,
            command.Industry, email, phone, address, parent);

        await _repository.AddAsync(organization);

        command.Id = organization.Id;

        scope.Complete();
    }
}