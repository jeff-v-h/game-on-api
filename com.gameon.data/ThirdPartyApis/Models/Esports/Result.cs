using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Result
    {
        [JsonProperty("team_id")]
        public int TeamId { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
