using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureFunctionTimeTrigger.Bootstrapper
{
    public static class ConfigurationServices
    {
        public static void IniciaServicos(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationInsightsKey = configuration.GetSection("Values")["InstrumentationKey"];

            var aiOptions = new ApplicationInsightsServiceOptions
            {
                EnableAdaptiveSampling = false,
                InstrumentationKey = applicationInsightsKey
            };

            services.AddApplicationInsightsTelemetry(aiOptions);
        }
    }
}
