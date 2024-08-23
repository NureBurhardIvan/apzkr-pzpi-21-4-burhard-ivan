using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.SecurityToken.Model;
using Application.Common.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var awsOptions = new AWSOptions
        {
            Credentials = new BasicAWSCredentials(configuration["AWS:AccessKey"], configuration["AWS:SecretKey"])
        };

        services.AddDefaultAWSOptions(awsOptions);
        services.AddCognitoIdentity();
        services.AddScoped<IAuthService, CognitoAuthService>();
        return services;
    }
}
