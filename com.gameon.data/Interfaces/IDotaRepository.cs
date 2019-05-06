using com.gameon.data.Models;
using System.Collections.Generic;

namespace com.gameon.data.Interfaces
{
    public interface IDotaRepository : IDocumentRepository<Dota>
    {
        List<Dota> GetAll();
    }
}
