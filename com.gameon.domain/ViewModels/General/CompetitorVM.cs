using com.gameon.domain.ViewModels.Nba;

namespace com.gameon.domain.ViewModels.General
{
    public class CompetitorVM
    {
        public string Name;
        public string ShortName;
        public string Abbreviation;
        public string Thumbnail;
        public string Score;

        public CompetitorVM(CompetingTeamVM c)
        {
            Name = c.FullName;
            ShortName = c.NickName;
            Abbreviation = c.ShortName;
            Thumbnail = c.Logo;
            Score = c.Score.Points;
        }
    }
}
