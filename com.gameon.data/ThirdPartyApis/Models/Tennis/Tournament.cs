using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class Tournament : Identifier
    {
        [JsonProperty("sport")]
        public Identifier Sport { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("current_season")]
        public Season CurrentSeason { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("country_format")]
        public bool CountryFormat { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }
    }
}
