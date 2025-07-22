using FluentValidation;

namespace FesteroApp.Application.UseCases.Users.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
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