using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Users.LoginUser;

public class LoginUserCommand : ICommand
{
    [Required] [EmailAddress] public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    public string? Token { get; set; }
}