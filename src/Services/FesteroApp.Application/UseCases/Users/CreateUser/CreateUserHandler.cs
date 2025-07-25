using FesteroApp.Domain.Entities.Companies;
using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces.Companies;
using FesteroApp.Domain.Interfaces.Users;
using FesteroApp.Domain.ValueObjects;
using FesteroApp.SharedKernel.Securities;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Users.CreateUser;

public class CreateUserHandler(
    IUserRepository userRepository,
    ICompanyRepository companyRepository,
    IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository = userRepository!;
    private readonly ICompanyRepository _companyRepository = companyRepository!;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(CreateUserCommand command)
    {
        using var scope = _unitOfWork.Get(true);

        Throw.IsTrue(await _userRepository.HasUserByEmail(command.Email!), "User.Create", "Este e-mail já está vinculado. Verifique sua senha ou utilize um e-mail diferente para continuar.");
        Throw.IsTrue(await _userRepository.HasUserByEmail(command.Company!.Email!), "Company.Create", "Este e-mail já está vinculado. Verifique sua senha ou utilize um e-mail diferente para continuar.");
        
        var userEmail = new Email(command.Email!);
        var userPhone = new Phone(command.Phone!);
        var userAddress = new Address(command.Street!, command.Number!, command.Neighborhood!, command.Complement,
            command.PostalCode!, command.City!, command.State!);

        var companyEmail = new Email(command.Company!.Email!);
        var companyPhone = new Phone(command.Company!.Phone!);
        var companyAddress = new Address(command.Company!.Street!, command.Company!.Number!,
            command.Company!.Neighborhood!, command.Company!.Complement,
            command.Company!.PostalCode!, command.Company!.City!, command.Company!.State!);

        Company? tentant = null;

        if (command.Company.TenantId.HasValue)
        {
            tentant = await _companyRepository.GetAsyncById(command.Company.TenantId.Value);
            Throw.IsNull(tentant, "Company.GetAsyncById", "Empresa matriz não encontrada.");
        }

        var company = new Company(Guid.NewGuid(), command.Company.LegalName, command.Company.TradeName,
            command.Company.Document, command.Company.Type, command.Company.Industry, companyEmail, companyPhone, companyAddress, tentant);
        var user = new User(Guid.NewGuid(), command.Name, company.Document, command.Password, userEmail, userPhone,
            userAddress);

        await _companyRepository.AddAsync(company);
        
        user.AddCompany(Roles.ADMIN, company);
        
        await _userRepository.AddAsync(user);

        command.Id = user.Id;
        
        scope.Complete();
    }
}