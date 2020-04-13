using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(AzureFunctionTimeTrigger.Bootstrapper.Startup))]
namespace AzureFunctionTimeTrigger.Bootstrapper
{
    class Startup : FunctionsStartup
    {
        private static IConfiguration _configuration;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            var fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);

            string path = fileInfo.Directory.Parent.FullName;

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .SetBasePath(path)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.IniciaServicos(_configuration);
        }
    }
}
