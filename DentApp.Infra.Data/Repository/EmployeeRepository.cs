using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Interfaces.Repository;
using DentApp.Domain.Entities;
using DentApp.Infra.Data.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DentApp.Infra.Data.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MongoDBContext context) : base(context)
        {
            SetCollection("users");
        }        

        public async Task<IEnumerable<Employee>> GetAllWithoutLogin(){
            var projection = Builders<Employee>.Projection.Exclude("Login");
            return await Find(emp => (!string.IsNullOrEmpty(emp.Id.ToString())), projection);
        }

        public Task<Employee> GetByLogin(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
