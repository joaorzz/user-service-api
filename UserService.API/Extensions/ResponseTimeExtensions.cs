using Microsoft.Extensions.DependencyInjection.Extensions;
using UserService.API.Middleware;
using UserService.API.Middleware.Interfaces;

namespace UserService.API.Extensions
{
    public static class ResponseTimeExtensions
    {
        public static IServiceCollection AddResponseTime(this IServiceCollection services)
        {
            services.TryAddSingleton<ResponseTimeMiddleware, ResponseTimeMiddleware>();
            services.AddSingleton<IStopwatchProvider, StopwatchProvider>();
            services.AddSingleton<IHeaderHandler, HeaderHandler>();

            return services;
        }

        public static IApplicationBuilder UseResponseTime(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ResponseTimeMiddleware>();
        }
    }
}
