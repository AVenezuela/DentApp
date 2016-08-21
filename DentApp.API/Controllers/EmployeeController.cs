using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Interfaces.Service;
using DentApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace DentApp.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        protected IEmployeeService _userService;

        public EmployeeController(IEmployeeService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<Employee> Add(Employee model)
        {
            await _userService.Create(model);
            return model;
        }
        
        [HttpGet("{id}")]
        public async Task<Employee> Get(string id)
        {
            return await _userService.GetByID(new ObjectId(id));
        }

    }
}
