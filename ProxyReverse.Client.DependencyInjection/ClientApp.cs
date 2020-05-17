using ProxyReverse.Client.DependencyInjection;
using ProxyReverse.Client.DependencyInjection.Setup;
using ProxyReverse.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProxyReverse.Client.DependencyInjection
{
    public class ClientApp 
    {
        public DefaultClientAppContext ClientAppContext { get; }
        private ClientApp()
        {
            ClientAppContext = new DefaultClientAppContext();

        }
        public void ConfigureDependencyInjection()
        {
            ClientAppContext
                .UseContext()
                .ConfigureServices<ClientDependencyConfigurator>();
        }

        public async Task RunAsync()
        {
            await ClientAppContext.StartAsync<StartUpService>();
        }

        private static ClientApp _instance;
        public static ClientApp Instance { get => _instance ?? (_instance = new ClientApp()); }
    }
}
