using com.gameon.data.Interfaces;
using com.gameon.data.Models;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace com.gameon.domain.managers
{
    public class DotaManager : IDotaManager
    {
        private readonly IDotaRepository _repo;

        public DotaManager(IDotaRepository repo)
        {
            _repo = repo;
        }

        public DotaVM Get()
        {
            var dota = _repo.Get();

            // return null if dota is null
            return (dota != null) ? new DotaVM(dota) : null;
        }

        public async Task<DotaVM> Create(DotaVM dotaVM)
        {
            // Ensure the project name is unique

            var today = DateTime.Today;
            // Pass in the property values into a new Project and add it into the Db via the repo.
            var dota = new Dota
            {
                Id = new ObjectId(),
                Tournament = new Tournament
                {
                    Name = dotaVM.Tournament.Name,
                    Year = dotaVM.Tournament.Year
                },
                StartDate = dotaVM.StartDate,
                EndDate = dotaVM.EndDate,
                IsCompleted = (today > dotaVM.EndDate) ? true : false
            };

            // Pass the data to repo for creation and return the new id into the view model
            await _repo.Create(dota);
            dotaVM.Id = dota.Id;

            return dotaVM;
        } 
    }
}
