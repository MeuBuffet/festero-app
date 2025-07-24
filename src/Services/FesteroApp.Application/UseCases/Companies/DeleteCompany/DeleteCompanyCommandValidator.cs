using FluentValidation;

namespace FesteroApp.Application.UseCases.Companies.DeleteCompany;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Código é obrigatório.");
    }
}