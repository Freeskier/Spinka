using System;
using System.Linq;
using System.Reflection;
using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Spinka.Api.Utils;
using Spinka.Application.Dispatchers;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Auth;
using Spinka.Infrastructure.Database;
using Spinka.Infrastructure.Mappers;
using Spinka.Infrastructure.Options;
using Spinka.Infrastructure.Repositories;

namespace Spinka.Api.Extensions
{
    public static class ConfigureServicesExtension
    {
        public static void AddSqlConfiguration(this IServiceCollection services, IConfiguration configuration, string section)
        {
            services.Configure<SqlOption>(x => configuration.GetSection(section).Bind(x));
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
        }

        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration, string section)
        {
            services.Configure<JwtOption>(x => configuration.GetSection(section).Bind(x));
            var jwtOption = new JwtOption();
            var jwtSection = configuration.GetSection(section);
            jwtSection.Bind(jwtOption);
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.SecretKey)),
                        ValidIssuer = jwtOption.Issuer,
                        ValidateAudience = false,
                        ValidateLifetime = jwtOption.ValidateLifetime
                    };
                });
        }

        public static void AddRepository(this IServiceCollection services)
            => services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        public static void AddRepositoryHelper(this IServiceCollection services)
           => services.AddScoped(typeof(IRepositoryHelper<>), typeof(RepositoryHelper<>));

        public static void AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        public static void AddJwt(this IServiceCollection services)
            => services.AddScoped<IJwtHandler, JwtHandler>();
        
        public static void AddPdf(this IServiceCollection services)
            => services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        
        public static void AddLogger(this IServiceCollection services)
        {
            services.AddLogging(builder => 
            {
                builder.AddSerilog(dispose: true);
            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(Consts.ApiVersion, new OpenApiInfo
                {
                    Title = Consts.ApiTitle,
                    Version = Consts.ApiVersion
                });
            });
        }

        public static void AddCommandAndQueryHandlers(this IServiceCollection services)
        {
            services.HandlerAssemblyInjector(typeof(ICommand), typeof(ICommandHandler<>));
            services.HandlerAssemblyInjector(typeof(IQuery<>), typeof(IQueryHandler<,>));
        }

        public static void AddDispatchers(this IServiceCollection services)
        {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IDispatcher, Dispatcher>();
        }
        
        public static void AddMappers(this IServiceCollection services)
        {
            services.MapperAssemblyInjector(typeof(IMapper<,>));
            services.MapperAssemblyInjector(typeof(IMapperWithParams<,>));
        }
        
        private static void HandlerAssemblyInjector(this IServiceCollection services, Type assemblyType, Type handlerType)
        {
            var handlers = assemblyType.Assembly.GetTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == handlerType)
                );

            foreach (var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerType), handler);
            }
        }

        private static void MapperAssemblyInjector(this IServiceCollection services, Type mapperType)
        {
            var assemblies = Assembly.GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load)
                .SelectMany(item => item.GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract))
                .ToList();
            
            foreach (var type in assemblies)
            {
                foreach (var i in type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapperType))
                {

                    var interfaceType = mapperType.MakeGenericType(i.GetGenericArguments());
                    services.Add(new ServiceDescriptor(interfaceType, type, ServiceLifetime.Scoped));
                }
            }
        }
    }
}