using com.gameon.data.ThirdPartyApis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IDotaApiService
    {
        Task<IEnumerable<ProMatch>> GetSchedule();
    }
}
