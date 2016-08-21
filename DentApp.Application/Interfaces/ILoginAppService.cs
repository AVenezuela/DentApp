using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Application.ViewModels;
using DentApp.Domain.Entities;

namespace DentApp.Application.Interfaces
{
    public interface ILoginAppService : IDisposable
    {
        Task<Employee> doLogin(LoginViewModel login);
    }
}
