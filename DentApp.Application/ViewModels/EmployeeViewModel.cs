using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Entities;

namespace DentApp.Application.ViewModels
{
    public class IndexEmployeeViewModel
    {
        public IEnumerable<Employee> ListUserBag { get; set; }
    }

    public class ActionEmployeeViewModel
    {
        public Employee UserBag { get; set; }
    }
}
