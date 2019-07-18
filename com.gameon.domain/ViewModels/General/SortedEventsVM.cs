using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.General
{
    public class SortedEventsVM
    {
        public List<EventVM> RecentlyCompleted;
        public List<EventVM> Live;
        public List<EventVM> Upcoming;
    }
}
