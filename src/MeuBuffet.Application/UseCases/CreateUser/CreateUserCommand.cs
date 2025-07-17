using System.ComponentModel.DataAnnotations;

namespace MeuBuffet.Application.UseCases.CreateUser
{
    public class CreateUserCommand
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}