using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DentApp.Security;
using Microsoft.AspNetCore.Authorization;

namespace DentApp.MVC.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {

        public HomeController(IIdentityHelper identityHelper) : base(identityHelper)
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
