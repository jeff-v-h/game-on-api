using com.gameon.domain.ViewModels.Esports;
using com.gameon.domain.ViewModels.Football;
using com.gameon.domain.ViewModels.Nba;
using com.gameon.domain.ViewModels.Tennis;

namespace com.gameon.domain.ViewModels.General
{
    public class CompetitorVM
    {
        public string Name;
        public string ShortName;
        public string Abbreviation;
        public string Thumbnail;
        public string Score;
        public string Rank;
        private EsportsTeamBaseVM opponent;

        // NBA
        public CompetitorVM(CompetingTeamVM c)
        {
            Name = c.FullName;
            ShortName = c.NickName;
            Abbreviation = c.ShortName;
            Thumbnail = c.Logo;
            Score = c.Score.Points;
        }

        // Football
        public CompetitorVM(TeamBaseVM t, int? goals)
        {
            Name = t.TeamName;
            Thumbnail = t.Logo;
            Score = goals?.ToString();
        }
        
        // Tennis
        public CompetitorVM(TennisCompetitorVM c)
        {
            Name = c.Name;
            Abbreviation = c.Abbreviation;
            Rank = c.Seed?.ToString();
        }

        public CompetitorVM(EsportsTeamBaseVM c, int score)
        {
            Name = c.Name;
            Abbreviation = c.Acronym;
            Thumbnail = c.ImageUrl;
            Score = score.ToString();
        }
    }
}
