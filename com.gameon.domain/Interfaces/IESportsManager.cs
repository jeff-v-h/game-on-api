using com.gameon.domain.ViewModels.Esports;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IESportsManager
    {
        Task<ESportsTournamentsVM> GetDotaTournaments();
        Task<ESportsTournamentsVM> GetLolTournaments();
        Task<ESportsTournamentsVM> GetOverwatchTournaments();
        Task<ESportsTournamentsVM> GetCsgoTournaments();
    }
}
