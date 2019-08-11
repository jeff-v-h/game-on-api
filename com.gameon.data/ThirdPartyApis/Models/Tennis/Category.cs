using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class Category : Identifier
    {
        [JsonProperty("level")]
        public string Level { get; set; }
    }
}
