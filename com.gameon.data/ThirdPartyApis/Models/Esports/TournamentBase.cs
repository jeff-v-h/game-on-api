using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class TournamentBase : Competition
    {
        [JsonProperty("serie_id")]
        public int SeriesId { get; set; }
    }
}
