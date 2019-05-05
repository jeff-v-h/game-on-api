using com.gameon.data.Models;

namespace com.gameon.data.Interfaces
{
    public interface IDotaRepository : IDocumentRepository<Dota>
    {
        Dota Get(string id);
    }
}
