using FluentValidation;

namespace FesteroApp.Users.Application.UseCases.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatória");
        }
    }
}