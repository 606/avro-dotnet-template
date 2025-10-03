namespace AvroDotNet.Company1.Extensions;

/// <summary>
/// Extension methods for IServiceCollection to register application services
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all application services
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register your services here
        // Example:
        // services.AddScoped<IMyService, MyService>();
        // services.AddScoped<IMyRepository, MyRepository>();
        
        return services;
    }
}
