﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class TournamentsApi : ApiBase
    {
        [JsonProperty("tournaments")]
        public List<Tournament> Tournaments { get; set; }
    }
}
