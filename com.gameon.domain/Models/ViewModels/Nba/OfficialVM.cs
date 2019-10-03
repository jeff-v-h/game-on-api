using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class OfficialVM
    {
        public string Name { get; set; }

        public OfficialVM(Official o)
        {
            Name = o.Name;
        }
    }
}
