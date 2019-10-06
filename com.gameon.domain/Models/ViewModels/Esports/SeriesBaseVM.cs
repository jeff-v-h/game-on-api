using com.gameon.data.ThirdPartyApis.Models.Esports;
using System;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class SeriesBaseVM
    {
        public int Year { get; set; }
        public string WinnerType { get; set; }
        public int? WinnerId { get; set; }
        public string Slug { get; set; }
        public string Season { get; set; }
        public string Prizepool { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? EndAt { get; set; }
        public string Description { get; set; }
        public DateTime? BeginAt { get; set; }

        public SeriesBaseVM() { }
    }
}
