using InsellerateApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace InsellerateApi.Extensions;

public static class InsellerateServiceExtension
{
    public static IServiceCollection AddInsellerateApiClient(this IServiceCollection services, IConfiguration configuration, ILogger logger)
    {
        logger.LogInformation("Starting the addition of Insellerate API client");
        services.Configure<InsellerateConfig>(configuration.GetSection("Insellerate"));
        services.AddSingleton<IInsellerateApiClient, InsellerateApiClientClient>();
        TestInsellerateConnection(services, logger);
        return services;
    }
    
    private static void TestInsellerateConnection(IServiceCollection services, ILogger logger)
    {
        var serviceProvider = services.BuildServiceProvider();
        var insellerateApi = serviceProvider.GetRequiredService<IInsellerateApiClient>();
        try
        {
            logger.LogInformation("Attempting to connect to Insellerate API");
            var result = insellerateApi.TestConnection().GetAwaiter().GetResult();
            if (result is null) throw new InvalidOperationException("Failed to connect to Insellerate API");
            logger.LogInformation("Successfully connected to Insellerate API");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error connecting to Insellerate API");
            throw;
        }
    }
}