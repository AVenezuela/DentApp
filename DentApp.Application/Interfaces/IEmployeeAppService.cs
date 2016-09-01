using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DentApp.Domain.Entities;

namespace DentApp.Application.Interfaces
{
    public interface IEmployeeAppService : IDisposable
    {
        Task<Employee> Add(Employee model);
        Task<Employee> GetByID(string id);
        Task<IEnumerable<Employee>> GetAll();
    }
}
