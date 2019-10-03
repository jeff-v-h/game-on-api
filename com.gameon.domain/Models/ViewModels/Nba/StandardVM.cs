using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class StandardVM
    {
        public string ConfName { get; set; }
        public string DivName { get; set; }

        public StandardVM(Standard s)
        {
            ConfName = s.ConfName;
            DivName = s.DivName;
        }
    }
}
