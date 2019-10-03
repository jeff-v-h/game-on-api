using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class PlayerBaseVM : IdentifierVM
    {
        public string Abbreviation { get; set; }

        public PlayerBaseVM(PlayerBase p)
        {
            Id = p.Id;
            Name = p.Name;
            Abbreviation = p.Abbreviation;
        }

        public PlayerBaseVM() { }
    }
}
