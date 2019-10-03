using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class PlayerVM : PlayerBaseVM
    {
        public string Nationality { get; set; }
        public string CountryCode { get; set; }

        public PlayerVM(Player p)
        {
            Id = p.Id;
            Name = p.Name;
            Abbreviation = p.Abbreviation;
            Nationality = p.Nationality;
            CountryCode = p.CountryCode;
        }

        public PlayerVM() { }
    }
}
