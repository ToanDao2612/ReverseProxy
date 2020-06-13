using ProxyReverse.Web.Core.ExternalyImplementedServices;
using ProxyReverse.Web.Core.ExternalyImplementedServices.Models;
using System;

namespace ProxyReverse.Web.Core.InternalyImplementedServices.Tunnel.Models
{
    public interface ITunnelRequestHandler
    {
        public void CreateTunnel();
    }

    public class TunnelRequestHandler : ITunnelRequestHandler
    {
        public TunnelRequestHandler(
            ITunnelExternalQueueAccessor tunnelExternalQueueAccessor, 
            IUserUrlProvider userUrlProvider,
            IIdentityProvider identityProvider)
        {
            TunnelExternalQueueAccessor = tunnelExternalQueueAccessor;
            UserUrlProvider = userUrlProvider;
            IdentityProvider = identityProvider;
        }

        public ITunnelExternalQueueAccessor TunnelExternalQueueAccessor { get; }
        public IUserUrlProvider UserUrlProvider { get; }
        public IIdentityProvider IdentityProvider { get; }

        private string _userUrl;
        private string UserUrl => _userUrl ?? (_userUrl = UserUrlProvider.GetUrlForUser());
        private UserIdentity _userIdentity;
        private UserIdentity UserIdentity => _userIdentity ?? (_userIdentity = IdentityProvider.GetUserIdendity());

        public void CreateTunnel()
        {
            var tunnel = new Tunnel(TunnelType.Http, UserUrl, UserIdentity.UserId);
            TunnelExternalQueueAccessor.SendDataToQueue(tunnel);
        }
    }
}
