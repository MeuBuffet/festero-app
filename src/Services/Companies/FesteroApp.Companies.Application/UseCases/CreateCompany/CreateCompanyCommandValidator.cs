using FluentValidation;

namespace FesteroApp.Companies.Application.UseCases.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(500).WithMessage("Tamanho máximo é de 500 caracteres.");
        }
    }
}