using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Football
{
    public class TeamBase
    {
        [JsonProperty("team_id")]
        public int TeamId { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
