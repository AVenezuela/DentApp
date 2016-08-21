using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Application.Interfaces;
using DentApp.Application.ViewModels;
using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Service;

namespace DentApp.Application
{
    public class EmployeeAppService : IEmployeeAppService
    {
        protected IEmployeeService _userService;

        public EmployeeAppService(IEmployeeService userService)
        {
            _userService = userService;
        }

        public async Task<ActionEmployeeViewModel> Add(ActionEmployeeViewModel model)
        {
            await _userService.Create(model.UserBag);
            return model;
        }

        public void Dispose()
        {
            _userService.Dispose();
        }
    }
}
