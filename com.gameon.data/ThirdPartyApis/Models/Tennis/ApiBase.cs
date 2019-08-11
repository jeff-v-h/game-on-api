using Newtonsoft.Json;
using System;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class ApiBase
    {
        [JsonProperty("generated_at")]
        public DateTime? GeneratedAt { get; set; }

        [JsonProperty("schema")]
        public string Schema { get; set; }
    }
}
