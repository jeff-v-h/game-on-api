using Newtonsoft.Json;
using System;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class League
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("modified_at")]
        public DateTime? ModifiedAt { get; set; }

        [JsonProperty("live_supported")]
        public bool LiveSupported { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
