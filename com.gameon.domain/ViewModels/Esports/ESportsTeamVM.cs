using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Esports
{
    public class ESportsTeamVM : ESportsTeamBaseVM
    {
        public List<ESportsPlayerVM> Players { get; set; }

        public ESportsTeamVM(Team t)
        {
            Slug = t.Slug;
            Name = t.Name;
            ImageUrl = t.ImageUrl;
            Id = t.Id;
            Acronym = t.Acronym;
            Players = MapPlayers(t.Players);
        }

        private List<ESportsPlayerVM> MapPlayers(List<Player> players)
        {
            if (players == null) return null;

            var list = new List<ESportsPlayerVM>();

            for (int i = 0; i < players.Count; i++)
                list.Add(new ESportsPlayerVM(players[i]));

            return list;
        }
    }
}
