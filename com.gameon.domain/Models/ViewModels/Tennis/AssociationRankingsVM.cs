using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class AssociationRankingsVM
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Year { get; set; }
        public int? Week { get; set; }
        public string CategoryId { get; set; }
        public List<PlayerRankVM> PlayerRankings { get; set; }

        public AssociationRankingsVM(AssociationRankings a)
        {
            Name = a.Name;
            Type = a.Type;
            Year = a.Year;
            Week = a.Week;
            CategoryId = a.CategoryId;
            PlayerRankings = MapPlayerRankings(a.PlayerRankings);
        }

        private List<PlayerRankVM> MapPlayerRankings(List<PlayerRank> playerRankings)
        {
            if (playerRankings == null) return null;

            var list = new List<PlayerRankVM>();

            for (int i = 0; i < playerRankings.Count; i++)
                list.Add(new PlayerRankVM(playerRankings[i]));

            return list;
        }
    }
}
