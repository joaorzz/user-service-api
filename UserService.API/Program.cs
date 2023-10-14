using Crosscutting.IOC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using OpenTelemetry.Resources;
using System.Reflection;
using UserService.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

ResourceBuilder resourceBuilder = ResourceBuilder.CreateDefault().AddService(serviceName: builder.Environment.ApplicationName,
    serviceVersion: Assembly.GetExecutingAssembly().GetName().Version.ToString(),
    serviceNamespace: builder.Environment.EnvironmentName,
    serviceInstanceId: Environment.MachineName);

builder.AddOpenTelemetryLogging(resourceBuilder);
builder.Services.AddOpenTelemetry().AddTracing(builder.Configuration, resourceBuilder);

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.AddJwtAuth();
builder.Services.AddHsts(options =>
{
    options.IncludeSubDomains = true;
    options.Preload = true;
    options.MaxAge = TimeSpan.FromMinutes(5);
});

builder.Services.AddResponseCompression(configureOptions =>
{
    configureOptions.EnableForHttps = true;
    configureOptions.Providers.Add<GzipCompressionProvider>();
});

builder.Services.AddResponseTime();
builder.Services.AddGlobalExceptionHandler();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });
}

app.UseResponseTime();
app.UseGlobalExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
