using DependencyInjection;
using ProxyReverse.Web.Core.InternalyImplementedServices;

namespace ProxyReverse.Web.Core
{
    public class WebDependencyConfigurator : IDependencyConfigurator
    {
        public void ConfigureService(IContainer container)
        {
            container.RegisterType<ITunnelRequestHandler, TunnelRequestHandler>();
        }
    }
}