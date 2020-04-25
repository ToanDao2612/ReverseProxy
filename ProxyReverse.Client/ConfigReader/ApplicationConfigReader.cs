using Newtonsoft.Json;
using System;

namespace ProxyReverse.Client.ConfigReader
{

    public interface IApplicationConfigReader
    {
        WebApplicationConfigs GetWebApp();
        WebApplicationConfigs GetWebApi();
    }
    public class ApplicationConfigReader : IApplicationConfigReader
    {
        private const string WebAppConfigsKey = "web_app";
        private const string WebApiConfigsKey = "web_api";
        public WebApplicationConfigs GetWebApp() => ReadWebApplicationConfigFromEnvironamenVariable(WebAppConfigsKey);
        public WebApplicationConfigs GetWebApi() => ReadWebApplicationConfigFromEnvironamenVariable(WebApiConfigsKey);

        private WebApplicationConfigs ReadWebApplicationConfigFromEnvironamenVariable(string key)
        {
            var webApplicationPortConfigArg = Environment.GetEnvironmentVariable(key) ?? throw new ArgumentNullException($"Not found environament key: {key}");
            var webApplicationPortConfigs = JsonConvert.DeserializeObject<WebApplicationConfigs>(webApplicationPortConfigArg);
            return webApplicationPortConfigs;
        }
    }
}
