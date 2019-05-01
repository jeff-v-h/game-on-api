using com.gameon.data.Interfaces;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels;

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
    }
}
