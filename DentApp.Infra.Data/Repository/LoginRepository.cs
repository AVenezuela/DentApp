using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Repository;
using DentApp.Infra.Data.Repository;
using DentApp.Infra.Data.Context;
using System.Threading.Tasks;

namespace DentApp.Infra.Data.Repository
{
    public class LoginRepository : BaseRepository<Employee>, ILoginRepository
    {
        public LoginRepository(MongoDBContext context)
            : base(context)
        {
          SetCollection("users");
        }

        public async Task<Employee> doLogin(Login login)
        {
            return await FindSingle(user => ((user.Login.UserName == login.UserName) && (user.Login.Password == login.Password) && (user.isActive)));
        }
    }
}
