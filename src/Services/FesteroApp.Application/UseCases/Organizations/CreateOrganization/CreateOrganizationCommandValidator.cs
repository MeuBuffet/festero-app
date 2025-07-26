using FluentValidation;

namespace FesteroApp.Application.UseCases.Organizations.CreateOrganization;

public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationCommandValidator()
    {
        RuleFor(x => x.LegalName)
            .NotEmpty().WithMessage("Razao social é obrigatório.")
            .MaximumLength(500).WithMessage("Tamanho máximo é de 500 caracteres.");
            
        RuleFor(x => x.TradeName)
            .NotEmpty().WithMessage("Nome fantasia é obrigatório.")
            .MaximumLength(500).WithMessage("Tamanho máximo é de 500 caracteres.");
            
        RuleFor(x => x.Document)
            .NotEmpty().WithMessage("Documento é obrigatório.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress();
        
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefone é obrigatório.")
            .MinimumLength(10);
        
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Endereço é obrigatório.");
        
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("Cidade é obrigatória.");
        
        RuleFor(x => x.State)
            .NotEmpty().WithMessage("UF é obrigatório.")
            .Length(2).WithMessage("Tamanho do UF é de 2 caracteres.");
        
        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("CEP é obrigatório.")
            .Length(8).WithMessage("Tamanho do CEP é de 8 caracteres.");
    }
}