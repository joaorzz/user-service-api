using Npgsql;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace UserService.API.Extensions
{
    public static class OpenTelemetryConfigurationExtensions
    {
        public static void AddOpenTelemetryLogging(this WebApplicationBuilder webApplicationBuilder, ResourceBuilder resourceBuilder)
        {
            webApplicationBuilder.Logging.ClearProviders().AddOpenTelemetry(options =>
            {
                options.SetResourceBuilder(resourceBuilder);
                options.AddOtlpExporter(otlpOptions =>
                {
                    otlpOptions.Endpoint = new Uri("http://otlp-collector:4317");
                });
                options.AddConsoleExporter();
                options.IncludeScopes = true;
                options.ParseStateValues = true;
            });
        }

        public static OpenTelemetryBuilder AddTracing(this OpenTelemetryBuilder openTelemetryBuilder, IConfiguration configuration, ResourceBuilder resourceBuilder)
        {
            openTelemetryBuilder.WithTracing(traceProviderBuilder =>
            {
                traceProviderBuilder.AddAspNetCoreInstrumentation()
                .SetResourceBuilder(resourceBuilder)
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation()
                .AddNpgsql()
                .AddConsoleExporter()
                .AddOtlpExporter(otlpExporterOptions =>
                {
                    otlpExporterOptions.Endpoint = new Uri("http://otlp-collector:4317");
                });
            });

            return openTelemetryBuilder;
        }
    }
}
