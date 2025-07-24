using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Companies.CreateCompany;

public class CreateCompanyCommand : ICommand
{
    [JsonIgnore]
    public Guid Id { get; set; }

    [Required] public string? Name { get; set; }

    [Required] public string? CorporateName { get; set; }

    [Required] public string? Document { get; set; }

    [Required] public string? Email { get; set; }

    [Required] public string? Phone { get; set; }

    [Required] public string? Street { get; set; }

    [Required] public string? Number { get; set; }

    [Required] public string? Neighborhood { get; set; }

    [Required] public string? City { get; set; }

    [Required] public string? State { get; set; }

    [Required] public string? PostalCode { get; set; }

    public string? Complement { get; set; }
    
    [JsonIgnore] public Guid? TenantId { get; set; }
}