using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class CreateUser
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password is not matched !!!")]
        public required string ConfirmPassword { get; set; }

        public string? UserName { get; set; }
    }
}