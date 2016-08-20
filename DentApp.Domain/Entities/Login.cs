using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DentApp.Domain.Entities
{
    public class Login
    {        
        [Required(ErrorMessage ="Informar o usuário")]
        [MaxLength(10)]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Informar a senha")]
        [MinLength(8)]
        public string Password { get; set; }

        public bool NeedToChangePassword { get; set; }

        public bool IsValid()
        {           
            return true;
        }
    }
}
