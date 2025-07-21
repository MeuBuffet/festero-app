using FesteroApp.Companies.Domain.Interfaces;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Companies.Application.UseCases.UpdateCompany
{
    public class UpdateCompanyHandler(ICompanyRepository userRepository, IUnitOfWork unitOfWork):
        ICommandHandler<UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _repository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task HandleAsync(UpdateCompanyCommand command)
        {
            var company = await _repository.GetAsyncById(command.Id);

            await _repository.UpdateAsync(company!);
        }
    }
}