using System.Threading.Tasks;
using DentApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DentApp.Domain.Interfaces.Service
{
    public interface IEmployeeService: IEntityService<Employee>, IDisposable
    {
        Task<IEnumerable<Employee>> GetAllWithoutLogin();        
    }
}
