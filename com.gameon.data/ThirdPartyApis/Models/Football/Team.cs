using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Football
{

    public class Team : TeamBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("founded")]
        public int Founded { get; set; }

        [JsonProperty("venue_name")]
        public string VenueName { get; set; }

        [JsonProperty("venue_surface")]
        public string VenueSurface { get; set; }

        [JsonProperty("venue_address")]
        public string VenueAddress { get; set; }

        [JsonProperty("venue_city")]
        public string VenueCity { get; set; }

        [JsonProperty("venue_capacity")]
        public int VenueCapacity { get; set; }
    }
}
