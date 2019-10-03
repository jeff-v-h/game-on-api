using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class EsportsPlayerVM
    {
        public string Slug { get; set; }
        public object Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int Id { get; set; }
        public string Hometown { get; set; }
        public string FirstName { get; set; }
    }
}
