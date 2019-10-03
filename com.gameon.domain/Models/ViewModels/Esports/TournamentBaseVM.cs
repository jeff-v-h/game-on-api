using com.gameon.data.ThirdPartyApis.Models.Esports;
using System;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class TournamentBaseVM
    {
        public string WinnerType { get; set; }
        public int? WinnerId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int LeagueId { get; set; }
        public int Id { get; set; }
        public DateTime? EndAt { get; set; }
        public DateTime? BeginAt { get; set; }
        public int SeriesId { get; set; }

        public TournamentBaseVM() { }
    }
}
