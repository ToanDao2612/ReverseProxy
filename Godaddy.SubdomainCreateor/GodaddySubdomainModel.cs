using Newtonsoft.Json;

namespace GoDaddy.SubdomainCreator
{
    internal class GodaddySubdomainModel
    {
        public GodaddySubdomainModel()
        {
        }
        [JsonProperty("data")]
        public string Ip { get; set; }
        [JsonProperty("name")]
        public string SubdomainName { get; set; }
        [JsonProperty("ttl")]
        public int RefreshRate { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}