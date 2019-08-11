using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class CoverageInfo
    {
        [JsonProperty("live_coverage")]
        public string LiveCoverage { get; set; }
    }
}
