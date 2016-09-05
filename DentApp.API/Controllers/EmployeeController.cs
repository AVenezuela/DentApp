using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DentApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DentApp.Application.Interfaces;

namespace DentApp.API.Controllers
{
    [ServiceFilter(typeof(InvalidModelStateFilterAttribute))]
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
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
                throw new ArgumentNullException("Operação inválida");
            
            await _userAppService.Add(model);

            return model;
        }        

        [HttpPut]
        public async Task<Employee> Update([FromBody] Employee model)
        {
            if (model == null)
                throw new ArgumentNullException("Operação inválida");
            
            await _userAppService.Update(model);

            return model;
        }        

        [HttpGet("{id}")]
        public async Task<Employee> Get(string id)
        {
            return await _userAppService.GetByID(id);
        }

        [HttpGet("")]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _userAppService.GetAll();
        }

    }
}
