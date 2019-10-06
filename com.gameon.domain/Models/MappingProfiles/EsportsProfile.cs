using AutoMapper;
using com.gameon.data.ThirdPartyApis.Models.Esports;
using com.gameon.domain.Models.ViewModels.Esports;

namespace com.gameon.domain.Models.MappingProfiles
{
    public class EsportsProfile : Profile
    {
        public EsportsProfile()
        {
            CreateMap<EsportsTournament, EsportsTournamentVM>();
            CreateMap<EsportsTeamBase, EsportsTeamBaseVM>();
            CreateMap<SeriesBase, SeriesBaseVM>();
            CreateMap<MatchBase, MatchBaseVM>();
            CreateMap<League, LeagueVM>();
            CreateMap<Live, LiveVM>();

            CreateMap<EsportsTeam, EsportsTeamVM>();
            CreateMap<Player, EsportsPlayerVM>();

            CreateMap<Series, SeriesVM>();
            CreateMap<TournamentBase, TournamentBaseVM>();

            CreateMap<Match, MatchVM>();
            CreateMap<VideoGame, VideoGameVM>();
            CreateMap<Result, ResultVM>();
            CreateMap<Competitor, EsportsCompetitorVM>();
            CreateMap<Game, EsportsGameVM>();
            CreateMap<Winner, WinnerVM>();
        }
    }
}
