using FesteroApp.Users.Domain.Interfaces;
using FesteroApp.Users.Domain.Security;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Users.Application.UseCases.LoginUser
{
    public class LoginUserHandler : ICommandHandler<LoginUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWorkFactory _unitOfWork;
        private readonly ITokenGenerator _token;

        public LoginUserHandler(IUserRepository repository, IUnitOfWorkFactory unitOfWork, ITokenGenerator token)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _token = token;
        }

        public async Task HandleAsync(LoginUserCommand command)
        {
            Throw.IsFalse(await _repository.IsCredentialsValid(command.Email!, command.Password), "User.Login",
                "Usuário e/ou senha incorretas.");

            var user = await _repository.GetAsyncByEmail(command.Email!);
            var token = _token.Generate(user);

            command.Token = token;
        }
    }
}