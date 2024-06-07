using ExampleApp.Exceptions;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace ExampleApp.Extensions;

public static class LocalizationExtensions
{
    public static IServiceCollection AddResourceLocalization(this IServiceCollection services)
    {
        try
        {
            services.AddLocalization();
        }
        catch (Exception ex)
        {
            throw new LocalizationException("An error occurred while setting up localization.", ex);
        }

        return services;
    }    
}