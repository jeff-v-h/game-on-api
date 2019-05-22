using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Live
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("supported")]
        public bool Supported { get; set; }

        [JsonProperty("opens_at")]
        public object OpensAt { get; set; }
    }
}
