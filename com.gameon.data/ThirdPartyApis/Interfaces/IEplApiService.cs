using com.gameon.data.ThirdPartyApis.Models.Football;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IEplApiService
    {
        Task<List<Fixture>> GetSchedule();
        Task<List<Team>> GetTeams();
    }
}
