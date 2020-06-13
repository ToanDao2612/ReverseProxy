using Microsoft.AspNetCore.SignalR;
using ProxyReverse.Web.Core.InternalyImplementedServices.Request;
using ProxyReverse.Web.Services.Orchestrator;
using System;
using System.Threading.Tasks;

namespace ProxyReverse.Web.Services.SignalRHubs
{
    public class TunnelWebSocketHub : Hub
    {
        public TunnelWebSocketHub(IRequestsDictionaryAccesor requestsDictionaryAccesor)
        {
            RequestsDictionaryAccesor = requestsDictionaryAccesor;
        }

        public IRequestsDictionaryAccesor RequestsDictionaryAccesor { get; }

        public void ReceiveResponseForRequest(Guid requestId,string response)
        {
            RequestsDictionaryAccesor.CompleteRequest(requestId, response);
        }
    }
}