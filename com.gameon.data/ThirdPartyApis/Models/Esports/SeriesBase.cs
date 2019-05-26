using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class SeriesBase : Competition
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("prizepool")]
        public string Prizepool { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
