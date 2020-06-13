using Base.Core.Services;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using ProxyReverse.Web.Core.InternalyImplementedServices.Tunnel.Models;

namespace ProxyReverse.Web.Services.WebImplementedServices
{
    internal class NewConnectorRequestMessageHandler : IMessageHandler<string>
    {
        public NewConnectorRequestMessageHandler(
            IJsonConvertor jsonConvertor,
            ICurrentTunnelsAccesor currentTunnelsAccesor)
        {
            JsonConvertor = jsonConvertor;
            CurrentTunnelsAccesor = currentTunnelsAccesor;
        }

        private IJsonConvertor JsonConvertor { get; }
        public ICurrentTunnelsAccesor CurrentTunnelsAccesor { get; }

        public void HandleMessage(string data)
        {
            var tunnel = JsonConvertor.ConvertToClass<Tunnel>(data);
            CurrentTunnelsAccesor.AddTunnel(tunnel);
        }
    }
}