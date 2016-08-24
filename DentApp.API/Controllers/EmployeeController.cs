using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DentApp.Application;
using DentApp.Application.Interfaces;
using DentApp.Application.ViewModels;

namespace DentApp.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        protected IEmployeeAppService _userAppService;

        public EmployeeController(IEmployeeAppService userAppService)
        {
            _userAppService = userAppService;
        }


        [HttpPost]
        public async Task<ActionEmployeeViewModel> Add(ActionEmployeeViewModel model)
        {
            await _userAppService.Add(model);
            return model;
        }
        
        [HttpGet("{id}")]
        public async Task<Employee> Get(string id)
        {
            return await _userAppService.GetByID(id);
        }

    }
}
