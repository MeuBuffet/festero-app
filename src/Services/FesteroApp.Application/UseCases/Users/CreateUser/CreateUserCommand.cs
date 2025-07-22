using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Users.CreateUser;

public class CreateUserCommand : ICommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
        
    [Required] public string? Name { get; set; }

    [Required] [EmailAddress] public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}