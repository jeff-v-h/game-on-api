using com.gameon.data.ThirdPartyApis.Models.Esports;
using System;

namespace com.gameon.domain.ViewModels.Esports
{
    public class ESportsGameVM
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

        public ESportsGameVM(Game g)
        {
            WinnerType = g.WinnerType;
            Winner = (g.Winner != null) ? new WinnerVM(g.Winner) : null;
            Position = g.Position;
            MatchId = g.MatchId;
            Length = g.Length;
            Id = g.Id;
            Forfeit = g.Forfeit;
            Finished = g.Finished;
            EndAt = g.EndAt;
            BeginAt = g.BeginAt;
        }
    }
}
