using AutoMapper;
using com.gameon.data.ThirdPartyApis.Models.Football;
using com.gameon.domain.Models.ViewModels.Football;

namespace com.gameon.domain.Models.MappingProfiles
{
    public class FootballProfile : Profile
    {
        public FootballProfile()
        {
            CreateMap<Fixture, FixtureVM>();
            CreateMap<FootballTeamBase, TeamBaseVM>();
            CreateMap<Score, ScoreVM>();
            CreateMap<FootballTeam, TeamVM>();
        }
    }
}
