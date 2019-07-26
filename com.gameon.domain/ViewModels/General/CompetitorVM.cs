using com.gameon.data.ThirdPartyApis.Models.Nba;
using com.gameon.data.ThirdPartyApis.Models.Football;
using com.gameon.data.ThirdPartyApis.Models.Tennis;
using com.gameon.data.ThirdPartyApis.Models.Esports;

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

        // NBA
        public CompetitorVM(CompetingTeam c)
        {
            Name = c.FullName;
            ShortName = c.NickName;
            Abbreviation = c.ShortName;
            Thumbnail = c.Logo;
            Score = c.Score?.Points;
        }

        // Football
        public CompetitorVM(FootballTeamBase t, int? goals)
        {
            Name = t.TeamName;
            Thumbnail = t.Logo;
            Score = goals?.ToString();
        }
        
        // Tennis
        public CompetitorVM(TennisCompetitor c)
        {
            Name = c.Name;
            Abbreviation = c.Abbreviation;
            Rank = c.Seed?.ToString();
        }

        // Esports
        public CompetitorVM(EsportsTeamBase c, int? score)
        {
            Name = c.Name;
            Abbreviation = c.Acronym;
            Thumbnail = c.ImageUrl;
            Score = score.ToString();
        }
    }
}
