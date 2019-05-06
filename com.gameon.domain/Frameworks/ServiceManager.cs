using com.gameon.data.Database.Interfaces;
using com.gameon.data.Database.Models;
using com.gameon.data.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace com.gameon.domain.Frameworks
{
    public class ServiceManager
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IDotaRepository, DotaRepository>();
            services.AddScoped<IDocumentRepository<Dota>, MongoBaseRepository<Dota>>();
        }
    }
}
