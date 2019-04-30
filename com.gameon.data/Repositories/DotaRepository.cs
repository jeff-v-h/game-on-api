using com.gameon.data.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace com.gameon.data.repositories
{
    public class DotaRepository
    {
        private readonly IConfiguration _config;
        private string _connectionString;
        private string _dbName;
        private string _collectionName;
        private IMongoDatabase _db;
        private IMongoCollection<Dota> _collection;

        public DotaRepository(IConfiguration config)
        {
            _config = config;

            var dbSettings = _config.GetSection("DbSettings");
            _connectionString = dbSettings["ConnectionString"];
            _dbName = dbSettings["DbName"];
            _collectionName = dbSettings["DotaCollection"];

            MongoClient client = new MongoClient(_connectionString);
            if (client != null)
            {
                _db = client.GetDatabase(_dbName);
                _collection = _db.GetCollection<Dota>(_collectionName);
            }
        }

        // Crud Methods
        // collection.Find(new BsonDocument()).ToList();
    }
}
