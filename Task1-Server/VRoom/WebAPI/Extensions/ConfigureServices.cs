using Application.Common.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.OptionsSetup;

namespace WebAPI.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection RegisterWebApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.ConfigureOptions<AwsOptionsSetup>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Authentication Token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JsonWebToken",
                Scheme = "Bearer"
            });
        });
        var awsOptions = services.BuildServiceProvider().GetService<IOptions<AwsOptions>>()!.Value;
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://cognito-idp.{awsOptions.Region}.amazonaws.com/{awsOptions.UserPoolId}";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = $"https://cognito-idp.{awsOptions.Region}.amazonaws.com/{awsOptions.UserPoolId}",
                    ValidateLifetime = true,
                    LifetimeValidator = (_, expires, _, _) => expires > DateTime.UtcNow,
                    ValidateAudience = false,
                    RoleClaimType = "custom:role"
                };
            });
        services.AddAuthorization();
        return services;
    }
}