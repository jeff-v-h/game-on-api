using com.gameon.domain.Models.ViewModels.General;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IGeneralManager
    {
        Task<SortedEventsVM> GetEventsAsync();
        Task<SortedWeekEventsVM> GetSortedWeekEventsAsync(string weekStartDateString = null);
        Task<SortedWeekEventsVM> GetSportSortedWeekEventsAsync(string sportOrLeague, string weekStartDateString = null);
    }
}
