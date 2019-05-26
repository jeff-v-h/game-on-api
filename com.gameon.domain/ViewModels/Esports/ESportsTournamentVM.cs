using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Esports
{
    public class ESportsTournamentVM : TournamentBaseVM
    {
        public List<ESportsTeamBaseVM> Teams { get; set; }
        public SeriesBaseVM Series { get; set; }
        public List<MatchBaseVM> Matches { get; set; }
        public LeagueVM League { get; set; }

        public ESportsTournamentVM(Tournament t)
        {
            WinnerType = t.WinnerType;
            Teams = MapTeams(t.Teams);
            Slug = t.Slug;
            SeriesId = t.SeriesId;
            Name = t.Name;
            Matches = MapMatches(t.Matches);
            LeagueId = t.LeagueId;
            League = (t.League != null) ? new LeagueVM(t.League) : null;
            Id = t.Id;
            EndAt = t.EndAt;
            BeginAt = t.BeginAt;
        }

        private List<ESportsTeamBaseVM> MapTeams(List<TeamBase> teams)
        {
            if (teams == null) return null;

            var list = new List<ESportsTeamBaseVM>();

            for (int i = 0; i < teams.Count; i++)
                list.Add(new ESportsTeamBaseVM(teams[i]));

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
