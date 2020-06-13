using ProxyReverse.Web.Core.ExternalyImplementedServices.Models;

namespace ProxyReverse.Web.Core.ExternalyImplementedServices
{
    public interface IIdentityProvider
    {
        UserIdentity GetUserIdendity();
    }
}
