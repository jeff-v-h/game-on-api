using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class PlayerVM : IdentifierVM
    {
        public string Abbreviation { get; set; }

        public PlayerVM(Player p)
        {
            Id = p.Id;
            Name = p.Name;
            Abbreviation = p.Abbreviation;
        }

        public PlayerVM() { }
    }
}
