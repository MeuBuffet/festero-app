using FesteroApp.Companies.Domain.Interfaces;
using FesteroApp.Users.Domain.Entities.Users;
using FesteroApp.Users.Domain.Interfaces;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Users.Application.UseCases.UpdateUser
{
    public class UpdateUserHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWorkFactory _unitOfWork;

        public UpdateUserHandler(IUserRepository repository, IUnitOfWorkFactory unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(UpdateUserCommand command)
        {
            var user = await _repository.GetAsyncById(command.Id);
            Throw.IsNull(user, "User", "Usuário nao encontrado.");
            
            await _repository.UpdateAsync(user!);
        }
    }
}