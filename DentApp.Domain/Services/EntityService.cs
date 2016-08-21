using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Repository;
using DentApp.Domain.Interfaces.Service;

namespace DentApp.Domain.Services
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repository;

        public EntityService(IBaseRepository<T> repository)
        {            
            _repository = repository;
        }

        public async Task<T> Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _repository.Add(entity);
            return entity;
        }


        public async Task<T> Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            await _repository.Edit(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
