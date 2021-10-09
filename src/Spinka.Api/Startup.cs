using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Spinka.Api.Extensions;
using Spinka.Api.Middlewares;
using Spinka.Application.Utils.BackgroundTasks;
using Spinka.Application.Utils.Mappings;
using Spinka.Infrastructure.Database;
using Consts = Spinka.Api.Utils.Consts;

namespace Spinka.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console()
                .WriteTo.File("")
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSqlConfiguration(Configuration, Consts.DbConfigurationSection);
            services.AddJwtConfiguration(Configuration, Consts.JwtConfigurationSection);
            services.AddHttpContextAccessor();
            services.AddDbContext<SpinkaContext>(cfg =>
                cfg.EnableSensitiveDataLogging());
            services.AddMemoryCache();
            services.AddRepository();
            services.AddRepositoryHelper();
            services.AddUnitOfWork();
            services.AddJwt();
            services.AddPdf();
            services.AddMappers();
            services.AddHostedService<CacheBackgroundTaskService>();
            services.AddCommandAndQueryHandlers();
            services.AddDispatchers();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();

            services.AddLogger();
            
            services.AddSwagger();
            services.AddSingleton<IClaimsTransformation, ClaimsTransformer>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  
                DatabaseInitializer.PrepPopulation(app).Wait();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(x => x.WithOrigins(Consts.ClientAppUrl)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Token"));
            //AddCredentials() To Turn on windows Auth.

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseErrorHandler();
            app.UseLogger();
            //app.UseAuthorizationMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(Consts.ApiSwaggerUrl, Consts.ApiName);
            });

        }
    }
}
