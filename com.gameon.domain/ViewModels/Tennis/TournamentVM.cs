using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.ViewModels.Tennis
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

        public TournamentVM(TennisTournament t)
        {
            Id = t.Id;
            Name = t.Name;
            Sport = (t.Sport != null) ? new IdentifierVM(t.Sport) : null;
            Category = (t.Category != null) ? new CategoryVM(t.Category) : null;
            CurrentSeason = (t.CurrentSeason != null) ? new SeasonVM(t.CurrentSeason) : null;
            Type = t.Type;
            Gender = t.Gender;
            CountryFormat = t.CountryFormat;
            ParentId = t.ParentId;
        }
    }
}
