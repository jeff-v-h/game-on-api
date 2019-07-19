using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.ViewModels.Esports
{
    public class VideoGameVM
    {
        public string Slug { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public VideoGameVM(VideoGame v)
        {
            Slug = v.Slug;
            Name = v.Name;
            Id = v.Id;
        }
    }
}
