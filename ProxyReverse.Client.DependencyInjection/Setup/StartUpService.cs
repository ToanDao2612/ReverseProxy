using ProxyReverse.Client.ConfigReader;
using ProxyReverse.Client.HttpRequester;
using System.Threading.Tasks;
using ProxyReverse.Client.Connection;
using ProxyReverse.Client.Connectors;
using DependencyInjection;

namespace ProxyReverse.Client.DependencyInjection.Setup
{
    internal class StartUpService : IStartUpService
    {
        public IWebRequest WebRequest { get; }
        public IConectionRequestProvider ConectionRequestProvider { get; }
        public IConnectorFactory Connector { get; }

        internal StartUpService(
            IWebRequest webRequest, 
            IConectionRequestProvider conectionRequestProvider,
            IConnectorFactory connector)
        {
            WebRequest = webRequest;
            ConectionRequestProvider = conectionRequestProvider;
            Connector = connector;
        }


        public async Task RunAsync()
        {
            var connectionRequest = ConectionRequestProvider.GetConnectionRequest();
            var connectionResponse = await WebRequest.NewRequestConnectionAsync(connectionRequest);
            if(!connectionResponse.IsSuccesful)
            {
                //throw new StartUpException();
            }

            var tunnel = Connector.CreateTunnel(connectionResponse);
            await tunnel.ProceedCommunication();
        }
    }
}
