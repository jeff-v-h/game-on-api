using System;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class EsportsGameVM
    {
        public string WinnerType { get; set; }
        public WinnerVM Winner { get; set; }
        public int? Position { get; set; }
        public int? MatchId { get; set; }
        public int? Length { get; set; }
        public int? Id { get; set; }
        public bool Forfeit { get; set; }
        public bool Finished { get; set; }
        public DateTime? EndAt { get; set; }
        public DateTime? BeginAt { get; set; }
    }
}
