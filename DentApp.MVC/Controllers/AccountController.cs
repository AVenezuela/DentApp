using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DentApp.Domain.Entities;
using Microsoft.Extensions.Logging;
using DentApp.Security;
using DentApp.MVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DentApp.MVC.Controllers
{
    public class AccountController : BaseController<HomeController>
    {
        private readonly IIdentityHelper _identityHelper;

        public AccountController(
            IIdentityHelper identityHelper,
            ILogger<HomeController> logger) : base(logger)
        {            
            _identityHelper = identityHelper;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login([FromQuery]string ReturnUrl)
        {
            LoginViewModel model = new ViewModels.LoginViewModel()
            {
                LoginBag = new Login(),
                ReturnUrl = string.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginInfo)
        {
            if (ModelState.IsValid)
            {
                var Id = 10;

                if (Id > 0)
                {
                    var Claims = new Dictionary<string, string>()
                    {
                        ["Id"] = Id.ToString()
                    };
                    var principal = _identityHelper.CreatePrincipal(loginInfo.LoginBag.UserName, "", Claims);

                    await HttpContext.Authentication.SignInAsync("DentAppCookieMiddlewareInstance", principal);
                }
            }
            else
            {
                return RedirectToAction("Forbidden", "Account");
            }

            var uri = loginInfo.ReturnUrl.Split(new char[] { '/' });
            return RedirectToAction(uri[2], uri[1]);
        }


        public IActionResult Forbidden()
        {
            return View();
        }

        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync("DentAppCookieMiddlewareInstance");

            return RedirectToAction("Index", "Home");
        }
    }
}
