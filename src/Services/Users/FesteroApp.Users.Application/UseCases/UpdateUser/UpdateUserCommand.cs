using System.ComponentModel.DataAnnotations;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Users.Application.UseCases.UpdateUser
{
    public class UpdateUserCommand : ICommand
    {
        [Required] public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}