using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class Player : PlayerBase
    {
        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
