using Application.Handlers.Queries;
using Domain.Repositories.ReadOnly;
using Domain.Repositories.Writable;
using Domain.Services;
using Domain.Services.Interfaces;
using Infrastructure.Configuration;
using Infrastructure.Data;
using Infrastructure.Repositories.ReadOnly;
using Infrastructure.Repositories.Writable;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Crosscutting.IOC
{
    public static class DependencyRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(x =>
            {
                Assembly assembly = typeof(GetUserQueryHandler).Assembly;
                x.RegisterServicesFromAssembly(assembly);
            });
            services.RegisterDomainLayer();
            services.RegisterInfrastructureLayer(configuration);
        }

        private static void RegisterDomainLayer(this IServiceCollection services)
        {
            services.AddSingleton<IUserReadOnlyService, UserReadOnlyService>();
            services.AddSingleton<IUserWritableService, UserWritableService>();
        }

        private static void RegisterInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserReadOnlyRepository, UserReadOnlyRepository>();
            services.AddSingleton<IUserWritableRepository, UserWritableRepository>();
            services.AddSingleton<IDbConnectionFactory, NpgsqlDbConnectionFactory>();
            services.AddSingleton<IDbService, DbService>();

            services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
            services.AddSingleton(x => x.GetRequiredService<IOptions<ConnectionStrings>>().Value);
        }

    }
}