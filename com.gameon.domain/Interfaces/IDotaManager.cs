using com.gameon.domain.ViewModels.Dota2;
using System.Collections.Generic;

namespace com.gameon.domain.Interfaces
{
    public interface IDotaManager
    {
        List<DotaVM> GetAll();
        DotaVM Get(string id);
        DotaVM Create(DotaVM dotaVM);
        bool Update(string id, DotaVM dotaVM);
        bool Delete(string id);
    }
}
