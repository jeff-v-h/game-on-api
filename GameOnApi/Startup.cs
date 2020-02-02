using AutoMapper;
using com.gameon.domain.Frameworks;
using com.gameon.domain.Interfaces;
using com.gameon.domain.Managers;
using com.gameon.domain.Models.MappingProfiles;
using GameOnApi.CustomExceptionMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GameOnApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            // Register mapping
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Dota2Profile());
                mc.AddProfile(new EsportsProfile());
                mc.AddProfile(new FootballProfile());
                mc.AddProfile(new NbaProfile());
                mc.AddProfile(new TennisProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Game On API", Version = "v1" });
            });

            // Add services in data layer via ServiceManager and the domain layer
            ServiceManager.InjectServices(services);
            services.AddTransient<IDotaManager, DotaManager>();
            services.AddTransient<IFootballManager, FootballManager>();
            services.AddTransient<INbaManager, NbaManager>();
            services.AddTransient<ITennisManager, TennisManager>();
            services.AddTransient<IEsportsManager, EsportsManager>();
            services.AddTransient<IGeneralManager, GeneralManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Game On API v1");
                // Set RoutePrefix to an empty string to serve swagger UI as the app's root
                c.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
