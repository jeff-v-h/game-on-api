using com.gameon.domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IDotaManager
    {
        Task<List<DotaVM>> GetAll();
        DotaVM Get(string id);
        DotaVM Create(DotaVM dotaVM);
        bool Update(string id, DotaVM dotaVM);
        bool Delete(string id);
    }
}
