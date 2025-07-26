using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FesteroApp.Domain.Securities;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Users.LoginUser;

public class LoginUserCommand : ICommand
{
    [Required] [EmailAddress] public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [JsonIgnore] public string? Token { get; set; }
}