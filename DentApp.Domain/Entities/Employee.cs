using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentApp.Domain.Entities
{
    public class Employee : Entity<int>
    {
        [Required(ErrorMessage = "Informar o nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informar o e-mail")]
        [EmailAddress(ErrorMessage = "Informar um e-mail válido")]
        public string Email { get; set; }

        public Login Login { get; set; }

        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public string Additional { get; set; }
        public bool isActive { get; set; }
    }
}
