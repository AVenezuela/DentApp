using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentApp.Infra.Data.Context
{
    public class MongoDBContext
    {   
        public const string DATABASE_NAME = "blog";
        public const string POSTS_COLLECTION_NAME = "posts";
        public const string USERS_COLLECTION_NAME = "users";

        // This is ok... Normally, they would be put into
        // an IoC container.
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static MongoDBContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
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
