using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Esports
{
    public class EsportsTournamentVM : TournamentBaseVM
    {
        public List<EsportsTeamBaseVM> Teams { get; set; }
        public SeriesBaseVM Series { get; set; }
        public List<MatchBaseVM> Matches { get; set; }
        public LeagueVM League { get; set; }

        public EsportsTournamentVM(EsportsTournament t)
        {
            WinnerType = t.WinnerType;
            Teams = MapTeams(t.Teams);
            Slug = t.Slug;
            SeriesId = t.SeriesId;
            Series = (t.Series != null) ? new SeriesBaseVM(t.Series) : null; 
            Name = t.Name;
            Matches = MapMatches(t.Matches);
            LeagueId = t.LeagueId;
            League = (t.League != null) ? new LeagueVM(t.League) : null;
            Id = t.Id;
            EndAt = t.EndAt;
            BeginAt = t.BeginAt;
        }

        private List<EsportsTeamBaseVM> MapTeams(List<EsportsTeamBase> teams)
        {
            if (teams == null) return null;

            var list = new List<EsportsTeamBaseVM>();

            for (int i = 0; i < teams.Count; i++)
                list.Add(new EsportsTeamBaseVM(teams[i]));

            return list;
        }

        private List<MatchBaseVM> MapMatches(List<MatchBase> matches)
        {
            if (matches == null) return null;

            var list = new List<MatchBaseVM>();

            for (int i = 0; i < matches.Count; i++)
                list.Add(new MatchBaseVM(matches[i]));

            return list;
        }
    }
}
