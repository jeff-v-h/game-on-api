using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class EsportsTeamVM : EsportsTeamBaseVM
    {
        public List<EsportsPlayerVM> Players { get; set; }
    }
}
