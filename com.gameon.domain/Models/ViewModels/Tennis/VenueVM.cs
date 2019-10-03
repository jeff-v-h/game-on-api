using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class VenueVM : IdentifierVM
    {
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public VenueVM(Venue v)
        {
            Id = v.Id;
            Name = v.Name;
            CityName = v.CityName;
            CountryName = v.CountryName;
            CountryCode = v.CountryCode;
        }
    }
}
