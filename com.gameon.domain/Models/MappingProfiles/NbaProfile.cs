using AutoMapper;
using com.gameon.data.ThirdPartyApis.Models.Nba;
using com.gameon.domain.Models.ViewModels.Nba;

namespace com.gameon.domain.Models.MappingProfiles
{
    public class NbaProfile : Profile
    {
        public NbaProfile()
        {
            CreateMap<NbaGame, NbaGameVM>();
            CreateMap<NbaGameDetails, NbaGameDetailsVM>();
            CreateMap<CompetingTeamDetails, CompetingTeamDetailsVM>();
            CreateMap<NbaScore, NbaScoreVM>();
            CreateMap<StatsLeader, StatsLeaderVM>();
            CreateMap<CompetingTeam, CompetingTeamVM>();
            CreateMap<NbaScoreBase, NbaScoreBaseVM>();
            CreateMap<StatsLeader, StatsLeaderVM>()
                .ForMember(dest => dest.Stat, opt => opt.MapFrom<StatNameResolver>())
                .ForMember(dest => dest.Value, opt => opt.MapFrom<StatValueResolver>());
            CreateMap<Official, OfficialVM>();
            CreateMap<Leagues, LeaguesVM>();
            CreateMap<Standard, StandardVM>();
            CreateMap<NbaScore, NbaScoreVM>();
            CreateMap<NbaTeam, NbaTeamVM>();
        }
    }

    public class StatNameResolver : IValueResolver<StatsLeader, StatsLeaderVM, string>
    {
        public string Resolve(StatsLeader source, StatsLeaderVM destination, string member, ResolutionContext context)
        {
            return (source.Points != null) ? "Points"
                : (source.Assists != null) ? "Assists"
                : (source.Rebounds != null) ? "Rebounds" 
                : "";
        }
    }

    public class StatValueResolver : IValueResolver<StatsLeader, StatsLeaderVM, string>
    {
        public string Resolve(StatsLeader source, StatsLeaderVM destination, string member, ResolutionContext context)
        {
            return (source.Points != null) ? source.Points
                : (source.Assists != null) ? source.Assists
                : (source.Rebounds != null) ? source.Rebounds 
                : "";
        }
    }
}
