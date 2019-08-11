using com.gameon.data.Database.Models;
using System.Collections.Generic;

namespace com.gameon.data.Database.Interfaces
{
    public interface IDotaRepository : IDocumentRepository<Dota>
    {
        List<Dota> GetAll();
    }
}
