using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Entities;

namespace DentApp.Application.ViewModels
{
    public class IndexUserViewModel
    {
        public IEnumerable<User> ListUserBag { get; set; }
    }

    public class CreateUserViewModel
    {
        public User UserBag { get; set; }
    }
}
