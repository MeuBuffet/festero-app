using System.ComponentModel.DataAnnotations;

namespace FesteroApp.Users.Application.UseCases.LoginUser
{
    public class LoginUserCommand
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}