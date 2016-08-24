using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Repository;
using DentApp.Domain.Interfaces.Service;
using MongoDB.Bson;

namespace DentApp.Domain.Services
{
    public class EmployeeService : EntityService<Employee>, IEntityService<Employee>, IEmployeeService
    {
        protected IEmployeeRepository _userRepository;

        public EmployeeService(IEmployeeRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;            
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }

        public async Task<Employee> GetAllWithoutLogin()
        {
            throw new NotImplementedException();
        }
    }
}
