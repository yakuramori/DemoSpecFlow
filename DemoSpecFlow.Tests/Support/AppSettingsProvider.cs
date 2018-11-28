using System.IO;
using Microsoft.Extensions.Configuration;

namespace DemoSpecFlow.Tests.Support
{
    public class AppSettingsProvider
    {
        private readonly IConfiguration _config;

        public AppSettingsProvider()
        {
            _config = InitConfiguration();
        }
        public string Get(string name)
        {
            return _config[name];
        }

        public IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Path.GetDirectoryName(typeof(AppSettingsProvider).Assembly.Location), "appsettings.json"))
                .Build();
            return config;
        }
    }
}
