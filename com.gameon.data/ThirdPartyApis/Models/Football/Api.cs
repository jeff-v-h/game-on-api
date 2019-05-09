using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Football
{
    public class Api
    {
        [JsonProperty("results")]
        public int Results;

        [JsonProperty("fixtures")]
        public List<Fixture> Fixtures;

        [JsonProperty("teams")]
        public List<Team> Teams;
    }
}
