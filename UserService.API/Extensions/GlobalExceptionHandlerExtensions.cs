using Microsoft.Extensions.DependencyInjection.Extensions;
using UserService.API.Middleware;

namespace UserService.API.Extensions
{
    public static class GlobalExceptionHandlerExtensions
    {
        public static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services)
        {
            services.TryAddSingleton<GlobalExceptionHandlerMiddleware, GlobalExceptionHandlerMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
