using com.gameon.data.ThirdPartyApis.Models.Tennis;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class CompetitorVM : PlayerVM
    {
        public string Nationality { get; set; }
        public string CountryCode { get; set; }
        public int? Seed { get; set; }
        public int? BracketNumber { get; set; }
        public string Qualifier { get; set; }
        public string QualificationPath { get; set; }

        public CompetitorVM(Competitor c)
        {
            Id = c.Id;
            Name = c.Name;
            Abbreviation = c.Abbreviation;
            Nationality = c.Nationality;
            CountryCode = c.CountryCode;
            Seed = c.Seed;
            BracketNumber = c.BracketNumber;
            Qualifier = c.Qualifier;
            QualificationPath = c.QualificationPath;
        }
    }
}
