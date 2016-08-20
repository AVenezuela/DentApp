using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DentApp.Domain.Entities;
using Microsoft.Extensions.Logging;
using DentApp.Security;
using DentApp.Application.ViewModels;
using DentApp.Application.Interfaces;

namespace DentApp.MVC.Controllers
{
    public class UserController : BaseController 
    {        
        public UserController(
            IIdentityHelper identityHelper) : base(identityHelper)
        {            
            
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            IndexUserViewModel model = new IndexUserViewModel();
            return PartialView("_Index", model);
        }


        // GET: /<controller>/
        [HttpGet]
        public IActionResult Create()
        {
            CreateUserViewModel model = new CreateUserViewModel();
            return PartialView("_Create", model);
        }
    }
}
