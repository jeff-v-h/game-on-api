using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class EsportsTeamVM : EsportsTeamBaseVM
    {
        public List<EsportsPlayerVM> Players { get; set; }

        public EsportsTeamVM(EsportsTeam t)
        {
            Slug = t.Slug;
            Name = t.Name;
            ImageUrl = t.ImageUrl;
            Id = t.Id;
            Acronym = t.Acronym;
            Players = MapPlayers(t.Players);
        }

        private List<EsportsPlayerVM> MapPlayers(List<Player> players)
        {
            if (players == null) return null;

            var list = new List<EsportsPlayerVM>();

            for (int i = 0; i < players.Count; i++)
                list.Add(new EsportsPlayerVM(players[i]));

            return list;
        }
    }
}
