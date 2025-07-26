using FesteroApp.Domain.Interfaces.Organizations;
using FesteroApp.Domain.ValueObjects;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Organizations.UpdateOrganization;

public class UpdateOrganizationHandler(IOrganizationRepository userRepository, IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<UpdateOrganizationCommand>
{
    private readonly IOrganizationRepository _repository = userRepository;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(UpdateOrganizationCommand command)
    {
        var organization = await _repository.GetAsyncById(command.Id);

        var email = new Email(command.Email!);
        var phone = new Phone(command.Phone!);
        var address = new Address(command.Street!, command.Number!, command.Neighborhood!, command.Complement,
            command.PostalCode!, command.City!, command.State!);

        organization.Update(organization.LegalName, organization.TradeName, organization.Document, command.Type, command.Industry, email,
            phone, address);

        await _repository.UpdateAsync(organization!);
    }
}