using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class LoginUser
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}