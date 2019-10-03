using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class CategoryVM : IdentifierVM
    {
        public string Level { get; set; }

        public CategoryVM(Category c)
        {
            Id = c.Id;
            Name = c.Name;
            Level = c.Level;
        }
    }
}
