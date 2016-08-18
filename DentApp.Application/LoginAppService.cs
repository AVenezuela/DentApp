using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Application.Interfaces;
using DentApp.Application.ViewModels;
using DentApp.Domain.Interfaces.Service;
using DentApp.Domain.Entities;

namespace DentApp.Application
{
    public class LoginAppService : ILoginAppService
    {
        private ILoginService _loginService;

        public LoginAppService(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<User> doLogin(LoginViewModel login)
        {   
            return await _loginService.doLogin(login.LoginBag);
        }

        public void Dispose()
        {
            _loginService.Dispose();
        }
    }
}
