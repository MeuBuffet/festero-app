using FluentValidation;

namespace FesteroApp.Application.UseCases.Organizations.InviteUserOrganization;

public class InviteUserOrganizationCommandValidator : AbstractValidator<InviteUserOrganizationCommand>
{
    public InviteUserOrganizationCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(500).WithMessage("Tamanho máximo é de 500 caracteres.");
            
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress();
    }
}