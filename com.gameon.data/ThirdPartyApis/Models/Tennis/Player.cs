using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class Player : Identifier
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
    }
}
