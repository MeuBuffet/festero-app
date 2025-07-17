using FluentValidation;

namespace MeuBuffet.Application.UseCases.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(150).WithMessage("Tamanho máximo é de 150 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatória")
                .MinimumLength(8).WithMessage("Senha deve ter no mínimo 8 caracteres")
                .MaximumLength(50).WithMessage("Senha deve ter no máximo 50 caracteres")
                .Matches("[A-Z]").WithMessage("A senha deve conter ao menos uma letra maiúscula")
                .Matches("[a-z]").WithMessage("A senha deve conter ao menos uma letra minúscula")
                .Matches("[0-9]").WithMessage("A senha deve conter ao menos um número")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter ao menos um caractere especial");
        }
    }
}