using ProxyReverse.Client.DependencyInjection.Setup;
using System.Threading.Tasks;
using DependencyInjection;

namespace ProxyReverse.Client.DependencyInjection
{
    public class ClientApp 
    {
        private DefaultClientAppContext ClientAppContext { get; }
        private ClientApp() => ClientAppContext = new DefaultClientAppContext();

        public async Task RunAsync()
             => await ClientAppContext.StartAsync<StartUpService>();

        private static ClientApp _instance;
        public static ClientApp Instance { get => _instance ?? (_instance = new ClientApp()); }
    }
}
