using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class SeriesVM : SeriesBaseVM
    {
        public LeagueVM League { get; set; }
        public List<TournamentBaseVM> Tournaments { get; set; }

        public SeriesVM(Series s)
        {
            Year = s.Year;
            WinnerType = s.WinnerType;
            WinnerId = s.WinnerId;
            Tournaments = MapTournaments(s.Tournaments);
            Slug = s.Slug;
            Season = s.Season;
            Prizepool = s.Prizepool;
            Name = s.Name;
            LeagueId = s.LeagueId;
            Id = s.Id;
            FullName = s.FullName;
            League = new LeagueVM(s.League);
            EndAt = s.EndAt;
            Description = s.Description;
            BeginAt = s.BeginAt;
        }

        private List<TournamentBaseVM> MapTournaments(List<TournamentBase> tournaments)
        {
            if (tournaments == null) return null;

            var list = new List<TournamentBaseVM>();

            for (int i = 0; i < tournaments.Count; i++)
                list.Add(new TournamentBaseVM(tournaments[i]));

            return list;
        }
    }
}
