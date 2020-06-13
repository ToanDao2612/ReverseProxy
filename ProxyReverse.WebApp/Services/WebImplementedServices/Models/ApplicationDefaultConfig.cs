using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxyReverse.WebApp.Services.WebImplementedServices.Models
{
    public class ApplicationDefaultConfig
    {
        public const string ApplicationDefaultConfigKey = nameof(ApplicationDefaultConfig);
        public IEnumerable<string> MainUrls { get; set; }
    }
}
