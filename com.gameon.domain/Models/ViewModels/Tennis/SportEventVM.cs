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
    }
}
