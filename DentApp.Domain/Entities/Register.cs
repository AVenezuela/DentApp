using System.ComponentModel.DataAnnotations;

namespace DentApp.Domain.Entities
{
    public class Register<T> : Entity<T>
    {
        
        public string Name { get; set; }

        
        public string Email { get; set; }

        [Required(ErrorMessage = "Informar o usuário")]
        [MaxLength(10)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informar a senha")]        
        [MinLength(8)]
        public string Password { get; set; }
    }
}
