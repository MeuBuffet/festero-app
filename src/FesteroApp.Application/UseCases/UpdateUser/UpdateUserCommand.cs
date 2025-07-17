using System.ComponentModel.DataAnnotations;

namespace FesteroApp.Application.UseCases.UpdateUser
{
    public class UpdateUserCommand
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}