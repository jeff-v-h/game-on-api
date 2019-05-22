using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class SeasonVM : IdentifierVM
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Year { get; set; }
        public string TournamentId { get; set; }

        public SeasonVM(Season s)
        {
            Id = s.Id;
            Name = s.Name;
            StartDate = s.StartDate;
            EndDate = s.EndDate;
            Year = s.Year;
            TournamentId = s.TournamentId;
        }
    }
}
