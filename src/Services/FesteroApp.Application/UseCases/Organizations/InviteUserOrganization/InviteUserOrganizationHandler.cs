using FesteroApp.Application.Services;
using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces.Organizations;
using FesteroApp.Domain.Interfaces.Users;
using FesteroApp.Domain.Securities;
using FesteroApp.Domain.ValueObjects;
using FesteroApp.SharedKernel;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Organizations.InviteUserOrganization;

public class InviteUserOrganizationHandler(
    IOrganizationRepository organizationRepository,
    IUserRepository userRepository,
    IEmailService emailService,
    IPasswordGenerator passwordGenerator,
    IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<InviteUserOrganizationCommand>
{
    private readonly IOrganizationRepository _organizationRepository = organizationRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEmailService _emailService = emailService;
    private readonly IPasswordGenerator _passwordGenerator = passwordGenerator;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(InviteUserOrganizationCommand command)
    {
        using var scope = _unitOfWork.Get();

        Throw.IsTrue(await _userRepository.HasUserByEmail(command.Email!), "Invite.User",
            "Esse email já foi convidado.");
        Throw.IsTrue(await _userRepository.HasUserByDocument(command.Document!), "Invite.User",
            "Esse documento já foi convidado.");

        var organization = await _organizationRepository.GetAsyncById(command.Id);
        Throw.IsNull(organization, "Invite.User", "Organização não encontrada.");

        var user = new User(Guid.NewGuid(), command.Name, command.Document, _passwordGenerator.Generate(),
            new Email(command.Email!));

        user.AddOrganization(ToEnum.Role(command.Role), organization);

        await _userRepository.AddAsync(user);

        await _emailService.Send(command.Email!, user.Password!, command.Name!);

        scope.Complete();
    }
}