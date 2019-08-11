using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class VideoGame
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
