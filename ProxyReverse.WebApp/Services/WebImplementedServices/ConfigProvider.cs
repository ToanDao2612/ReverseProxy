using ProxyReverse.Web.Core.ExternalyImplementedServices;
using ProxyReverse.WebApp.Services.WebImplementedServices.Models;
using System.Collections.Generic;

namespace ProxyReverse.WebApp.Services.WebImplementedServices
{
    public class ConfigProvider : IConfigurationProvider
    {

        public ConfigProvider(ApplicationDefaultConfig applicationDefaultConfig)
        {
            ApplicationDefaultConfig = applicationDefaultConfig;
        }

        public ApplicationDefaultConfig ApplicationDefaultConfig { get; }

        public IEnumerable<string> GetMainUrls()
            => ApplicationDefaultConfig.MainUrls;
    }
}
