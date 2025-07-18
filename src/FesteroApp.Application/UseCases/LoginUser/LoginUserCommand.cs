﻿using System.ComponentModel.DataAnnotations;

namespace FesteroApp.Application.UseCases.LoginUser
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