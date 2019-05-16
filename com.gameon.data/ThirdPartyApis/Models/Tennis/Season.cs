using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class Season : Identifier
    {
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("tournament_id")]
        public string TournamentId { get; set; }
    }
}
