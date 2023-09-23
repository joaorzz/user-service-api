using Microsoft.OpenApi.Models;

namespace UserService.API.Extensions
{
    public static class SwaggerConfigurationExtensions
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API v1", Version = "v1" });
            });

            return services;
        }
    }
}
