using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Esports
{
    public class ESportsTournamentsVM
    {
        public List<Tournament> Tournaments { get; set; }

        public ESportsTournamentsVM(List<Tournament> t)
        {
            Tournaments = t;
        }
    }
}
