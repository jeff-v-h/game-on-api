using com.gameon.domain.ViewModels;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IDotaManager
    {
        DotaVM Get(string id);
        Task<DotaVM> Create(DotaVM dotaVM);
        bool Update(DotaVM dotaVM);
    }
}
