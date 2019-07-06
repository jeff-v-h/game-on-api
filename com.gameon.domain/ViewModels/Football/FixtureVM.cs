using com.gameon.data.ThirdPartyApis.Models.Football;
using System;

namespace com.gameon.domain.ViewModels.Football
{
    public class FixtureVM
    {
        public int? FixtureId { get; set; }
        public int? LeagueId { get; set; }
        public DateTime EventDate { get; set; }
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

        public FixtureVM(Fixture f)
        {
            FixtureId = f.FixtureId;
            LeagueId = f.LeagueId;
            EventDate = f.EventDate;
            EventTimestamp = f.EventTimestamp;
            FirstHalfStart = f.FirstHalfStart;
            SecondHalfStart = f.SecondHalfStart;
            Round = f.Round;
            Status = f.Status;
            StatusShort = f.StatusShort;
            Elapsed = f.Elapsed;
            Venue = f.Venue;
            Referee = f.Referee;
            HomeTeam = (f.HomeTeam != null) ? new TeamBaseVM(f.HomeTeam) : null;
            AwayTeam = (f.AwayTeam != null) ? new TeamBaseVM(f.AwayTeam) : null;
            GoalsHomeTeam = f.GoalsHomeTeam;
            GoalsAwayTeam = f.GoalsAwayTeam;
            Score = (f.Score != null) ? new ScoreVM(f.Score) : null;
        }
    }
}
