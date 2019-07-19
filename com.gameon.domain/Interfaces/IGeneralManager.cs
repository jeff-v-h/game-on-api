using com.gameon.domain.ViewModels.General;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IGeneralManager
    {
        Task<SortedEventsVM> GetEventsAsync();
    }
}
