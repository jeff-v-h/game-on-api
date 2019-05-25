using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Player
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("role")]
        public object Role { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("hometown")]
        public string Hometown { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }
    }
}
