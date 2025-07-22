using FesteroApp.Domain.Entities.Companies;
using FesteroApp.Domain.Interfaces.Companies;
using FesteroApp.Domain.ValueObjects;
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
        var email = new Email(command.Email!);
        var phone = new Phone(command.Phone!);
        var address = new Address(command.Street!, command.Number!, command.Neighborhood!, command.Complement, command.PostalCode!, command.City!, command.State!);
        
        var company = new Company(Guid.NewGuid(), command.Name, command.CorporateName, command.Document,  email, phone, address);

        await _repository.AddAsync(company);

        command.Id = company.Id;
    }
}