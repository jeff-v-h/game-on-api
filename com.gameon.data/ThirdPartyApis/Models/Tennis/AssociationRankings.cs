using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class AssociationRankings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("week")]
        public int? Week { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("player_rankings")]
        public List<PlayerRank> PlayerRankings { get; set; }
    }
}
