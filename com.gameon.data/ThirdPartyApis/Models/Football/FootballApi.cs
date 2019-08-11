using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Football
{
    public class FootballApi
    {
        [JsonProperty("api")]
        public Api Api { get; set; }
    }
}
