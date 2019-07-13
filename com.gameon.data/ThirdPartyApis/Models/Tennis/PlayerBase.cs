using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class PlayerBase : Identifier
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
    }
}
