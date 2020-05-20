using ProxyReverse.Web.Core.DataTransferObjects;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using System;

namespace ProxyReverse.Web.Core.InternalyImplementedServices
{
    public interface ITunnelRequestHandler
    {
        public void CreateTunnel(HttpTunelRequest httpTunelRequest);
    }

    public class TunnelRequestHandler : ITunnelRequestHandler
    {
        public TunnelRequestHandler(ITunnelExternalQueueAccessor tunnelExternalQueueAccessor, IUserUrlProvider userUrlProvider)
        {
            TunnelExternalQueueAccessor = tunnelExternalQueueAccessor;
            UserUrlProvider = userUrlProvider;
        }

        public ITunnelExternalQueueAccessor TunnelExternalQueueAccessor { get; }
        public IUserUrlProvider UserUrlProvider { get; }

        private string _userUrl;
        private string UserUrl => _userUrl ?? (_userUrl = UserUrlProvider.GetUrlForUser());

        public void CreateTunnel(HttpTunelRequest httpTunelRequest)
        {
            httpTunelRequest.UserUrl = UserUrl;
            TunnelExternalQueueAccessor.SendRequest(httpTunelRequest);
        }
    }
}
