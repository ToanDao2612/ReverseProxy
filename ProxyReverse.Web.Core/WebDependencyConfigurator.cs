using DependencyInjection;
using ProxyReverse.Web.Core.InternalyImplementedServices;
using ProxyReverse.Web.Core.InternalyImplementedServices.Tenant;
using ProxyReverse.Web.Core.InternalyImplementedServices.Tunnel.Models;

namespace ProxyReverse.Web.Core
{
    public class WebDependencyConfigurator : IDependencyConfigurator
    {
        public void ConfigureService(IContainer container)
        {
            container.RegisterType<ITunnelRequestHandler, TunnelRequestHandler>();
            container.RegisterType<ITenantProvider, TenantProvider>();
            container.RegisterType<IUserUrlProvider, UserUrlProvider>();
        }
    }
}