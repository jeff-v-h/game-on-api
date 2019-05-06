using com.gameon.data.Database.Interfaces;
using com.gameon.data.Database.Models;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels;
using System;
using System.Collections.Generic;

namespace com.gameon.domain.managers
{
    public class DotaManager : IDotaManager
    {
        private readonly IDotaRepository _repo;

        public DotaManager(IDotaRepository repo)
        {
            _repo = repo;
        }

        public List<DotaVM> GetAll()
        {
            var dotaList = _repo.GetAll();

            var dotaVMs = new List<DotaVM>();

            foreach (Dota d in dotaList) dotaVMs.Add(new DotaVM(d));

            return dotaVMs;
        }

        public DotaVM Get(string id)
        {
            var dota = _repo.Get(id);

            // return null if dota is null
            return (dota != null) ? new DotaVM(dota) : null;
        }

        public DotaVM Create(DotaVM dotaVM)
        {
            var today = DateTime.UtcNow;
            var dota = TransferValues(dotaVM, today);

            dota.CreatedOn = today;

            // Pass the data to repo for creation and return the new id into the view model
            _repo.Create(dota);
            dotaVM.Id = dota.Id;

            return dotaVM;
        }

        public bool Update(string id, DotaVM dotaVM)
        {
            var dota = _repo.Get(id);
            if (dota == null) return false;

            var newDotaValues = TransferValues(dotaVM, DateTime.UtcNow);
            newDotaValues.Id = dota.Id;

            _repo.Replace(id, newDotaValues);

            return true;
        }

        // Pass in the property values from viewmodel into a new Dota object (excluding id and CreatedOn)
        private Dota TransferValues(DotaVM dotaVM, DateTime today)
        {
            return new Dota
            {
                ModifiedOn = today,
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

        public bool Delete(string id)
        {
            var dota = _repo.Get(id);
            if (dota == null) return false;

            _repo.Delete(id);
            return true;
        }
    }
}
