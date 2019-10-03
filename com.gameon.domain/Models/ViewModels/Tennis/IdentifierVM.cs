using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class IdentifierVM
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IdentifierVM(Identifier i)
        {
            Id = i.Id;
            Name = i.Name;
        }

        public IdentifierVM() { }
    }
}
