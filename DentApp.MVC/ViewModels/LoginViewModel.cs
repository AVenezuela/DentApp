using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Interfaces;
using DentApp.Domain.Entities;

namespace DentApp.MVC.ViewModels
{
    public class LoginViewModel
    {
        public Login LoginBag { get; set; }

        public bool RemindMe { get; set; }        
        public string ReturnUrl { get; set; }
    }
}
