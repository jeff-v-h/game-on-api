using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class InfoVM
    {
        public int? PrizeMoney { get; set; }
        public string PrizeCurrency { get; set; }
        public string Surface { get; set; }
        public string Complex { get; set; }
        public int? NumberOfCompetitors { get; set; }
        public int? NumberOfQualifiedCompetitors { get; set; }
        public int? NumberOfScheduledMatches { get; set; }

        public InfoVM(Info i)
        {
            PrizeMoney = i.PrizeMoney;
            PrizeCurrency = i.PrizeCurrency;
            Surface = i.Surface;
            Complex = i.Complex;
            NumberOfCompetitors = i.NumberOfCompetitors;
            NumberOfQualifiedCompetitors = i.NumberOfQualifiedCompetitors;
            NumberOfScheduledMatches = i.NumberOfScheduledMatches;
        }
    }
}
