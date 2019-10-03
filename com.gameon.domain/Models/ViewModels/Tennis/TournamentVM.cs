namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class TournamentVM : IdentifierVM
    {
        public IdentifierVM Sport { get; set; }
        public CategoryVM Category { get; set; }
        public SeasonVM CurrentSeason { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public bool CountryFormat { get; set; }
        public string ParentId { get; set; }
    }
}
