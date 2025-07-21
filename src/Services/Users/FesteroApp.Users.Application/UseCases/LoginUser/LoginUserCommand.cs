using System.ComponentModel.DataAnnotations;
using SrShut.Cqrs.Commands;

namespace FesteroApp.Users.Application.UseCases.LoginUser
{
    public class LoginUserCommand : ICommand
    {
        [Required] [EmailAddress] public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        public string? Token { get; set; }
    }
}