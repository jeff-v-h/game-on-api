using com.gameon.data.Models;
using MongoDB.Bson;
using System;

namespace com.gameon.domain.ViewModels
{
    public class DotaVM
    {
        public DotaVM(Dota d)
        {
            Tournament = new TournamentVM(d.Tournament);
            StartDate = d.StartDate;
            EndDate = d.EndDate;
            IsCompleted = d.IsCompleted;
        }

        public DotaVM() { }

        public ObjectId Id { get; set; }
        public TournamentVM Tournament { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
