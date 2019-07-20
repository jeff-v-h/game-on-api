using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Competitor
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("opponent")]
        public EsportsTeamBase Opponent { get; set; }
    }
}
