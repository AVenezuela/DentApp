using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Application.Interfaces;
using DentApp.Application.ViewModels;
using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Service;
using MongoDB.Bson;

namespace DentApp.Application
{
    public class EmployeeAppService : IEmployeeAppService
    {
        protected IEmployeeService _userService;

        public EmployeeAppService(IEmployeeService userService)
        {
            _userService = userService;
        }

        public async Task<Employee> GetByID(string id)
        {
            return await _userService.GetById(new ObjectId(id));
        }

        public async Task<ActionEmployeeViewModel> Add(ActionEmployeeViewModel model)
        {
            await _userService.Add(model.EmployeeBag);
            return model;
        }

        public void Dispose()
        {
            _userService.Dispose();
        }
    }
}
