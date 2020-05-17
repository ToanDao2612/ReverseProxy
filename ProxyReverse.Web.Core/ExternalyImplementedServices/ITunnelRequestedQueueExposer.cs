using ProxyReverse.Web.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Web.Core.ExternalyImplementedServices
{
    public interface ITunnelRequestedQueueExposer
    {
        void SendRequest(TunnelRequest httpTunelRequest);
    }
}
