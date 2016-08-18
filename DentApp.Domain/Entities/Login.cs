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
        public string UserName { get; set; }

        [Required(ErrorMessage ="Informar a senha")]
        public string Password { get; set; }

        public bool IsValid()
        {           
            return true;
        }
    }
}
