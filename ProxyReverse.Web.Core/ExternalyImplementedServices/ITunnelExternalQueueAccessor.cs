using ProxyReverse.Web.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Web.Core.ExternalyImplementedServices
{
    public interface ITunnelExternalQueueAccessor
    {
        void SendRequest(AbstractTunnelRequest httpTunelRequest);
        void ReceiveWork(IMessageHandler<string> messageHandler);
    }
}
