using com.gameon.domain.ViewModels.Football;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IEplManager
    {
        Task<List<FixtureVM>> GetSchedule();
        Task<List<TeamVM>> GetTeams();
    }
}
