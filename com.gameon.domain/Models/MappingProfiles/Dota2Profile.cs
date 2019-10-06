using AutoMapper;
using com.gameon.data.Database.Models;
using com.gameon.domain.Models.ViewModels.Dota2;

namespace com.gameon.domain.Models.MappingProfiles
{
    public class Dota2Profile : Profile
    {
        public Dota2Profile()
        {
            CreateMap<Dota, DotaVM>();
            CreateMap<Tournament, DotaTournamentVM>();
        }
    }
}
