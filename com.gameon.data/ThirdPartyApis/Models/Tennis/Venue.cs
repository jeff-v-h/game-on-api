using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class Venue : Identifier
    {
        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
