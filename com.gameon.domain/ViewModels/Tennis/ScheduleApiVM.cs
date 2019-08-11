using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class ScheduleApiVM : ApiBaseVM
    {
        public TournamentVM Tournament { get; set; }
        public List<SportEventVM> SportEvents { get; set; }

        public ScheduleApiVM(ScheduleApi s)
        {
            Tournament = (s.Tournament != null) ? new TournamentVM(s.Tournament) : null;
            SportEvents = MapSportEvents(s.SportEvents);
        }

        private List<SportEventVM> MapSportEvents(List<SportEvent> sportEvents)
        {
            if (sportEvents == null) return null;

            var list = new List<SportEventVM>();

            for (int i = 0; i < sportEvents.Count; i++)
            {
                list.Add(new SportEventVM(sportEvents[i]));
            }

            return list;
        }
    }
}
