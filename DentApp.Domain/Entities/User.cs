using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentApp.Domain.Entities
{
    public class User : Entity<int>
    {
        public string Name { get; set; }
        public string eMail { get; set; }
        public Login Login { get; set; }
        public IEnumerable<Phone> PhoneNumbers { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
