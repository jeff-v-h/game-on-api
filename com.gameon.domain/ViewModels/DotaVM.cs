using com.gameon.data.Models;
using System;

namespace com.gameon.domain.ViewModels
{
    public class DotaVM
    {
        public string Id { get; set; }
        public TournamentVM Tournament { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }

        public DotaVM(Dota d)
        {
            Id = d.Id;
            Tournament = new TournamentVM(d.Tournament);
            StartDate = d.StartDate;
            EndDate = d.EndDate;
            IsCompleted = d.IsCompleted;
        }

        public DotaVM() { }
    }
}
