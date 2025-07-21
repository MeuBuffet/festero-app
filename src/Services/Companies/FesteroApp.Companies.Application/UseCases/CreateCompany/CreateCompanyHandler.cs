using FesteroApp.Companies.Domain.Entities.Companies;
using FesteroApp.Companies.Domain.Interfaces;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Companies.Application.UseCases.CreateCompany
{
    public class CreateCompanyHandler(ICompanyRepository userRepository, IUnitOfWork unitOfWork) :
        ICommandHandler<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _repository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task HandleAsync(CreateCompanyCommand command)
        {
            var company = new Company(Guid.NewGuid(), command.Name);

            await _repository.AddAsync(company);

            command.Id = company.Id;
        }
    }
}