using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace DentApp.Domain.Interfaces.Repository
{
    public interface ILoginRepository : IBaseRepository<Employee>
    {
        Task<Employee> doLogin(Login login);
    }
}
