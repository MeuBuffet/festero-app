using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FesteroApp.Domain.Enums;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Organizations.CreateOrganization;

public class CreateOrganizationCommand : ICommand
{
    [JsonIgnore] public Guid Id { get; set; }

    [Required] public string? LegalName { get; set; }

    [Required] public string? TradeName { get; set; }

    [Required] public string? Document { get; set; }

    [Required] public OrganizationTypes? Type { get; set; }

    [Required] public Industries? Industry { get; set; }

    [Required] [EmailAddress] public string? Email { get; set; }

    [Required] [Phone] public string? Phone { get; set; }

    [Required] public string? Street { get; set; }

    [Required] public string? Number { get; set; }

    [Required] public string? Neighborhood { get; set; }

    [Required] public string? City { get; set; }

    [Required] public string? State { get; set; }

    [Required] public string? PostalCode { get; set; }

    public string? Complement { get; set; }

    [JsonIgnore] public Guid? TenantId { get; set; }
}