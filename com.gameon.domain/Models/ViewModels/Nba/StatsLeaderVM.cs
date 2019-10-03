using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class StatsLeaderVM
    {
        public string PlayerId;
        public string Name;
        public string Stat;
        public string Value;

        public StatsLeaderVM(StatsLeader s)
        {
            PlayerId = s.PlayerId;
            Name = s.Name;
            Stat = (s.Points != null) ? "Points" 
                : (s.Assists != null) ? "Assists" 
                : (s.Rebounds != null) ? "Rebounds" : "";
            Value = (s.Points != null) ? s.Points 
                : (s.Assists != null) ? s.Assists
                : (s.Rebounds != null) ? s.Rebounds : "";
        }
    }
}
