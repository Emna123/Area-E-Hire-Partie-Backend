using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class RegisterModel
    {
        [Required (ErrorMessage = "User name is required !")]
        public string username { get; set; }

        [Required (ErrorMessage = "Email  is required !")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required !")]
        public string password { get; set; }

    }
}
