using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class EsportsTeamBaseVM
    {
        public string Slug { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int? Id { get; set; }
        public string Acronym { get; set; }

        public EsportsTeamBaseVM(EsportsTeamBase t)
        {
            Slug = t.Slug;
            Name = t.Name;
            ImageUrl = t.ImageUrl;
            Id = t.Id;
            Acronym = t.Acronym;
        }

        public EsportsTeamBaseVM() { }
    }
}
