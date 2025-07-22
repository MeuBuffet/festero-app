using FesteroApp.Domain.Interfaces.Companies;
using FesteroApp.Domain.ValueObjects;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Companies.UpdateCompany;

public class UpdateCompanyHandler(ICompanyRepository userRepository, IUnitOfWorkFactory unitOfWork):
    ICommandHandler<UpdateCompanyCommand>
{
    private readonly ICompanyRepository _repository = userRepository;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(UpdateCompanyCommand command)
    {
        var company = await _repository.GetAsyncById(command.Id);

        var email = new Email(command.Email!);
        var phone = new Phone(command.Phone!);
        var address = new Address(command.Street!, command.Number!, command.Neighborhood!, command.Complement, command.PostalCode!, command.City!, command.State!);
        
        company.Update(company.Name, company.CorporateName, company.Document, email,  phone, address);
            
        await _repository.UpdateAsync(company!);
    }
}