using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class Stage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("competitors")]
        public List<TennisCompetitor> Competitors { get; set; }

        [JsonProperty("number_of_scheduled_matches")]
        public int? NumberOfScheduledMatches { get; set; }
    }
}
