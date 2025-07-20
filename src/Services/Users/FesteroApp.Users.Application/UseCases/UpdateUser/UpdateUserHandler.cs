using FesteroApp.Users.Domain.Entities.Users;
using FesteroApp.Users.Domain.Interfaces;

namespace FesteroApp.Users.Application.UseCases.UpdateUser
{
    public class UpdateUserHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
    {
        private readonly IRepository<User> _repository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> HandleAsync(UpdateUserCommand command)
        {
            var user = await _repository.GetByIdAsync(command.Id);

            await _repository.UpdateAndCommitAsync(user!);

            return user!.Id;
        }
    }
}