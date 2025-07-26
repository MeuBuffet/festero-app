using FesteroApp.Domain.Interfaces.Organizations;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Organizations.DeleteOrganization;

public class DeleteOrganizationHandler(IOrganizationRepository organizationOrganizationRepository, IUnitOfWorkFactory unitOfWork):
    ICommandHandler<DeleteOrganizationCommand>
{
    private readonly IOrganizationRepository _organizationRepository = organizationOrganizationRepository;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(DeleteOrganizationCommand command)
    {
        var organization = await _organizationRepository.GetAsyncById(command.Id);

        organization.Delete();
            
        await _organizationRepository.UpdateAsync(organization!);
    }
}