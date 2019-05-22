using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class CoverageInfoVM
    {
        public string LiveCoverage { get; set; }

        public CoverageInfoVM(CoverageInfo c)
        {
            LiveCoverage = c.LiveCoverage;
        }
    }
}
