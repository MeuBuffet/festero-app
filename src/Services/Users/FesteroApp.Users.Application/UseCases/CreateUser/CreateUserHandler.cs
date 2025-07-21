using FesteroApp.Companies.Domain.Interfaces;
using FesteroApp.Users.Domain.Entities.Users;
using FesteroApp.Users.Domain.Interfaces;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Users.Application.UseCases.CreateUser
{
    public class CreateUserHandler :
     ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWorkFactory _unitOfWork;

        public CreateUserHandler(IUserRepository repository, IUnitOfWorkFactory unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(CreateUserCommand command)
        {
            var user = new User(Guid.NewGuid(), command.Name, command.Email, command.Password);

            await _repository.AddAsync(user);
    
            command.Id = user.Id;
        }
    }
}