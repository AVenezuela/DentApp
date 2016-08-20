using MongoDB.Driver;
using DentApp.Domain.Interfaces.Data; 

namespace DentApp.Infra.Data.Context
{
    public class MongoDBContext : IMongoDBContext
    {   
        // This is ok... Normally, they would be put into
        // an IoC container.
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDBContext(MongoDBContextOptions options)
        {            
            _client = new MongoClient(options.ConnectionString);
            _database = _client.GetDatabase(options.DataBaseName);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoDatabase DataBase
        {
            get { return _database; }
        }

        public void Teste()
        {
            
        }
    }
}
