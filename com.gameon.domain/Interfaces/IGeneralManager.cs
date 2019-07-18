using com.gameon.domain.ViewModels.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IGeneralManager
    {
        Task<List<EventVM>> GetEvents();
    }
}
