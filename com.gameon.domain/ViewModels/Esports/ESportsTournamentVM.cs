using com.gameon.data.ThirdPartyApis.Models.Esports;
using System;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Esports
{
    public class ESportsTournamentVM
    {
        public string WinnerType { get; set; }
        public int? WinnerId { get; set; }
        public List<ESportsTeamVM> Teams { get; set; }
        public string Slug { get; set; }
        public int SeriesId { get; set; }
        public SeriesVM Series { get; set; }
        public string Name { get; set; }
        public List<MatchVM> Matches { get; set; }
        public int LeagueId { get; set; }
        public LeagueVM League { get; set; }
        public int Id { get; set; }
        public DateTime? EndAt { get; set; }
        public DateTime? BeginAt { get; set; }

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

        private List<ESportsTeamVM> MapTeams(List<Team> teams)
        {
            if (teams == null) return null;

            var list = new List<ESportsTeamVM>();

            for (int i = 0; i < teams.Count; i++)
            {
                list.Add(new ESportsTeamVM(teams[i]));
            }

            return list;
        }

        private List<MatchVM> MapMatches(List<Match> matches)
        {
            if (matches == null) return null;

            var list = new List<MatchVM>();

            for (int i = 0; i < matches.Count; i++)
            {
                list.Add(new MatchVM(matches[i]));
            }

            return list;
        }
    }
}
