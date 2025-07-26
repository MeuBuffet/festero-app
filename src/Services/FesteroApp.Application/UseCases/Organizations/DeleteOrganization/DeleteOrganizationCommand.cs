using System.ComponentModel.DataAnnotations;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Organizations.DeleteOrganization;

public class DeleteOrganizationCommand : ICommand
{
    [Required] public Guid Id { get; set; }
}