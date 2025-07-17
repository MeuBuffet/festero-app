using MeuBuffet.Domain.Entities.Users;
using MeuBuffet.Domain.Interfaces;

namespace MeuBuffet.Application.UseCases.DetailUser
{
    public class GetUserByIdHandler(IRepository<User> repository) : IGetUserByIdHandler
    {
        private readonly IRepository<User> _repository = repository;

        public async Task<UserDetailQueryResult?> HandleAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user is null) return null;

            return new UserDetailQueryResult(user.Id, user.Name, user.Email);
        }
    }
}