using com.gameon.data.Database.Interfaces;
using com.gameon.data.Database.Models;
using com.gameon.data.Database.Repositories;
using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Services;
using Microsoft.Extensions.DependencyInjection;

namespace com.gameon.domain.Frameworks
{
    public class ServiceManager
    {
        public static void InjectServices(IServiceCollection services)
        {
            // Private Database Repositories
            services.AddTransient<IDotaRepository, DotaRepository>();
            services.AddTransient<IDocumentRepository<Dota>, MongoBaseRepository<Dota>>();

            // Third Party Api Services
            services.AddHttpClient<IFootballApiService, FootballApiService>();
            services.AddHttpClient<INbaApiService, NbaApiService>();
            services.AddHttpClient<ITennisApiService, TennisApiService>();
            services.AddHttpClient<IESportsApiService, ESportsApiService>();
        }
    }
}
