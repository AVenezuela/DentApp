using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Entities;

namespace DentApp.Domain.Interfaces.Service
{
    public interface ILoginService : IDisposable
    {
        Task<User> doLogin(Login login);
    }
}
