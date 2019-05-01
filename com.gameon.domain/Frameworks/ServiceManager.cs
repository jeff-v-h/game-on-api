using com.gameon.data.Interfaces;
using com.gameon.data.Models;
using com.gameon.data.Repositories;
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
