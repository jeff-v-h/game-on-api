using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class LiveMatch
    {
        [JsonProperty("endpoints")]
        public List<Endpoint> Endpoints { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("opens_at")]
        public Match match { get; set; }
    }
}
