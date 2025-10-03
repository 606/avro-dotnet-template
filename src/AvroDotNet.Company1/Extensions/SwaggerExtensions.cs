namespace AvroDotNet.Company1.Extensions;

/// <summary>
/// Extension methods for configuring Swagger/OpenAPI
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// Adds Swagger services to the service collection
    /// </summary>
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "AvroDotNet.Company1 API",
                Version = "v1",
                Description = "A backend API built with .NET 10"
            });
        });
        
        return services;
    }
}
