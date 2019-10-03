using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class LeagueVM
    {
        public string Url { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public bool LiveSupported { get; set; }
        public string ImageUrl { get; set; }
        public int Id { get; set; }

        public LeagueVM(League l)
        {
            Url = l.Url;
            Slug = l.Slug;
            Name = l.Name;
            LiveSupported = l.LiveSupported;
            ImageUrl = l.ImageUrl;
            Id = l.Id;
        }
    }
}
