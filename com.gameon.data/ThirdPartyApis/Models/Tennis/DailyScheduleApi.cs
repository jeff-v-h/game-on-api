using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class DailyScheduleApi : ApiBase
    {
        [JsonProperty("sport_events")]
        public List<SportEvent> SportEvents { get; set; }
    }
}
