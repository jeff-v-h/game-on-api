using com.gameon.data.Models;
using System;

namespace com.gameon.domain.ViewModels
{
    public class DotaVM
    {
        public DotaVM(Dota d)
        {
            tournament = new TournamentVM(d.tournament);
            startDate = d.startDate;
            endDate = d.endDate;
            isCompleted = d.isCompleted;
        }

        public DotaVM() { }

        public TournamentVM tournament { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isCompleted { get; set; }
    }
}
