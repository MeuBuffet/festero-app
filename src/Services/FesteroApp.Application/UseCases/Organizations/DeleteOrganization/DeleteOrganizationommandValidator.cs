using FluentValidation;

namespace FesteroApp.Application.UseCases.Organizations.DeleteOrganization;

public class DeleteOrganizationommandValidator : AbstractValidator<DeleteOrganizationCommand>
{
    public DeleteOrganizationommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Código é obrigatório.");
    }
}