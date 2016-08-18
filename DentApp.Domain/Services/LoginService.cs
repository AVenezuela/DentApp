using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Service;
using DentApp.Domain.Interfaces.Repository;

namespace DentApp.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public void Dispose()
        {
            _loginRepository.Dispose();
        }

        public Task<User> doLogin(Login login)
        {
            return _loginRepository.doLogin(login);
        }
    }
}
