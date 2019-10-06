using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class TournamentsApiVM : ApiBaseVM
    {
        public List<TournamentVM> Tournaments { get; set; }
    }
}
