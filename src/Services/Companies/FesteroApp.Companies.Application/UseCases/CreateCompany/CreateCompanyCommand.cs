using System.ComponentModel.DataAnnotations;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Companies.Application.UseCases.CreateCompany
{
    public class CreateCompanyCommand : ICommand
    {
        public Guid Id { get; set; }
        
        [Required] public string? Name { get; set; }
    }
}