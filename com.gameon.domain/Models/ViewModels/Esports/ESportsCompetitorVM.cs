using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class EsportsCompetitorVM
    {
        public string Type { get; set; }
        public EsportsTeamBaseVM Opponent { get; set; }
    }
}
