using com.gameon.data.Database.Models;

namespace com.gameon.domain.ViewModels
{
    public class TournamentVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public TournamentVM(Tournament t)
        {
            Id = t.Id;
            Name = t.Name;
            Year = t.Year;
        }

        public TournamentVM() { }
    }
}
