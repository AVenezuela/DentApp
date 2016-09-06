using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DentApp.Domain.Entities;
using Microsoft.Extensions.Logging;
using DentApp.Security;
using DentApp.Application.ViewModels;
using DentApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace DentApp.MVC.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(InvalidModelStateFilterAttribute))]
    public class EmployeeController : BaseController 
    {
        protected IEmployeeAppService _userAppService;

        public EmployeeController(
            IEmployeeAppService userAppService,
            IIdentityHelper identityHelper) : base(identityHelper)
        {
            _userAppService = userAppService;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            IndexEmployeeViewModel model = new IndexEmployeeViewModel();
            return PartialView("_Index", model);
        }


        // GET: /<controller>/
        [HttpGet]
        public IActionResult Action()
        {
            ActionEmployeeViewModel model = new ActionEmployeeViewModel();
            return PartialView("_Action", model);
        }

        [HttpPost]
        [Route("/api/employee/post")]
        public async Task<Employee> Create([FromBody] Employee model)
        {
            if (model == null)
                throw new ArgumentNullException("Operação inválida");

            await _userAppService.Add(model);

            return model;
        }

        [HttpPut]
        [Route("/api/employee/post")]
        public async Task<Employee> Update([FromBody] Employee model)
        {
            if (model == null)
                throw new ArgumentNullException("Operação inválida");

            await _userAppService.Update(model);

            return model;
        }

        [HttpGet("{id}")]
        [Route("/api/employee/get")]
        public async Task<Employee> Get(string id)
        {
            return await _userAppService.GetByID(id);
        }

        [HttpGet("")]
        [Route("/api/employee/getall")]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _userAppService.GetAll();
        }
    }
}
