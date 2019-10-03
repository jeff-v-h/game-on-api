using System;

namespace com.gameon.domain.Models.ViewModels.Dota2
{
    public class DotaVM
    {
        public string Id { get; set; }
        public DotaTournamentVM Tournament { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }

        public DotaVM() { }
    }
}
