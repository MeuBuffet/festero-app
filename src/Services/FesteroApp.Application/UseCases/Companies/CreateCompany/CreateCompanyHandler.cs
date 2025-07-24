using FesteroApp.Domain.Entities.Companies;
using FesteroApp.Domain.Interfaces.Companies;
using FesteroApp.Domain.ValueObjects;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Companies.CreateCompany;

public class CreateCompanyHandler(ICompanyRepository userRepository, IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<CreateCompanyCommand>
{
    private readonly ICompanyRepository _repository = userRepository;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(CreateCompanyCommand command)
    {
        using var scope = _unitOfWork.Get(true);

        var email = new Email(command.Email!);
        var phone = new Phone(command.Phone!);
        var address = new Address(command.Street!, command.Number!, command.Neighborhood!, command.Complement,
            command.PostalCode!, command.City!, command.State!);

        Company? parent = null;

        if (command.TenantId.HasValue)
        {
            parent = await _repository.GetAsyncById(command.TenantId.Value);
            Throw.IsNull(parent, "Company.Create", "Empresa matriz não encontrada.");
        }

        var company = new Company(Guid.NewGuid(), command.LegalName, command.TradeName, command.Document, command.Type,
            command.Industry, email, phone, address, parent);

        await _repository.AddAsync(company);

        command.Id = company.Id;

        scope.Complete();
    }
}