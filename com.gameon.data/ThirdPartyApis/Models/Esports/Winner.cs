using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Winner
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }
    }
}
