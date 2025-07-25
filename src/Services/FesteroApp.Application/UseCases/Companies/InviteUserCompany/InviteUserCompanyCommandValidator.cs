using FluentValidation;

namespace FesteroApp.Application.UseCases.Companies.InviteUserCompany;

public class InviteUserCompanyCommandValidator : AbstractValidator<InviteUserCompanyCommand>
{
    public InviteUserCompanyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(500).WithMessage("Tamanho máximo é de 500 caracteres.");
            
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress();
    }
}