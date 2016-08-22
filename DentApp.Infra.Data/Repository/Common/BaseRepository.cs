using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DentApp.Domain.Entities;
using DentApp.Domain.Interfaces.Repository;
using DentApp.Infra.Data.Context;
using MongoDB.Driver;
using MongoDB.Bson;
using DentApp.Domain.Interfaces;

namespace DentApp.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected MongoDBContext _mongoDBContext;
        protected IMongoCollection<TEntity> _collection;        

        public BaseRepository(MongoDBContext context)
        {
            _mongoDBContext = context;            
        }

        protected void SetCollection(string collectionName)
        {
            _collection = _mongoDBContext.DataBase.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            await _collection.InsertOneAsync(obj);
            return obj;
        }
        
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> FindSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return await _collection.Find(predicate).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetById(ObjectId id)
        {            
            return await _collection.Find<TEntity>(o => (o as IEntity<TEntity>).Id == id).SingleOrDefaultAsync();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Edit(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {         
            GC.SuppressFinalize(this);
        }

        public void Delete(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
