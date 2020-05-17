using DependencyInjection;

namespace ProxyReverse.Client.DependencyInjection.Setup
{
    public class DefaultClientAppContext : AbstractStartupServiceApplicationContext
    {
        public DefaultClientAppContext()
        {

            ServiceProviderBuilder
                .ConfigureServices<ClientDependencyConfigurator>();
        }
    }
}
