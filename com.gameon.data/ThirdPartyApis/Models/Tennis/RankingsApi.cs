using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class RankingsApi : ApiBase
    {
        [JsonProperty("rankings")]
        public List<AssociationRankings> Rankings { get; set; }
    }
}
