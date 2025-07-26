using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FesteroApp.SharedKernel.Securities;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Organizations.InviteUserOrganization;

public class InviteUserOrganizationCommand : ICommand
{
    [JsonIgnore] public Guid Id { get; set; }

    [Required] public string? Name { get; set; }

    [Required] public string? Document { get; set; }

    [Required] [EmailAddress] public string? Email { get; set; }
    
    [Required] public RoleTypes Role { get; set; }
}