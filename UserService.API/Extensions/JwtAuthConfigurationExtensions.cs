using Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace UserService.API.Extensions
{
    public static class JwtAuthConfigurationExtensions
    {
        public static void AddJwtAuth(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                JwtAuthSettings jwtAuthSettings = applicationBuilder.Configuration.GetSection(nameof(JwtAuthSettings)).Get<JwtAuthSettings>();

                options.Authority = jwtAuthSettings.Authority;
                options.Audience = jwtAuthSettings.Audience;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtAuthSettings.Issuer,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtAuthSettings.GetEncodedSecret())
                };
            });
        }
    }
}
