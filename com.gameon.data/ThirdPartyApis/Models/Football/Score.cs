using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Football
{
    public class Score
    {
        [JsonProperty("halftime")]
        public string Halftime { get; set; }
        [JsonProperty("fulltime")]
        public string Fulltime { get; set; }
        [JsonProperty("extratime")]
        public object Extratime { get; set; }
        [JsonProperty("penalty")]
        public object Penalty { get; set; }
    }
}
