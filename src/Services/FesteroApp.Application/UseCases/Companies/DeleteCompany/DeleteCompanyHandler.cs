using FesteroApp.Domain.Interfaces.Companies;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Companies.DeleteCompany;

public class DeleteCompanyHandler(ICompanyRepository companyCompanyRepository, IUnitOfWorkFactory unitOfWork):
    ICommandHandler<DeleteCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository = companyCompanyRepository;
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(DeleteCompanyCommand command)
    {
        var company = await _companyRepository.GetAsyncById(command.Id);

        company.Delete();
            
        await _companyRepository.UpdateAsync(company!);
    }
}