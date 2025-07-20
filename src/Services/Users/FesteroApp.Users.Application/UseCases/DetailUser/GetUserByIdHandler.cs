using FesteroApp.Users.Domain.Entities.Users;
using FesteroApp.Users.Domain.Interfaces;

namespace FesteroApp.Users.Application.UseCases.DetailUser
{
    public class GetUserByIdHandler(IRepository<User> repository) : IGetUserByIdHandler
    {
        private readonly IRepository<User> _repository = repository;

        public async Task<UserDetailQueryResult?> HandleAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user is null ? null : new UserDetailQueryResult(user.Id, user.Name, user.Email);
        }
    }
}