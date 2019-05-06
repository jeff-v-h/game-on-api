using com.gameon.data.Interfaces;
using com.gameon.data.Models;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels;
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

        public DotaVM Get(string id)
        {
            var dota = _repo.Get(id);

            // return null if dota is null
            return (dota != null) ? new DotaVM(dota) : null;
        }

        public async Task<DotaVM> Create(DotaVM dotaVM)
        {
            var dota = TransferValues(dotaVM);

            // Pass the data to repo for creation and return the new id into the view model
            await _repo.Create(dota);
            dotaVM.Id = dota.Id;

            return dotaVM;
        }

        public bool Update(string id, DotaVM dotaVM)
        {
            var dota = _repo.Get(id);

            if (dota == null) return false;

            var newDotaValues = TransferValues(dotaVM);
            newDotaValues.Id = dota.Id;

            _repo.Replace(id, newDotaValues);

            return true;
        }

        // Pass in the property values from viewmodel into a new Dota object (excluding id)
        private Dota TransferValues(DotaVM dotaVM)
        {
            var today = DateTime.Today;
            
            return new Dota
            {
                Tournament = new Tournament
                {
                    Id = dotaVM.Tournament.Id,
                    Name = dotaVM.Tournament.Name,
                    Year = dotaVM.Tournament.Year
                },
                StartDate = dotaVM.StartDate,
                EndDate = dotaVM.EndDate,
                IsCompleted = (today > dotaVM.EndDate) ? true : false
            };
        }
    }
}
