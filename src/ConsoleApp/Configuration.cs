using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;


namespace ConsoleApp
{
    public static class Configuration
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var configurationDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var builder = new ConfigurationBuilder()
                .SetBasePath(configurationDir)
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.Production.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
