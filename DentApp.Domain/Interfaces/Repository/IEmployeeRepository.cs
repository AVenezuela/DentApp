using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using DentApp.Domain.Entities;

namespace DentApp.Domain.Interfaces.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> GetByLogin(Login login);
        Task<Employee> GetByMyID(ObjectId id);
    }
}
