using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.ViewModels.Esports
{
    public class WinnerVM
    {
        public string Type { get; set; }
        public int? Id { get; set; }

        public WinnerVM(Winner w)
        {
            Type = w.Type;
            Id = w.Id;
        }
    }
}
