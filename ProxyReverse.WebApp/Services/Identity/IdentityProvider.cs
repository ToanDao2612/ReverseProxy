using ProxyReverse.Web.Core.ExternalyImplementedServices;
using ProxyReverse.Web.Core.ExternalyImplementedServices.Models;

namespace ProxyReverse.Web.Services.Identity
{
    public class IdentityProvider : IIdentityProvider
    {
        public IdentityProvider()
        {
        }

        public UserIdentity GetUserIdendity()
        {
            return new UserIdentity(1);
        }
    }
}
