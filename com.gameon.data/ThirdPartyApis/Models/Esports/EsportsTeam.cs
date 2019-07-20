using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class EsportsTeam : EsportsTeamBase
    {
        [JsonProperty("players")]
        public List<Player> Players { get; set; }

        [JsonProperty("current_videogame")]
        public VideoGame CurrentVideoGame { get; set; }
    }
}
