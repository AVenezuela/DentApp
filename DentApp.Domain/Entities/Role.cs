using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentApp.Domain.Entities
{
    public class Role : Entity<int>
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
