using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Esports
{
    public class MatchVM : MatchBaseVM
    {
        public TournamentBaseVM Tournament { get; set; }
        public EsportsTeamBaseVM Winner { get; set; }
        public int SeriesId { get; set; }
        public SeriesBaseVM Series { get; set; }
        public List<ResultVM> Results { get; set; }
        public List<EsportsCompetitorVM> Opponents { get; set; }
        public int LeagueId { get; set; }
        public LeagueVM League { get; set; }
        public List<EsportsGameVM> Games { get; set; }

        public MatchVM(Match m)
        {
            BeginAt = m.BeginAt;
            Draw = m.Draw;
            EndAt = m.EndAt;
            Forfeit = m.Forfeit;
            Games = MapGames(m.Games);
            Id = m.Id;
            League = (m.League != null) ? new LeagueVM(m.League) : null;
            LeagueId = m.LeagueId;
            Live = (m.Live != null) ? new LiveVM(m.Live) : null;
            MatchType = m.MatchType;
            Name = m.Name;
            NumberOfGames = m.NumberOfGames;
            Opponents = MapOpponents(m.Opponents);
            Results = MapResults(m.Results);
            Series = (m.Series != null) ? new SeriesBaseVM(m.Series) : null;
            SeriesId = m.SeriesId;
            Slug = m.Slug;
            Status = m.Status;
            Tournament = (m.Tournament != null) ? new TournamentBaseVM(m.Tournament) : null;
            TournamentId = m.TournamentId;
            Winner = (m.Winner != null) ? new EsportsTeamBaseVM(m.Winner) : null;
            WinnerId = m.WinnerId;
        }

        private List<ResultVM> MapResults(List<Result> results)
        {
            if (results == null) return null;

            var list = new List<ResultVM>();

            for (int i = 0; i < results.Count; i++)
                list.Add(new ResultVM(results[i]));

            return list;
        }

        private List<EsportsCompetitorVM> MapOpponents(List<Competitor> opponents)
        {
            if (opponents == null) return null;

            var list = new List<EsportsCompetitorVM>();

            for (int i = 0; i < opponents.Count; i++)
                list.Add(new EsportsCompetitorVM(opponents[i]));

            return list;
        }

        private List<EsportsGameVM> MapGames(List<Game> games)
        {
            if (games == null) return null;

            var list = new List<EsportsGameVM>();

            for (int i = 0; i < games.Count; i++)
                list.Add(new EsportsGameVM(games[i]));

            return list;
        }
    }
}
