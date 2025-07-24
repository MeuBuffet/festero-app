using System.ComponentModel.DataAnnotations;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Companies.DeleteCompany;

public class DeleteCompanyCommand : ICommand
{
    [Required] public Guid Id { get; set; }
}