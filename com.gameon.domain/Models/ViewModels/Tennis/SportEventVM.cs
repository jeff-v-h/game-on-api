using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System;
using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class SportEventVM
    {
        public string Id { get; set; }
        public DateTime? Scheduled { get; set; }
        public bool StartTimeTbd { get; set; }
        public string Status { get; set; }
        public TournamentRoundVM TournamentRound { get; set; }
        public SeasonVM Season { get; set; }
        public TournamentVM Tournament { get; set; }
        public List<TennisCompetitorVM> Competitors { get; set; }
        public VenueVM Venue { get; set; }
        public bool Estimated { get; set; }
        public SportEventVM(SportEvent s)
        {
            Id = s.Id;
            Scheduled = s.Scheduled;
            StartTimeTbd = s.StartTimeTbd;
            Status = s.Status;
            TournamentRound = (s.TournamentRound != null) ? new TournamentRoundVM(s.TournamentRound) : null;
            Season = (s.Season != null) ? new SeasonVM(s.Season) : null;
            Tournament = (s.Tournament != null) ? new TournamentVM(s.Tournament) : null;
            Competitors = MapCompetitors(s.Competitors);
            Venue = (s.Venue != null) ? new VenueVM(s.Venue) : null;
            Estimated = s.Estimated;
        }

        private List<TennisCompetitorVM> MapCompetitors(List<TennisCompetitor> competitors)
        {
            if (competitors == null) return null;

            var list = new List<TennisCompetitorVM>();

            for (int i = 0; i < competitors.Count; i++)
            {
                list.Add(new TennisCompetitorVM(competitors[i]));
            }

            return list;
        }
    }
}
