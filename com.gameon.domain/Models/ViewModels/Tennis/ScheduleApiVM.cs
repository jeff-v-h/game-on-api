using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class ScheduleApiVM : ApiBaseVM
    {
        public TournamentVM Tournament { get; set; }
        public List<SportEventVM> SportEvents { get; set; }
    }
}
