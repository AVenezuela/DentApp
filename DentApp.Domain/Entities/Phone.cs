using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentApp.Domain.Entities
{
    public class Phone : Entity<int>
    {
        public string Number { get; set; }
        public bool isDefault { get; set; }
    }
}
