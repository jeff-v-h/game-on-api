using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Tennis
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
        public List<CompetitorVM> Competitors { get; set; }
        public VenueVM Venue { get; set; }
        public bool Estimated { get; set; }
        public SportEventVM(SportEvent s)
        {
            Id = s.Id;
            Scheduled = s.Scheduled;
            StartTimeTbd = s.StartTimeTbd;
            Status = s.Status;
            TournamentRound = new TournamentRoundVM(s.TournamentRound);
            Season = new SeasonVM(s.Season);
            Tournament = new TournamentVM(s.Tournament);
            Competitors = MapCompetitors(s.Competitors);
            Venue = new VenueVM(s.Venue);
            Estimated = s.Estimated;
        }

        private List<CompetitorVM> MapCompetitors(List<Competitor> competitors)
        {
            if (competitors == null) return null;

            var list = new List<CompetitorVM>();

            for (int i = 0; i < competitors.Count; i++)
            {
                list.Add(new CompetitorVM(competitors[i]));
            }

            return list;
        }
    }
}
