using Newtonsoft.Json;

namespace ProxyReverse.Client.ConfigReader
{
    public class WebApplicationConfigs
    {
        [JsonProperty("uri")]
        public string RequestConnectionUrl { get; set; }

        public long Http { get; set; }
        public long Https { get; set; }
    }
}
