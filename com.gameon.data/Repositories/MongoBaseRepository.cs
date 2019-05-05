using com.gameon.data.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace com.gameon.data.Repositories
{
    public class MongoBaseRepository<T> : IDocumentRepository<T>
    {
        private readonly IConfiguration _config;
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<T> _collection;

        public MongoBaseRepository(IConfiguration config)
        {
            _config = config;

            var dbSettings = _config.GetSection("DbSettings");
            var connectionString = dbSettings["ConnectionString"];
            var dbName = dbSettings["DbName"];

            Connect(connectionString, dbName);

            var collectionName = typeof(T).Name;
            //CreateCollection(dbName, collectionName, "Id");
            _collection = _database.GetCollection<T>(collectionName);
        }

        private void Connect(string connectionString, string dbName)
        {
            try
            {
                _client = new MongoClient(connectionString);
                _database = _client.GetDatabase(dbName);
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while attempting to connect to database: {ex}");
            }
        }

        // Method to create collection via mongo shell in cosmos db emulator
        private void CreateCollection(string dbName, string collectionName, string shardKeyName)
        {
            //Sharded collection must be initialized this way
            var bson = new BsonDocument
            {
                { "shardCollection", dbName + "." + collectionName },
                { "key", new BsonDocument(shardKeyName, "hashed") }
            };

            var shellCommand = new BsonDocumentCommand<BsonDocument>(bson);

            try
            {
                var commandResult = _database.RunCommand(shellCommand);
            }
            catch (MongoCommandException ex)
            {
                throw new Exception($"Error while creating collection in database: {ex}");
                //logger.LogError(ex, ex.Result.ToString());
            }
        }

        // Crud Methods
        public virtual IFindFluent<T, T> GetAll()
        {
            return _collection.Find(x => true);
        }

        public IFindFluent<T, T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _collection.Find(predicate);
        }

        public async Task Create(T doc)
        {
            try
            {
                await _collection.InsertOneAsync(doc);
            }
            catch (MongoCommandException ex)
            {
                throw new Exception($"Error while creating document: {ex}");
            }
        }
    }
}
