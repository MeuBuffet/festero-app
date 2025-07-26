using FesteroApp.Domain.Interfaces.Organizations;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Organizations.UpdateOrganizationConfiguration;

public class UpdateOrganizationConfigurationHandler(IOrganizationRepository userRepository, IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<UpdateOrganizationConfigurationCommand>
{
    private readonly IOrganizationRepository _repository = userRepository;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(UpdateOrganizationConfigurationCommand command)
    {
        var organization = await _repository.GetAsyncById(command.Id);
        Throw.IsNull(organization, "OrganizationConfiguration.Update", "Organização não encontrada.");

        if (command is { WorkdayStart: not null, WorkdayEnd: not null })
            organization.UpdateConfiguration(command.WorkdayStart, command.WorkdayEnd);

        await _repository.UpdateAsync(organization!);
    }
}