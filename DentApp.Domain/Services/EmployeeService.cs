using System.Collections.Generic;
using System.Threading.Tasks;
using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Repository;
using DentApp.Domain.Interfaces.Service;

namespace DentApp.Domain.Services
{
    public class EmployeeService : EntityService<Employee>, IEntityService<Employee>, IEmployeeService
    {
        protected IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;            
        }

        public void Dispose()
        {
            _employeeRepository.Dispose();
        }

        public async Task<IEnumerable<Employee>> GetAllWithoutLogin()
        {
            return await _employeeRepository.GetAllWithoutLogin();
        }
    }
}
