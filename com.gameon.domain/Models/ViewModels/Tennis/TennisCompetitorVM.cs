namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class TennisCompetitorVM : PlayerVM
    {
        public int? Seed { get; set; }
        public int? BracketNumber { get; set; }
        public string Qualifier { get; set; }
        public string QualificationPath { get; set; }
    }
}
