using com.gameon.domain.ViewModels;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IDotaManager
    {
        DotaVM Get();
        Task<DotaVM> Create(DotaVM dotaVM);
    }
}
