using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DentApp.Application;
using DentApp.Application.Interfaces;
using DentApp.Application.ViewModels;
using Microsoft.AspNetCore.Cors;

namespace DentApp.API.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        protected IEmployeeAppService _userAppService;

        public EmployeeController(IEmployeeAppService userAppService)
        {
            _userAppService = userAppService;
        }


        [HttpPost]
        public async Task<Employee> Create([FromBody] Employee model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Operação inválida");
            }

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
