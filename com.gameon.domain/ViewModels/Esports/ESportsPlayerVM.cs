using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.ViewModels.Esports
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

        public EsportsPlayerVM(Player p)
        {
            Slug = p.Slug;
            Role = p.Role;
            Name = p.Name;
            LastName = p.LastName;
            ImageUrl = p.ImageUrl;
            Id = p.Id;
            Hometown = p.Hometown;
            FirstName = p.FirstName;
        }
    }
}
