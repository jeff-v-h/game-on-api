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

        public TournamentVM(Tournament t)
        {
            Id = t.Id;
            Name = t.Name;
            Sport = new IdentifierVM(t.Sport);
            Category = new CategoryVM(t.Category);
            CurrentSeason = new SeasonVM(t.CurrentSeason);
            Type = t.Type;
            Gender = t.Gender;
            CountryFormat = t.CountryFormat;
            ParentId = t.ParentId;
        }
    }
}
