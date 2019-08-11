using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class RankingsApiVM
    {
        public List<AssociationRankingsVM> Rankings { get; set; }

        public RankingsApiVM(RankingsApi r)
        {
            Rankings = MapRankings(r.Rankings);
        }

        private List<AssociationRankingsVM> MapRankings(List<AssociationRankings> rankings)
        {
            if (rankings == null) return null;

            var list = new List<AssociationRankingsVM>();

            for (int i = 0; i < rankings.Count; i++)
                list.Add(new AssociationRankingsVM(rankings[i]));

            return list;
        }
    }
}
