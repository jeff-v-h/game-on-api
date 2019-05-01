using com.gameon.data.Models;
using System;

namespace com.gameon.domain.ViewModels
{
    public class TournamentVM
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int year { get; set; }

        public TournamentVM(Tournament t)
        {
            id = t.id;
            name = t.name;
            year = t.year;
        }
    }
}
