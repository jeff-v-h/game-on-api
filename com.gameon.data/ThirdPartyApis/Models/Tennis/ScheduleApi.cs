using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class ScheduleApi : ApiBase
    {
        [JsonProperty("tournament")]
        public TennisTournament Tournament { get; set; }

        [JsonProperty("sport_events")]
        public List<SportEvent> SportEvents { get; set; }
    }
}
