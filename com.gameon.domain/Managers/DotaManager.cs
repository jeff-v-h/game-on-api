using AutoMapper;
using com.gameon.data.Database.Interfaces;
using com.gameon.data.Database.Models;
using com.gameon.domain.Interfaces;
using com.gameon.domain.Models.ViewModels.Dota2;
using System;
using System.Collections.Generic;

namespace com.gameon.domain.Managers
{
    public class DotaManager : IDotaManager
    {
        private readonly IDotaRepository _repo;
        private readonly IMapper _mapper;

        public DotaManager(IDotaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // CRUD methods for private database. For requests to third party APIs check EsportsManager
        public List<DotaVM> GetAll()
        {
            var dotaList = _repo.GetAll();

            var dotaVMs = new List<DotaVM>();

            foreach (Dota d in dotaList) dotaVMs.Add(_mapper.Map<DotaVM>(d));

            return dotaVMs;
        }

        public DotaVM Get(string id)
        {
            var dota = _repo.Get(id);

            // return null if dota is null
            return (dota != null) ? _mapper.Map<DotaVM>(dota) : null;
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
