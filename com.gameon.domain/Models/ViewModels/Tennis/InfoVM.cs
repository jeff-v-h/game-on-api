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
    }
}
