using com.gameon.data.ThirdPartyApis.Models.Esports;
using Newtonsoft.Json;
using System;

namespace com.gameon.domain.ViewModels.Esports
{
    public class MatchVM
    {
        public int? WinnerId { get; set; }
        public int TournamentId { get; set; }
        public string Status { get; set; }
        public string Slug { get; set; }
        public int NumberOfGames { get; set; }
        public string Name { get; set; }
        public string MatchType { get; set; }
        public LiveVM Live { get; set; }
        public int Id { get; set; }
        public bool Forfeit { get; set; }
        public DateTime? EndAt { get; set; }
        public bool Draw { get; set; }
        public DateTime? BeginAt { get; set; }

        public MatchVM(Match m)
        {
            WinnerId = m.WinnerId;
            TournamentId = m.TournamentId;
            Status = m.Status;
            Slug = m.Slug;
            NumberOfGames = m.NumberOfGames;
            Name = m.Name;
            MatchType = m.MatchType;
            Live = (m.Live != null) ? new LiveVM(m.Live) : null;
            Id = m.Id;
            Forfeit = m.Forfeit;
            EndAt = m.EndAt;
            Draw = m.Draw;
            BeginAt = m.BeginAt;
        }
    }
}
