using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DentApp.Domain.Entities;

namespace DentApp.Domain.Interfaces.Service
{
    public interface IEntityService<T> : IService
     where T : BaseEntity
    {
        Task<T> Create(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(T entity);
    }
}
