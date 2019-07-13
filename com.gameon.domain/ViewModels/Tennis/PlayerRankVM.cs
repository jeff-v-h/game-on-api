using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class PlayerRankVM
    {
        public int? Rank { get; set; }
        public int? Points { get; set; }
        public int? RankingMovement { get; set; }
        public int? TournamentsPlayed { get; set; }
        public PlayerVM Player { get; set; }

        public PlayerRankVM(PlayerRank p)
        {
            Rank = p.Rank;
            Points = p.Points;
            RankingMovement = p.RankingMovement;
            TournamentsPlayed = p.TournamentsPlayed;
            Player = (p.Player != null) ? new PlayerVM(p.Player) : null;
        }
    }
}
