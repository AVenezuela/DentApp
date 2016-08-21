using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Entities;
using DentApp.Application.ViewModels;

namespace DentApp.Application.Interfaces
{
    public interface IEmployeeAppService : IDisposable
    {
        Task<ActionEmployeeViewModel> Add(ActionEmployeeViewModel model);
    }
}
