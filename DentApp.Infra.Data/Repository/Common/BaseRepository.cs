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
        protected FilterDefinition<TEntity> filter;

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
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, ProjectionDefinition<TEntity, TEntity> projection)
        {
            return await _collection.Find(predicate).Project(projection).ToListAsync();
        }

        public async Task<TEntity> FindSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return await _collection.Find(predicate).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            filter = Builders<TEntity>.Filter.Empty;
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<TEntity> GetById(ObjectId id)
        {
            filter = Builders<TEntity>.Filter.Eq("_id", id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public void Delete(string id)
        {
            filter = Builders<TEntity>.Filter.Eq("_id", id);
            _collection.DeleteOne(filter);
        }

        public async Task<TEntity> Update(TEntity obj)
        {            
            filter = Builders<TEntity>.Filter.Eq("_id", (obj as IEntity<TEntity>).Id);
            await _collection.ReplaceOneAsync(filter, obj);
            return obj;
        }

        public void Dispose()
        {         
            GC.SuppressFinalize(this);
        }

        public void Delete(TEntity obj)
        {
            //Delete((obj as IEntity<TEntity>).Id);
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
