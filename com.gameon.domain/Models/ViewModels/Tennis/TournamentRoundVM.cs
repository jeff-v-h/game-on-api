using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class TournamentRoundVM
    {
        public string Type { get; set; }
        public int? Number { get; set; }
        public string Name { get; set; }
        public int? CupRoundMatchNumber { get; set; }
        public int? CupRoundMatches { get; set; }

        public TournamentRoundVM(TournamentRound t)
        {
            Type = t.Type;
            Number = t.Number;
            Name = t.Name;
            CupRoundMatchNumber = t.CupRoundMatchNumber;
            CupRoundMatches = t.CupRoundMatches;
        }
    }
}
