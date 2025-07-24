using System.ComponentModel.DataAnnotations;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Application.UseCases.Users.DeleteUser;

public class DeleteUserCommand : ICommand
{
    [Required] public Guid Id { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}