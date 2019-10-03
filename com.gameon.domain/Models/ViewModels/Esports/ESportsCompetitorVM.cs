using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class EsportsCompetitorVM
    {
        public string Type { get; set; }
        public EsportsTeamBaseVM Opponent { get; set; }

        public EsportsCompetitorVM(Competitor t)
        {
            Type = t.Type;
            Opponent = (t.Opponent != null) ? new EsportsTeamBaseVM(t.Opponent) : null;
        }
    }
}
