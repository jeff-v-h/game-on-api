using com.gameon.data.Interfaces;
using com.gameon.data.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace com.gameon.data.Repositories
{
    public class DotaRepository : MongoBaseRepository<Dota>, IDotaRepository
    {
        public DotaRepository(IConfiguration config) : base(config) { }

        public Dota Get(string id)
        {
            return GetBy(doc => doc.Id == id).FirstOrDefault();
        }
    }
}
