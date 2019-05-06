using com.gameon.domain.ViewModels;

namespace com.gameon.domain.Interfaces
{
    public interface IDotaManager
    {
        DotaVM Get(string id);
        DotaVM Create(DotaVM dotaVM);
        bool Update(string id, DotaVM dotaVM);
        bool Delete(string id);
    }
}
