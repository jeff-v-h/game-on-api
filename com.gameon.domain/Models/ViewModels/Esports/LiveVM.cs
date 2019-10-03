using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class LiveVM
    {
        public string Url { get; set; }
        public bool Supported { get; set; }
        public object OpensAt { get; set; }

        public LiveVM(Live l)
        {
            Url = l.Url;
            Supported = l.Supported;
            OpensAt = l.OpensAt;
        }
    }
}
