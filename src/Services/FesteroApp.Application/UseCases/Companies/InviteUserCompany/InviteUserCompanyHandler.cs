using FesteroApp.Application.Services;
using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces.Companies;
using FesteroApp.Domain.Interfaces.Users;
using FesteroApp.Domain.Securities;
using FesteroApp.Domain.ValueObjects;
using FesteroApp.SharedKernel;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Companies.InviteUserCompany;

public class InviteUserCompanyHandler(
    ICompanyRepository companyRepository,
    IUserRepository userRepository,
    IEmailService emailService,
    IPasswordGenerator passwordGenerator,
    IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<InviteUserCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository = companyRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEmailService _emailService = emailService;
    private readonly IPasswordGenerator _passwordGenerator = passwordGenerator;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(InviteUserCompanyCommand command)
    {
        using var scope = _unitOfWork.Get();

        Throw.IsTrue(await _userRepository.HasUserByEmail(command.Email!), "Invite.User",
            "Esse email já foi convidado.");
        Throw.IsTrue(await _userRepository.HasUserByDocument(command.Document!), "Invite.User",
            "Esse documento já foi convidado.");

        var company = await _companyRepository.GetAsyncById(command.Id);
        Throw.IsNull(company, "Invite.User", "Empresa não encontrada.");

        var user = new User(Guid.NewGuid(), command.Name, command.Document, _passwordGenerator.Generate(),
            new Email(command.Email!));

        user.AddCompany(ToEnum.Role(command.Role), company);

        await _userRepository.AddAsync(user);

        await _emailService.Send(command.Email!, user.Password!, command.Name!);

        scope.Complete();
    }
}