using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Nba
{
    public class Api
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public int Results { get; set; }
        public List<string> Filters { get; set; }
        public List<Team> Teams { get; set; }
        public List<Game> Games { get; set; }
    }
}
