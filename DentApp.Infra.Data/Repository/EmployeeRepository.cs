using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Interfaces.Repository;
using DentApp.Domain.Entities;
using DentApp.Infra.Data.Context;
using MongoDB.Bson;

namespace DentApp.Infra.Data.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MongoDBContext context) : base(context)
        {
            SetCollection("users");
        }

        public async Task<Employee> GetByMyID(ObjectId id)
        {
            return await FindSingle(e => e.Id == id);
        }

        public Task<Employee> GetByLogin(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
