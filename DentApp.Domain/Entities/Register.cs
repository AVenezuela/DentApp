using System.ComponentModel.DataAnnotations;

namespace DentApp.Domain.Entities
{
    public class Register<T> : Entity<T>
    {
        [Required(ErrorMessage ="Informar o nome")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Informar o e-mail")]
        [EmailAddress(ErrorMessage ="Informar um e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informar o usuário")]
        [MaxLength(10)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informar a senha")]        
        [MinLength(8)]
        public string Password { get; set; }
    }
}
