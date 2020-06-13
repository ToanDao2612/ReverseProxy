using DependencyInjection;
using Json.NewtonSoft.ThirdParty;
using ProxyReverse.RabitMqInterface;
using ProxyReverse.Web.Core;

namespace ProxyReverse.Web.DependencyInjection
{
    public class WebApplicationContext : AbstractApplicationContext
    {
        public WebApplicationContext()
        {
            ServiceProviderBuilder
                .ConfigureServices<WebDependencyConfigurator>()
                .ConfigureServices<RabitMqDependencies>()
                .ConfigureServices<JsonDependencyies>();
        }
    }
}
