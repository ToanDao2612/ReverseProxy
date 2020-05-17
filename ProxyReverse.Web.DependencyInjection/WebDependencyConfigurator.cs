using ProxyReverse.DependencyInjection;
using ProxyReverse.RabitMqInterface;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using ProxyReverse.Web.Core.InternalyImplementedServices;

namespace ProxyReverse.Web.DependencyInjection
{
    public class WebDependencyConfigurator : IDependencyConfigurator
    {
        public void ConfigureService(IContainer container)
        {
            container.RegisterType<ITunnelRequestHandler, TunnelRequestHandler>();
            container.RegisterType<ITunnelRequestedQueueExposer, RabbitQueueExposer>();
        }
    }
}