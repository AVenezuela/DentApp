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
    public class EmployeeController : BaseController 
    {        
        public EmployeeController(
            IIdentityHelper identityHelper) : base(identityHelper)
        {            
            
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            IndexEmployeeViewModel model = new IndexEmployeeViewModel();
            return PartialView("_Index", model);
        }


        // GET: /<controller>/
        [HttpGet]
        public IActionResult Action()
        {
            ActionEmployeeViewModel model = new ActionEmployeeViewModel();
            return PartialView("_Action", model);
        }
    }
}
