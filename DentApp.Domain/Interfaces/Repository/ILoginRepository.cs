using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace DentApp.Domain.Interfaces.Repository
{
    public interface ILoginRepository : IBaseRepository<User>
    {
        Task<User> doLogin(Login login);
    }
}
