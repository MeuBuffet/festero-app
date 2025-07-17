using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces;
using FesteroApp.Domain.Security;

namespace FesteroApp.Application.UseCases.LoginUser
{
    public class LoginUserHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork, ITokenGenerator token) : ILoginUserHandler
    {
        private readonly IRepository<User> _repository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITokenGenerator _token = token;

        public async Task<string> HandleAsync(LoginUserCommand command)
        {
            var user = await _repository.GetByAsync<User>(u => u.Email == command.Email
                                                            && u.Password == command.Password);

            if (user is null)
                return string.Empty;

            var token = _token.Generate(user);

            return token;
        }
    }
}