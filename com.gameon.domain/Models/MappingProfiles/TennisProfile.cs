using AutoMapper;
using com.gameon.data.ThirdPartyApis.Models.Tennis;
using com.gameon.domain.Models.ViewModels.Tennis;

namespace com.gameon.domain.Models.MappingProfiles
{
    public class TennisProfile : Profile
    {
        public TennisProfile()
        {
            CreateMap<TournamentsApi, TournamentsApiVM>();
            CreateMap<TennisTournament, TournamentVM>();
            CreateMap<Identifier, IdentifierVM>();
            CreateMap<Category, CategoryVM>();
            CreateMap<Season, SeasonVM>();
            CreateMap<InfoApi, InfoApiVM>();
            CreateMap<TournamentRound, TournamentRoundVM>();
            CreateMap<Info, InfoVM>();
            CreateMap<CoverageInfo, CoverageInfoVM>();
            CreateMap<PlayerBase, PlayerBaseVM>();
            CreateMap<TennisCompetitor, TennisCompetitorVM>();
            CreateMap<Stage, StageVM>();
            CreateMap<TennisCompetitor, TennisCompetitorVM>();
            CreateMap<ScheduleApi, ScheduleApiVM>();
            CreateMap<SportEvent, SportEventVM>();
            CreateMap<Venue, VenueVM>();
            CreateMap<RankingsApi, RankingsApiVM>();
            CreateMap<AssociationRankings, AssociationRankingsVM>();
            CreateMap<PlayerRank, PlayerRankVM>();
            CreateMap<Player, PlayerVM>();
            CreateMap<AssociationRankings, AssociationRankingsVM>();
        }
    }
}
