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
    }
}
