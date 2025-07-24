using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FesteroApp.Domain.Enums;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Users.CreateUser;

public class CreateUserCommand : ICommand
{
    [JsonIgnore] public Guid Id { get; set; }

    [Required] public string? Name { get; set; }

    [Required] public string? Document { get; set; }
    
    [Required] [EmailAddress] public string? Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required] [Phone] public string? Phone { get; set; }

    [Required] public string? Street { get; set; }

    [Required] public string? Number { get; set; }

    [Required] public string? Neighborhood { get; set; }

    [Required] public string? City { get; set; }

    [Required] public string? State { get; set; }

    [Required] public string? PostalCode { get; set; }

    public string? Complement { get; set; }
    
    public CreateUserCompany? Company { get; set; }

    public class CreateUserCompany
    {
        [Required] public string? LegalName { get; set; }

        [Required] public string? TradeName { get; set; }

        [Required] public string? Document { get; set; }

        [Required] public string? Type { get; set; }

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
        
        public Guid? TenantId { get; set; }
    }
}