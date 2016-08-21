using System.Threading.Tasks;
using DentApp.Domain.Entities;
using MongoDB.Bson;
using System;

namespace DentApp.Domain.Interfaces.Service
{
    public interface IEmployeeService: IEntityService<Employee>, IDisposable
    {
        Task<Employee> GetByID(ObjectId id);        
    }
}
