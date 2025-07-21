using System.ComponentModel.DataAnnotations;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Companies.Application.UseCases.UpdateCompany
{
    public class UpdateCompanyCommand : ICommand
    {
        [Required] public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}