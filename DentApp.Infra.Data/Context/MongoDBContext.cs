using MongoDB.Driver;
using DentApp.Domain.Interfaces.Data; 

namespace DentApp.Infra.Data.Context
{
    public class MongoDBContext : IMongoDBContext
    {   
        public const string DATABASE_NAME = "dentapp";
        public const string POSTS_COLLECTION_NAME = "posts";
        public const string USERS_COLLECTION_NAME = "users";

        // This is ok... Normally, they would be put into
        // an IoC container.
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static MongoDBContext()
        {            
            _client = new MongoClient();
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoDatabase DataBase
        {
            get { return _database; }
        }

        //public IMongoCollection<Post> Posts
        //{
        //    get { return _database.GetCollection<Post>(POSTS_COLLECTION_NAME); }
        //}

        //public IMongoCollection<User> Users
        //{
        //    get { return _database.GetCollection<User>(USERS_COLLECTION_NAME); }
        //}
    }
}
