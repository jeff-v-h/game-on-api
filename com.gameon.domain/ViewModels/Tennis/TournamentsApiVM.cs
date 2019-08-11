using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class TournamentsApiVM : ApiBaseVM
    {
        public List<TournamentVM> Tournaments { get; set; }

        public TournamentsApiVM(TournamentsApi t)
        {
            Tournaments = MapTournaments(t.Tournaments);
        }

        private List<TournamentVM> MapTournaments(List<TennisTournament> tournaments)
        {
            if (tournaments == null) return null;

            var list = new List<TournamentVM>();

            for (int i = 0; i < tournaments.Count; i++)
            {
                list.Add(new TournamentVM(tournaments[i]));
            }

            return list;
        }
    }
}
