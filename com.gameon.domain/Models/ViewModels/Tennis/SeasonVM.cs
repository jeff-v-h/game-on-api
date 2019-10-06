namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class SeasonVM : IdentifierVM
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Year { get; set; }
        public string TournamentId { get; set; }
    }
}
