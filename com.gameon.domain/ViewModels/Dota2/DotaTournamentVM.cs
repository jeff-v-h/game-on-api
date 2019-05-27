using com.gameon.data.Database.Models;

namespace com.gameon.domain.ViewModels.Dota2
{
    public class DotaTournamentVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public DotaTournamentVM(Tournament t)
        {
            Id = t.Id;
            Name = t.Name;
            Year = t.Year;
        }

        public DotaTournamentVM() { }
    }
}
