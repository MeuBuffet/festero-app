using System.ComponentModel.DataAnnotations;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Users.Application.UseCases.CreateUser
{
    public class CreateUserCommand : ICommand
    {
        public Guid Id { get; set; }
        
        [Required] public string? Name { get; set; }

        [Required] [EmailAddress] public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}