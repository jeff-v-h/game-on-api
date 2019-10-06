using System;

namespace com.gameon.domain.Models.ViewModels.Football
{
    public class FixtureVM
    {
        public int? FixtureId { get; set; }
        public int? LeagueId { get; set; }
        public DateTime? EventDate { get; set; }
        public int? EventTimestamp { get; set; }
        public int? FirstHalfStart { get; set; }
        public int? SecondHalfStart { get; set; }
        public string Round { get; set; }
        public string Status { get; set; }
        public string StatusShort { get; set; }
        public int? Elapsed { get; set; }
        public string Venue { get; set; }
        public object Referee { get; set; }
        public TeamBaseVM HomeTeam { get; set; }
        public TeamBaseVM AwayTeam { get; set; }
        public int? GoalsHomeTeam { get; set; }
        public int? GoalsAwayTeam { get; set; }
        public ScoreVM Score { get; set; }
    }
}
