using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DentApp.MVC.Controllers
{
    public class BaseController<T> : Controller
    {
        private readonly ILogger<T> _logger;

        public BaseController(
            ILogger<T> logger
            )
        {
            _logger = logger;
        }
    }
}
