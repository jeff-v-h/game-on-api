using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.ViewModels.Esports
{
    public class ESportsCompetitorVM
    {
        public string Type { get; set; }
        public ESportsTeamBaseVM Opponent { get; set; }

        public ESportsCompetitorVM(Competitor t)
        {
            Type = t.Type;
            Opponent = (t.Opponent != null) ? new ESportsTeamBaseVM(t.Opponent) : null;
        }
    }
}
