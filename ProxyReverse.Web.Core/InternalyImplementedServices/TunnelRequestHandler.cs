using ProxyReverse.Web.Core.DataTransferObjects;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using System;

namespace ProxyReverse.Web.Core.InternalyImplementedServices
{
    public interface ITunnelRequestHandler
    {
        public ITunnelRequestHandler CreateTunnel(HttpTunelRequest httpTunelRequest);
    }

    public class TunnelRequestHandler : ITunnelRequestHandler
    {
        public TunnelRequestHandler(ITunnelRequestedQueueExposer tunnelRequestedQueueExposer)
        {
            TunnelRequestedQueueExposer = tunnelRequestedQueueExposer;
        }

        public ITunnelRequestedQueueExposer TunnelRequestedQueueExposer { get; }

        public ITunnelRequestHandler CreateTunnel(HttpTunelRequest httpTunelRequest)
        {
            TunnelRequestedQueueExposer.SendRequest(httpTunelRequest);
            return this;
        }
    }
}
