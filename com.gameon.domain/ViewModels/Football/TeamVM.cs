using com.gameon.data.ThirdPartyApis.Models.Football;

namespace com.gameon.domain.ViewModels.Football
{
    public class TeamVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public int Founded { get; set; }
        public string VenueName { get; set; }
        public string VenueSurface { get; set; }
        public string VenueAddress { get; set; }
        public string VenueCity { get; set; }
        public int VenueCapacity { get; set; }

        public TeamVM(Team t)
        {
            Name = t.Name;
            Code = t.Code;
            Country = t.Country;
            Founded = t.Founded;
            VenueName = t.VenueName;
            VenueSurface = t.VenueSurface;
            VenueAddress = t.VenueAddress;
            VenueCity = t.VenueCity;
            VenueCapacity = t.VenueCapacity;
        }
    }
}
