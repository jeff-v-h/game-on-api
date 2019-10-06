namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class PlayerRankVM
    {
        public int? Rank { get; set; }
        public int? Points { get; set; }
        public int? RankingMovement { get; set; }
        public int? TournamentsPlayed { get; set; }
        public PlayerVM Player { get; set; }
    }
}
