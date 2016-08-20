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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DentApp.MVC.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILoginAppService _loginAppService;        

        public AccountController(
            ILoginAppService loginAppService,
            IIdentityHelper identityHelper): base(identityHelper)
        {
            _loginAppService = loginAppService;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login([FromQuery]string ReturnUrl)
        {
            LoginViewModel model = new LoginViewModel()
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
                User user = await _loginAppService.doLogin(loginInfo);

                if (!object.ReferenceEquals(user, null))
                {
                    var Claims = new Dictionary<string, string>()
                    {
                        ["Id"] = user.Id.ToString()
                    };
                    var principal = _identityHelper.CreatePrincipal(user.Login.UserName, "", Claims);
                    await HttpContext.Authentication.SignInAsync("DentAppCookieMiddlewareInstance", principal);
                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View(loginInfo);
        }


        public IActionResult Forbidden()
        {
            return View();
        }

        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync("DentAppCookieMiddlewareInstance");

            return RedirectToAction("Login", "Account");
        }
    }
}
